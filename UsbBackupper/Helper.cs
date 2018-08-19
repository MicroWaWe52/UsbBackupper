using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsbBackupper
{
    public class Helper
    {
        public static void CreateShortCut()
        {
            Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
            dynamic shell = Activator.CreateInstance(t);
            try
            {
                var lnk = shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup)+"UsbBackupper.lnk");
                try
                {
                    lnk.TargetPath = Application.StartupPath+"\\"+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Name+".exe";
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
    }
}

