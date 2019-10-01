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
using UsbBackupper.Properties;

namespace UsbBackupper
{
    public partial class FormHome : Form
    {
        private List<DriveInfo> listDrives;
        private UsbInfoList usbInfoList;
        private bool close;
        private int usbIndex;
        public FormHome()
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
                listDrives = DriveInfo.GetDrives().Where(drive => drive.DriveType != DriveType.CDRom).ToList();
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

            if (id != usbInfo.DeviceId.ToString() && usbInfo.CanAutoBackup) return;
            {
                if (usbInfo.CanAutoBackup)
                {
                    Backup(usbInfo.backupMode, usbInfo, driveInfo);

                }
            }


            StartDetector();
        }

        public void Backup(UsbInfoList.UsbInfo.BackupMode backupMode, UsbInfoList.UsbInfo usbinfo, DriveInfo driveinfo)
        {
            notifyIcon1.ShowBalloonTip(8, "UsbBackupper", usbinfo.VolumeLabel + " backup in progress", ToolTipIcon.None);
            try
            {
                var date = DateTime.Now.ToString("dd-MM-yy_hh_mm");
                var driveFolders = Directory.GetDirectories(driveinfo.RootDirectory.ToString()).ToList();
                var driveFile = Directory.GetFiles(driveinfo.RootDirectory.ToString(), "*",
                    SearchOption.TopDirectoryOnly);
                driveFolders = driveFolders.Where(d => !d.Contains("System Volume Information")).ToList();
                var backupPathNow = usbinfo.BackupPath + $"\\{driveinfo.VolumeLabel}-{date}";

                Task.Run(() =>
                {
                    if (!usbinfo.BackOnCloud) return;
                    ftpClient = new Ftp(Settings.Default.Ip, Settings.Default.Usern, Settings.Default.Passw);
                    ftpClient.CreateDirectory($"{backupPathNow.Split('\\').Last().Replace(':', '_')}");
                    Upload(driveinfo.RootDirectory.ToString(), Settings.Default.Ip + $"/{backupPathNow.Split('\\').Last().Replace(':', '_')}");
                });
                switch (backupMode)
                {
                    case UsbInfoList.UsbInfo.BackupMode.Fast:
                        {
                            var path = usbinfo.BackupPath + $"\\{driveinfo.VolumeLabel}-{date}";
                            Directory.CreateDirectory(usbinfo.BackupPath + $"\\{driveinfo.VolumeLabel}-{date}");
                            Helper.CopyFilesRecursively(new DirectoryInfo(driveinfo.RootDirectory.ToString()),
                                new DirectoryInfo(usbinfo.BackupPath + $"\\{driveinfo.VolumeLabel}-{date}"));
                            usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, usbinfo.BackOnCloud, date);
                            usbInfoList.Serialize();
                            break;
                        }
                    case UsbInfoList.UsbInfo.BackupMode.Light:
                        {

                            Directory.CreateDirectory(usbinfo.BackupPath + $"\\{driveinfo.VolumeLabel}-{date}");
                            Helper.CopyFilesRecursively(new DirectoryInfo(driveinfo.RootDirectory.ToString()),
                                new DirectoryInfo(usbinfo.BackupPath + $"\\{driveinfo.VolumeLabel}-{date}"));
                            using (var zip = new ZipFile(usbinfo.BackupPath))
                            {
                                Directory.CreateDirectory(usbinfo.BackupPath + "\\temp");
                                zip.TempFileFolder = usbinfo.BackupPath + "\\temp";
                                zip.AddDirectory(usbinfo.BackupPath + $"\\{driveinfo.VolumeLabel}-{date}\\");
                                zip.CompressionLevel = CompressionLevel.BestCompression;
                                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                                zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{driveinfo.VolumeLabel}-{date}.zip");
                                usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                    usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, usbinfo.BackOnCloud, date);
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
                                    zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                                    zip.CompressionLevel = CompressionLevel.BestCompression;
                                    zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                    zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{directory.Split('\\').Last()}.zip");
                                    usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                        usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, usbinfo.BackOnCloud, date);
                                    usbInfoList.Serialize();
                                }
                            }
                            using (var zip = new ZipFile(usbinfo.BackupPath))
                            {
                                zip.TempFileFolder = usbinfo.BackupPath + "\\temp";
                                zip.AddFiles(driveFile);
                                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                                zip.CompressionLevel = CompressionLevel.BestCompression;
                                zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\SpreadFiles.zip");
                                usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                    usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, usbinfo.BackOnCloud, date);
                                usbInfoList.Serialize();
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
                                    zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                                    zip.CompressionLevel = CompressionLevel.BestCompression;
                                    zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                    zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{directory.Split('\\').Last()}.zip");
                                    oldZipList.Add($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{directory.Split('\\').Last()}.zip");
                                    usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                        usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, usbinfo.BackOnCloud, date);
                                    usbInfoList.Serialize();
                                }
                            }
                            using (var zip = new ZipFile(usbinfo.BackupPath))
                            {
                                zip.TempFileFolder = usbinfo.BackupPath + "\\temp";
                                zip.AddFiles(driveFile);
                                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                                zip.CompressionLevel = CompressionLevel.BestCompression;
                                zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\SpreadFiles.zip");
                                oldZipList.Add($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\SpreadFiles.zip");
                                usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                    usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, usbinfo.BackOnCloud, date);
                                usbInfoList.Serialize();
                            }
                            using (var zip = new ZipFile(usbinfo.BackupPath))
                            {
                                Directory.CreateDirectory(usbinfo.BackupPath + "\\temp");
                                zip.TempFileFolder = usbinfo.BackupPath + "\\temp";
                                zip.AddDirectory($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}");
                                zip.CompressionLevel = CompressionLevel.BestCompression;
                                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                                zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                                zip.Save($"{usbinfo.BackupPath}\\{driveinfo.VolumeLabel}-{date}\\{driveinfo.VolumeLabel}-{date}.zip");
                                usbInfoList[usbInfoList.IndexOf(usbinfo)] = new UsbInfoList.UsbInfo(usbinfo.BackupPath,
                                    usbinfo.VolumeLabel, usbinfo.DeviceId, usbinfo.backupMode, usbinfo.BackOnCloud, date);
                                usbInfoList.Serialize();
                            }

                            foreach (var oldZip in oldZipList)
                            {
                                File.Delete(oldZip);
                            }
                            break;
                        }

                }
                notifyIcon1.ShowBalloonTip(8, "UsbBackupper", usbinfo.VolumeLabel + " backup completed", ToolTipIcon.None);

            }
            catch (Exception e)
            {
                notifyIcon1.ShowBalloonTip(8, "UsbBackupper", usbinfo.VolumeLabel + " backup failed\n" + e.Message, ToolTipIcon.Error);
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
                // ignored
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

        private Ftp ftpClient;
        public void Upload(string dirPath, string uploadPath)
        {
            var files = Directory.GetFiles(dirPath, "*.*");
            var subDirs = Directory.GetDirectories(dirPath);

            foreach (var file in files)
            {
                ftpClient.Upload(uploadPath + "/" + Path.GetFileName(file), file);
            }

            foreach (var subDir in subDirs)
            {
                ftpClient.CreateDirectoryUpload(uploadPath + "/" + Path.GetFileName(subDir));
                Upload(subDir, uploadPath + "/" + Path.GetFileName(subDir));
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void listBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDevices.SelectedIndex == -1)
            {
                labelDeviceName.Text =
                    linkLabelDeviceBackupPath.Text =
                        labelDeviceLastBackup.Text = "";
                groupBox1.Visible = false;
                buttonBackNow.Visible = false;
                checkBoxAutoBackup.Visible = false;
            }
            else
            {
                var usbinfo = usbInfoList[listBoxDevices.SelectedIndex];
                groupBox1.Visible = true;
                buttonBackNow.Visible = true;
                checkBoxAutoBackup.Visible = true;
                checkBoxAutoBackup.Checked = usbinfo.CanAutoBackup;
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

                var drivePresent = DriveInfo.GetDrives().Where(d => d.DriveType != DriveType.CDRom).Any(drive => drive.VolumeLabel == usbinfo.VolumeLabel);

                buttonBackNow.Enabled = drivePresent;
            }

            usbIndex = listBoxDevices.SelectedIndex;
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
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Fast, info.BackOnCloud, info.LastBackup);
        }

        private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLight.Checked) return;
            var info = usbInfoList[listBoxDevices.SelectedIndex];
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Light, info.BackOnCloud, info.LastBackup);
        }

        private void radioButtonSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonSingle.Checked) return;
            var info = usbInfoList[listBoxDevices.SelectedIndex];
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Single, info.BackOnCloud, info.LastBackup);
        }

        private void radioButtonComplex_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonComplex.Checked) return;
            var info = usbInfoList[listBoxDevices.SelectedIndex];
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Complex, info.BackOnCloud, info.LastBackup);
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

        private void checkBoxAutoBackup_CheckedChanged(object sender, EventArgs e)
        {
            var info = usbInfoList[listBoxDevices.SelectedIndex];
            usbInfoList[listBoxDevices.SelectedIndex] = new UsbInfoList.UsbInfo(info.BackupPath, info.VolumeLabel, info.DeviceId, UsbInfoList.UsbInfo.BackupMode.Complex, info.BackOnCloud, info.LastBackup, checkBoxAutoBackup.Checked);
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            try
            {
                Process.Start(linkLabelDeviceBackupPath.Tag.ToString());

            }
            catch
            {
                // ignored
            }
        }

        private void buttonBackNow_Click(object sender, EventArgs e)
        {
            var info = usbInfoList[usbIndex];
            var drive = listDrives.First(d => d.VolumeLabel == info.VolumeLabel);
            Task.Factory.StartNew(() =>
            {
                Backup(info.backupMode, info, drive);
            });
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSettings().ShowDialog();
        }
    }
}
