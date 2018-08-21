using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Experimental.IO;

namespace UsbBackupper
{
    public static class Helper
    {
        public static void CreateShortCut()
        {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                var lnk = shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\UsbBackupper.lnk");
                try
                {
                    lnk.TargetPath = Application.StartupPath + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe";
                    lnk.IconLocation = "shell32.dll, 1";
                    lnk.Save();
                }
                finally
                {
                    Marshal.FinalReleaseComObject(lnk);
                }
            }
            finally
            {
                Marshal.FinalReleaseComObject(shell);
            }
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
            foreach (DirectoryInfo dir in driveFolders)
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

