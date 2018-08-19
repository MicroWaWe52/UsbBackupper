using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;

namespace UsbBackupper
{
    public partial class Form1 : Form
    {
        private List<DriveInfo> listDrives;
        private UsbInfoList usbInfoList;
        public Form1()
        {
            InitializeComponent();
        }

        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var driveLetter = e.NewEvent.Properties["DriveName"].Value.ToString();
            var driveInfo = listDrives.First(d => d.Name.Contains(driveLetter));
            var label = driveInfo.VolumeLabel;
            var usbInfo = usbInfoList.First(usb => usb.VolumeLabel == label);
            var backupPath = usbInfo.BackupPath;
            if (!File.Exists(driveLetter + "UsbBackupper.bck"))
            {
                return;
            }

            string id;
            using (var stream = new StreamReader(driveLetter + "UsbBackupper.bck"))
            {
                id = stream.ReadLine();
            }

            if (id != usbInfo.DeviceId.ToString()) return;
            {
                try
                {
                    using (var zip = new ZipFile(backupPath))
                    {
                        notifyIcon1.ShowBalloonTip(8, "UsbBackupper", "Backup di " + usbInfo.VolumeLabel + " in corso", ToolTipIcon.None);
                        Directory.CreateDirectory(backupPath + "\\temp");
                        zip.TempFileFolder = backupPath + "\\temp";
                        zip.AddDirectory(driveInfo.RootDirectory.ToString());
                        zip.CompressionLevel = CompressionLevel.BestCompression;
                        zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                        var date = DateTime.Now.ToString("dd-MM-yy_hh:mm");
                        zip.Save($"{backupPath}\\{label}-{date}.zip");
                        usbInfoList[usbInfoList.IndexOf(usbInfo)] = new UsbInfoList.UsbInfo(usbInfo.BackupPath, usbInfo.VolumeLabel, usbInfo.DeviceId, date);
                        usbInfoList.Serialize();
                    }
                    notifyIcon1.ShowBalloonTip(8, "UsbBackupper", $"Backup di {usbInfo.VolumeLabel} completato", ToolTipIcon.None);
                }
                catch
                {
                    notifyIcon1.ShowBalloonTip(8, "UsbBackupper", "Backup di " + usbInfo.VolumeLabel + " fallito", ToolTipIcon.Error);
                }



            }


            StartDetector();
        }

       

        private void aggiungiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new FormAdd();
            addForm.ShowDialog();
            usbInfoList = UsbInfoList.Deserialize() ?? new UsbInfoList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Helper.CreateShortCut();
            listDrives = DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom).ToList();
            usbInfoList = UsbInfoList.Deserialize() ?? new UsbInfoList();
            StartDetector();
            foreach (var usbs in usbInfoList)
            {
                listBoxDevices.Items.Add(usbs.VolumeLabel);
            }
            linkLabelDeviceBackupPath.LinkClicked += LinkLabelDeviceBackupPath_LinkClicked;
            WindowState = FormWindowState.Minimized;

        }

        private void LinkLabelDeviceBackupPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelDeviceBackupPath.Tag.ToString());
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
            
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }
        public void StartDetector()
        {
            Task.Factory.StartNew(() =>
            {
                ManagementEventWatcher watcher = new ManagementEventWatcher();
                WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
                watcher.EventArrived += Watcher_EventArrived;
                watcher.Query = query;
                watcher.Start();
                watcher.WaitForNextEvent();
            });
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void listBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usbinfo = usbInfoList[listBoxDevices.SelectedIndex];

            labelDeviceName.Text = usbinfo.VolumeLabel;
            linkLabelDeviceBackupPath.Text = "Percorso di backup:" + usbinfo.BackupPath;
            linkLabelDeviceBackupPath.Tag = usbinfo.BackupPath;
            labelDeviceLastBackup.Text = "Ultimo backup:" + usbinfo.LastBackup;
        }
    }
}
