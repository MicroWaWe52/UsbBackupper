using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UsbBackupper
{
    public partial class Form1 : Form
    {
        private List<DriveInfo> listDrives;
        private UsbInfoList usbInfoList;
        private bool close = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string driveLetter;
            DriveInfo driveInfo;
            string label;
            UsbInfoList.UsbInfo usbInfo;
            try
            {
                driveLetter = e.NewEvent.Properties["DriveName"].Value.ToString();
                driveInfo = listDrives.First(d => d.Name.Contains(driveLetter));
                label = driveInfo.VolumeLabel;
                usbInfo = usbInfoList.First(usb => usb.VolumeLabel == label);
                if (!File.Exists(driveLetter + "UsbBackupper.bck"))
                {
                    return;
                }
            }
            catch
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
                Backup(usbInfo.backupMode, usbInfo, driveInfo);
                /*try
                {
                    using (var zip = new ZipFile(backupPath))
                    {
                        notifyIcon1.ShowBalloonTip(8, "UsbBackupper", usbInfo.VolumeLabel + "backup in progress", ToolTipIcon.None);
                        Directory.CreateDirectory(backupPath + "\\temp");
                        zip.TempFileFolder = backupPath + "\\temp";
                        zip.AddDirectory(driveInfo.RootDirectory.ToString());
                        zip.CompressionLevel = CompressionLevel.BestCompression;
                        zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                        var date = DateTime.Now.ToString("dd-MM-yy_hh:mm");
                        zip.Save($"{backupPath}\\{label}-{date}.zip");
                        usbInfoList[usbInfoList.IndexOf(usbInfo)] = new UsbInfoList.UsbInfo(usbInfo.BackupPath, usbInfo.VolumeLabel, usbInfo.DeviceId,usbInfo.backupMode,date);
                        usbInfoList.Serialize();
                    }
                    notifyIcon1.ShowBalloonTip(8, "UsbBackupper",usbInfo.VolumeLabel+ "backup completed", ToolTipIcon.None);
                }
                catch
                {
                    notifyIcon1.ShowBalloonTip(8, "UsbBackupper", usbInfo.VolumeLabel + "backup failed", ToolTipIcon.Error);
                }*/



            }


            StartDetector();
        }

        public void Backup(UsbInfoList.UsbInfo.BackupMode backupMode, UsbInfoList.UsbInfo usbinfo, DriveInfo driveinfo)
        {
            notifyIcon1.ShowBalloonTip(8, "UsbBackupper", usbinfo.VolumeLabel + "backup in progress", ToolTipIcon.None);
            try
            {
                var date = DateTime.Now.ToString("dd-MM-yy_hh:mm");
                var driveFolders = Directory.GetDirectories(driveinfo.RootDirectory.ToString(), "*",
                    SearchOption.TopDirectoryOnly).ToList();
                driveFolders = driveFolders.Where(d => !d.Contains("System Volume Information")).ToList();
                switch (backupMode)
                {
                    case UsbInfoList.UsbInfo.BackupMode.Fast:
                        {
                            foreach (string dirPath in driveFolders)
                            {
                                Directory.CreateDirectory(dirPath.Replace(driveinfo.RootDirectory.ToString(),
                                    usbinfo.BackupPath + "\\" + driveinfo.VolumeLabel + date + "\\"));
                            }
                            usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, date);
                            usbInfoList.Serialize();
                            break;
                        }
                    case UsbInfoList.UsbInfo.BackupMode.Light:
                        {

                            foreach (string dirPath in driveFolders)
                            {
                                Directory.CreateDirectory(dirPath.Replace(driveinfo.RootDirectory.ToString(),
                                    usbinfo.BackupPath + "\\" + date + "\\"));
                            }
                            using (var zip = new ZipFile(usbinfo.BackupPath))
                            {
                                Directory.CreateDirectory(usbinfo.BackupPath + "\\temp");
                                zip.TempFileFolder = usbinfo.BackupPath + "\\temp";
                                zip.AddDirectory(usbinfo.BackupPath + $"\\{date}\\");
                                zip.CompressionLevel = CompressionLevel.BestCompression;
                                zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}.zip");
                                usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                    usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, date);
                                usbInfoList.Serialize();
                            }

                            break;
                        }
                    case UsbInfoList.UsbInfo.BackupMode.Single:
                        {
                            Directory.CreateDirectory($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}");
                            foreach (var directory in driveFolders)
                            {
                                using (var zip = new ZipFile(usbinfo.BackupPath))
                                {
                                    Directory.CreateDirectory(usbinfo.BackupPath + "\\temp");
                                    zip.TempFileFolder = usbinfo.BackupPath + "\\temp";
                                    zip.AddDirectory(directory);
                                    zip.CompressionLevel = CompressionLevel.BestCompression;
                                    zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                    zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{directory.Split('\\').Last()}.zip");
                                    usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                        usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, date);
                                    usbInfoList.Serialize();
                                }
                            }

                            break;
                        }
                    case UsbInfoList.UsbInfo.BackupMode.Complex:
                        {
                            var oldZipList = new List<string>();
                            Directory.CreateDirectory($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}");
                            foreach (var directory in driveFolders)
                            {
                                using (var zip = new ZipFile(usbinfo.BackupPath))
                                {
                                    Directory.CreateDirectory(usbinfo.BackupPath + "\\temp");
                                    zip.TempFileFolder = usbinfo.BackupPath + "\\temp";
                                    zip.AddDirectory(directory);
                                    zip.CompressionLevel = CompressionLevel.BestCompression;
                                    zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                    zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{directory.Split('\\').Last()}.zip");
                                    oldZipList.Add($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{directory.Split('\\').Last()}.zip");
                                    usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                        usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, date);
                                    usbInfoList.Serialize();
                                }
                            }
                            using (var zip = new ZipFile(usbinfo.BackupPath))
                            {
                                Directory.CreateDirectory(usbinfo.BackupPath + "\\temp");
                                zip.TempFileFolder = usbinfo.BackupPath + "\\temp";
                                zip.AddDirectory($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}");
                                zip.CompressionLevel = CompressionLevel.BestCompression;
                                zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{driveinfo.VolumeLabel}-{date}.zip");
                                usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                    usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, date);
                                usbInfoList.Serialize();
                            }

                            foreach (var oldZip in oldZipList)
                            {
                                File.Delete(oldZip);
                            }
                            break;
                        }
                }
                notifyIcon1.ShowBalloonTip(8, "UsbBackupper", usbinfo.VolumeLabel + "backup completed", ToolTipIcon.None);
            }
            catch
            {
                notifyIcon1.ShowBalloonTip(8, "UsbBackupper", usbinfo.VolumeLabel + "backup failed", ToolTipIcon.None);
            }
        }

        private void aggiungiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAdd().ShowDialog();
            usbInfoList = UsbInfoList.Deserialize() ?? new UsbInfoList();
            listBoxDevices.Items.Clear();
            foreach (var usbs in usbInfoList)
            {
                listBoxDevices.Items.Add(usbs.VolumeLabel);
            }
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
            try
            {
                Process.Start(linkLabelDeviceBackupPath.Tag.ToString());

            }
            catch
            {

            }
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
            if (listBoxDevices.SelectedIndex == -1)
            {
                labelDeviceName.Text =
                    linkLabelDeviceBackupPath.Text =
                        labelDeviceLastBackup.Text = "";
                groupBox1.Visible = false;
            }
            var usbinfo = usbInfoList[listBoxDevices.SelectedIndex];
            groupBox1.Visible = true;
            labelDeviceName.Text = usbinfo.VolumeLabel;
            linkLabelDeviceBackupPath.Text = "Backup path:" + usbinfo.BackupPath;
            linkLabelDeviceBackupPath.Tag = usbinfo.BackupPath;
            labelDeviceLastBackup.Text = "Last backup:" + usbinfo.LastBackup;
            switch (usbinfo.backupMode)
            {
                case UsbInfoList.UsbInfo.BackupMode.Light:
                    radioButtonLight.Checked = true;
                    break;
                case UsbInfoList.UsbInfo.BackupMode.Fast:
                    radioButtonFast.Checked = true;
                    break;
                case UsbInfoList.UsbInfo.BackupMode.Single:
                    radioButtonSingle.Checked = true;
                    break;
                case UsbInfoList.UsbInfo.BackupMode.Complex:
                    radioButtonComplex.Checked = true;
                    break;
            }
        }

        private void rimuoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormRemove().ShowDialog();
            usbInfoList = UsbInfoList.Deserialize() ?? new UsbInfoList();
            listBoxDevices.Items.Clear();
            foreach (var usbs in usbInfoList)
            {
                listBoxDevices.Items.Add(usbs.VolumeLabel);
            }
        }

        private void radioButtonFast_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonFast.Checked) return;
            var info = usbInfoList[listBoxDevices.SelectedIndex];
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Fast, info.LastBackup);
        }

        private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLight.Checked) return;
            var info = usbInfoList[listBoxDevices.SelectedIndex];
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Light, info.LastBackup);
        }

        private void radioButtonSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonSingle.Checked) return;
            var info = usbInfoList[listBoxDevices.SelectedIndex];
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Single, info.LastBackup);
        }

        private void radioButtonComplex_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonComplex.Checked) return;
            var info = usbInfoList[listBoxDevices.SelectedIndex];
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Complex, info.LastBackup);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close) return;
            e.Cancel = true;
            Hide();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close = true;
            Close();
        }
    }
}
