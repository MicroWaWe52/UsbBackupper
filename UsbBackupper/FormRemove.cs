using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsbBackupper
{
    public partial class FormRemove : Form
    {
        private UsbInfoList usbInfoList;
        public FormRemove()
        {
            InitializeComponent();
        }

        private void FormRemove_Load(object sender, EventArgs e)
        {
            usbInfoList = UsbInfoList.Deserialize() ?? new UsbInfoList();
            foreach (var usb in usbInfoList)
            {
                comboBoxRemove.Items.Add(usb.VolumeLabel);
            }

            if (comboBoxRemove.Items.Count < 1) return;
            comboBoxRemove.SelectedIndex = 0;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var deletedDrive = usbInfoList[comboBoxRemove.SelectedIndex];
                usbInfoList.RemoveAt(comboBoxRemove.SelectedIndex);

                if (checkBoxRemoveDelete.Checked)
                {
                    Task.Factory.StartNew(() => { Directory.Delete(deletedDrive.BackupPath, true); });
                }

                var drives = DriveInfo.GetDrives();
                drives = drives.Where(d => d.DriveType != DriveType.CDRom).ToArray();
                try
                {
                    File.Delete(drives.First(drive => drive.VolumeLabel == deletedDrive.VolumeLabel).RootDirectory + "UsbBackupper.bck");
                }
                finally
                {
                    Close();
                }

            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Impossibile cancellare i backup\nprobabilmente sono gia stati eliminati");
                Close();
            }

        }
    }
}
