using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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

            if (!File.Exists("devices.xml")) return;
            var xmlser = new XmlSerializer(typeof(UsbInfoList));
            var stream=new StreamReader("devices.xml");
            usbInfoList =(UsbInfoList)xmlser.Deserialize(stream);
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
            Directory.CreateDirectory(textBoxBackupPath.Text +
                                      $"{listDrives[comboBoxDevice.SelectedIndex].VolumeLabel}-Backup");


        }
    }
}
