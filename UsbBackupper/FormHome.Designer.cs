namespace UsbBackupper
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dispositiviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rimuoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.labelDeviceLastBackup = new System.Windows.Forms.Label();
            this.linkLabelDeviceBackupPath = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonComplex = new System.Windows.Forms.RadioButton();
            this.radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.radioButtonLight = new System.Windows.Forms.RadioButton();
            this.radioButtonFast = new System.Windows.Forms.RadioButton();
            this.buttonBackNow = new System.Windows.Forms.Button();
            this.checkBoxAutoBackup = new System.Windows.Forms.CheckBox();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispositiviToolStripMenuItem,
            this.settingsToolStripMenuItem});
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
            this.dispositiviToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.dispositiviToolStripMenuItem.Text = "Devices";
            // 
            // aggiungiToolStripMenuItem
            // 
            this.aggiungiToolStripMenuItem.Name = "aggiungiToolStripMenuItem";
            this.aggiungiToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.aggiungiToolStripMenuItem.Text = "Add";
            this.aggiungiToolStripMenuItem.Click += new System.EventHandler(this.aggiungiToolStripMenuItem_Click);
            // 
            // rimuoviToolStripMenuItem
            // 
            this.rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            this.rimuoviToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.rimuoviToolStripMenuItem.Text = "Remove";
            this.rimuoviToolStripMenuItem.Click += new System.EventHandler(this.rimuoviToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "UsbBackupper";
            this.notifyIcon1.BalloonTipTitle = "UsbBackupper";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "UsbBackupper";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonComplex);
            this.groupBox1.Controls.Add(this.radioButtonSingle);
            this.groupBox1.Controls.Add(this.radioButtonLight);
            this.groupBox1.Controls.Add(this.radioButtonFast);
            this.groupBox1.Location = new System.Drawing.Point(480, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 110);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup mode";
            this.groupBox1.Visible = false;
            // 
            // radioButtonComplex
            // 
            this.radioButtonComplex.AutoSize = true;
            this.radioButtonComplex.Location = new System.Drawing.Point(7, 87);
            this.radioButtonComplex.Name = "radioButtonComplex";
            this.radioButtonComplex.Size = new System.Drawing.Size(65, 17);
            this.radioButtonComplex.TabIndex = 3;
            this.radioButtonComplex.Text = "Complex";
            this.radioButtonComplex.UseVisualStyleBackColor = true;
            this.radioButtonComplex.CheckedChanged += new System.EventHandler(this.radioButtonComplex_CheckedChanged);
            // 
            // radioButtonSingle
            // 
            this.radioButtonSingle.AutoSize = true;
            this.radioButtonSingle.Location = new System.Drawing.Point(7, 66);
            this.radioButtonSingle.Name = "radioButtonSingle";
            this.radioButtonSingle.Size = new System.Drawing.Size(86, 17);
            this.radioButtonSingle.TabIndex = 2;
            this.radioButtonSingle.Text = "Single Folder";
            this.radioButtonSingle.UseVisualStyleBackColor = true;
            this.radioButtonSingle.CheckedChanged += new System.EventHandler(this.radioButtonSingle_CheckedChanged);
            // 
            // radioButtonLight
            // 
            this.radioButtonLight.AutoSize = true;
            this.radioButtonLight.Location = new System.Drawing.Point(7, 43);
            this.radioButtonLight.Name = "radioButtonLight";
            this.radioButtonLight.Size = new System.Drawing.Size(48, 17);
            this.radioButtonLight.TabIndex = 1;
            this.radioButtonLight.Text = "Light";
            this.radioButtonLight.UseVisualStyleBackColor = true;
            this.radioButtonLight.CheckedChanged += new System.EventHandler(this.radioButtonLight_CheckedChanged);
            // 
            // radioButtonFast
            // 
            this.radioButtonFast.AutoSize = true;
            this.radioButtonFast.Checked = true;
            this.radioButtonFast.Location = new System.Drawing.Point(7, 20);
            this.radioButtonFast.Name = "radioButtonFast";
            this.radioButtonFast.Size = new System.Drawing.Size(45, 17);
            this.radioButtonFast.TabIndex = 0;
            this.radioButtonFast.TabStop = true;
            this.radioButtonFast.Text = "Fast";
            this.radioButtonFast.UseVisualStyleBackColor = true;
            this.radioButtonFast.CheckedChanged += new System.EventHandler(this.radioButtonFast_CheckedChanged);
            // 
            // buttonBackNow
            // 
            this.buttonBackNow.Location = new System.Drawing.Point(480, 363);
            this.buttonBackNow.Name = "buttonBackNow";
            this.buttonBackNow.Size = new System.Drawing.Size(200, 45);
            this.buttonBackNow.TabIndex = 11;
            this.buttonBackNow.Text = "Backup Now";
            this.buttonBackNow.UseVisualStyleBackColor = true;
            this.buttonBackNow.Visible = false;
            this.buttonBackNow.Click += new System.EventHandler(this.buttonBackNow_Click);
            // 
            // checkBoxAutoBackup
            // 
            this.checkBoxAutoBackup.AutoSize = true;
            this.checkBoxAutoBackup.Location = new System.Drawing.Point(487, 223);
            this.checkBoxAutoBackup.Name = "checkBoxAutoBackup";
            this.checkBoxAutoBackup.Size = new System.Drawing.Size(85, 17);
            this.checkBoxAutoBackup.TabIndex = 12;
            this.checkBoxAutoBackup.Text = "AutoBackup";
            this.checkBoxAutoBackup.UseVisualStyleBackColor = true;
            this.checkBoxAutoBackup.Visible = false;
            this.checkBoxAutoBackup.CheckedChanged += new System.EventHandler(this.checkBoxAutoBackup_CheckedChanged);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxAutoBackup);
            this.Controls.Add(this.buttonBackNow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabelDeviceBackupPath);
            this.Controls.Add(this.labelDeviceLastBackup);
            this.Controls.Add(this.labelDeviceName);
            this.Controls.Add(this.listBoxDevices);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonComplex;
        private System.Windows.Forms.RadioButton radioButtonSingle;
        private System.Windows.Forms.RadioButton radioButtonLight;
        private System.Windows.Forms.RadioButton radioButtonFast;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonBackNow;
        private System.Windows.Forms.CheckBox checkBoxAutoBackup;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

