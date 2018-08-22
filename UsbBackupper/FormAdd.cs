using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UsbBackupper
{
    public partial class FormAdd : Form
    {
        private List<DriveInfo> listDrives;
        private UsbInfoList usbInfoList;
        public FormAdd()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            listDrives = DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom).ToList();
            foreach (var drive in listDrives)
            {
                if (drive.Name != @"C:\") comboBoxDevice.Items.Add(drive.VolumeLabel);
            }

            usbInfoList = UsbInfoList.Deserialize() ?? new UsbInfoList();
            var toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500
            };
            toolTip1.SetToolTip(radioButtonFast, "Copy the entire folder of the drive");
            toolTip1.SetToolTip(radioButtonLight, "Compress the entire folder of the drive in one zip");
            toolTip1.SetToolTip(radioButtonSingle, "Compress the single folders of the drive in multiple zip");
            toolTip1.SetToolTip(radioButtonComplex, "Compress the single folders of the device and then compress in a single zip");

        }

        private void buttonBackupPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();
                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;
                textBoxBackupPath.Text = fbd.SelectedPath;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxDevice.Text) || string.IsNullOrWhiteSpace(textBoxBackupPath.Text))
            {
                return;
            }

            try
            {
                var drive = listDrives.First(d => d.VolumeLabel == comboBoxDevice.Text);
                var volumeLabel = drive.VolumeLabel;
                if (textBoxBackupPath.Text.Last() != '\\')
                {
                    textBoxBackupPath.Text += '\\';
                }
                var backupPath = textBoxBackupPath.Text + $@"{volumeLabel}-Backup";
                Directory.CreateDirectory(backupPath);
                var deviceRoot = drive.RootDirectory;
                var id = Guid.NewGuid();
                using (var stream = new StreamWriter(deviceRoot + "\\UsbBackupper.bck"))
                {
                    stream.WriteLine(id.ToString("D"));
                    stream.Close();
                }

                UsbInfoList.UsbInfo.BackupMode mode;
                if (radioButtonFast.Checked)
                {
                    mode = UsbInfoList.UsbInfo.BackupMode.Fast;
                }
                else if (radioButtonLight.Checked)
                {
                    mode = UsbInfoList.UsbInfo.BackupMode.Light;
                }
                else if (radioButtonSingle.Checked)
                {
                    mode = UsbInfoList.UsbInfo.BackupMode.Single;
                }
                else
                {
                    mode = UsbInfoList.UsbInfo.BackupMode.Complex;
                }
                usbInfoList.Add(new UsbInfoList.UsbInfo(backupPath, volumeLabel, id, mode));
                Close();
            }
            catch
            {

            }
        }
    }
}
