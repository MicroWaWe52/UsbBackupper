namespace UsbBackupper
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dispositiviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.labelDeviceLastBackup = new System.Windows.Forms.Label();
            this.linkLabelDeviceBackupPath = new System.Windows.Forms.LinkLabel();
            this.rimuoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispositiviToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dispositiviToolStripMenuItem
            // 
            this.dispositiviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aggiungiToolStripMenuItem,
            this.rimuoviToolStripMenuItem});
            this.dispositiviToolStripMenuItem.Name = "dispositiviToolStripMenuItem";
            this.dispositiviToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.dispositiviToolStripMenuItem.Text = "Dispositivi";
            // 
            // aggiungiToolStripMenuItem
            // 
            this.aggiungiToolStripMenuItem.Name = "aggiungiToolStripMenuItem";
            this.aggiungiToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.aggiungiToolStripMenuItem.Text = "Aggiungi";
            this.aggiungiToolStripMenuItem.Click += new System.EventHandler(this.aggiungiToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "UsbBackupper";
            this.notifyIcon1.BalloonTipTitle = "UsbBackupper";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "UsbBackupper";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.Location = new System.Drawing.Point(12, 27);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.Size = new System.Drawing.Size(120, 381);
            this.listBoxDevices.TabIndex = 2;
            this.listBoxDevices.SelectedIndexChanged += new System.EventHandler(this.listBoxDevices_SelectedIndexChanged);
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeviceName.Location = new System.Drawing.Point(522, 28);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(0, 24);
            this.labelDeviceName.TabIndex = 3;
            // 
            // labelDeviceLastBackup
            // 
            this.labelDeviceLastBackup.AutoSize = true;
            this.labelDeviceLastBackup.Location = new System.Drawing.Point(477, 125);
            this.labelDeviceLastBackup.Name = "labelDeviceLastBackup";
            this.labelDeviceLastBackup.Size = new System.Drawing.Size(0, 13);
            this.labelDeviceLastBackup.TabIndex = 5;
            // 
            // linkLabelDeviceBackupPath
            // 
            this.linkLabelDeviceBackupPath.AutoSize = true;
            this.linkLabelDeviceBackupPath.Location = new System.Drawing.Point(477, 93);
            this.linkLabelDeviceBackupPath.Name = "linkLabelDeviceBackupPath";
            this.linkLabelDeviceBackupPath.Size = new System.Drawing.Size(0, 13);
            this.linkLabelDeviceBackupPath.TabIndex = 6;
            // 
            // rimuoviToolStripMenuItem
            // 
            this.rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            this.rimuoviToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rimuoviToolStripMenuItem.Text = "Rimuovi";
            this.rimuoviToolStripMenuItem.Click += new System.EventHandler(this.rimuoviToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabelDeviceBackupPath);
            this.Controls.Add(this.labelDeviceLastBackup);
            this.Controls.Add(this.labelDeviceName);
            this.Controls.Add(this.listBoxDevices);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dispositiviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aggiungiToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListBox listBoxDevices;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.Label labelDeviceLastBackup;
        private System.Windows.Forms.LinkLabel linkLabelDeviceBackupPath;
        private System.Windows.Forms.ToolStripMenuItem rimuoviToolStripMenuItem;
    }
}

