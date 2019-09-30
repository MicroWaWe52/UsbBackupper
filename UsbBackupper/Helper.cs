using IWshRuntimeLibrary;
using Microsoft.Experimental.IO;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UsbBackupper
{
    public static class Helper
    {
        public static void CreateShortCut()
        {

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Backupper.lnk";
            WshShell wsh = new IWshRuntimeLibrary.WshShell();
            IWshShortcut shortcut = wsh.CreateShortcut(path) as IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = Environment.CurrentDirectory + @"\UsbBackupper.exe";
            shortcut.WindowStyle = 1;
            shortcut.Description = "backupper";
            shortcut.WorkingDirectory = Environment.CurrentDirectory + @"\";
            shortcut.Save();

        }
        public static string GetCustomDescription(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }
        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {

            var driveFolders = source.GetDirectories().ToList();
            driveFolders = driveFolders.Where(d => !d.FullName.Contains("System Volume Information")).ToList();
            foreach (var dir in driveFolders)
            {
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            }
            foreach (var file in source.GetFiles())
            {
                try
                {
                    LongPathFile.Copy(file.FullName, Path.Combine(target.FullName, file.Name), true);
                    //file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                }
                catch
                {
                    MessageBox.Show(target.FullName + "       " + file.Name);
                }
            }
        }

    }
}

