using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using UsbBackupper.Properties;

namespace UsbBackupper
{
    public partial class FormSettings : Form
    {
        List<Panel> panels = new List<Panel>();
        public FormSettings()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(new Uri(textBoxIp.Text + "/UsbBackupper"));
                request.Credentials = new NetworkCredential(textBoxUsern.Text, textBoxPassw.Text);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;

                request.GetResponse();
                MessageBox.Show("Successful connection and setup ");
            }
            catch (Exception exx)
            {
                MessageBox.Show("Connection failed \nIf \"UsbBackupper\" path is present on the server, try to delete it");
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            panels.Add(panelBackCloud);
            listBoxSettings.SelectedIndex = 0;
            panels[listBoxSettings.SelectedIndex].BringToFront();
            textBoxIp.Text = Settings.Default.Ip;
            textBoxUsern.Text = Settings.Default.Usern;
            textBoxPassw.Text = Settings.Default.Passw;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings.Default.Ip = textBoxIp.Text+ "/UsbBackupper";
            Settings.Default.Usern = textBoxUsern.Text;
            Settings.Default.Passw = textBoxPassw.Text;
            Settings.Default.Save();
        }
    }
}
