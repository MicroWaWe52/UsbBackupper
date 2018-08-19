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

namespace UsbBackupper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            watcher.EventArrived += Watcher_EventArrived;
            watcher.Query = query;
            watcher.Start();
            watcher.WaitForNextEvent();
        }

        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            

        }

        private void aggiungiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addForm=new FormAdd();
            addForm.ShowDialog();
        }
    }
}
