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
            catch
            {
                MessageBox.Show("Connection failed");
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            panels.Add(panelBackCloud);
            listBoxSettings.SelectedIndex = 0;
            panels[listBoxSettings.SelectedIndex].BringToFront();
            textBoxIp.Text = Settings.Default.Ip;
            textBoxUsern.Text = Settings.Default.usern;
            textBoxPassw.Text = Settings.Default.passw;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings.Default.Ip = textBoxIp.Text;
            Settings.Default.usern = textBoxUsern.Text;
            Settings.Default.passw = textBoxPassw.Text;
            Settings.Default.Save();
        }
    }
}
