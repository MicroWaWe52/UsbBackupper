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
            var drive = listDrives.First(d => d.VolumeLabel == comboBoxDevice.Text);
            var volumeLabel = drive.VolumeLabel;
            var backupPath = textBoxBackupPath.Text +$@"{volumeLabel}-Backup";
            Directory.CreateDirectory(backupPath);
            var deviceRoot = drive.RootDirectory;
            var id=Guid.NewGuid();
            using (var stream=new StreamWriter(deviceRoot+"UsbBackupper.bck"))
            {
                stream.WriteLine(id.ToString("D"));
                stream.Close();
            }
            usbInfoList.Add(new UsbInfoList.UsbInfo(backupPath, volumeLabel,id));
            Close();
        }
    }
}
