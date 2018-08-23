namespace UsbBackupper
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxSettings = new System.Windows.Forms.ListBox();
            this.panelBackCloud = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.textBoxPassw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUsern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBackCloud.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxSettings
            // 
            this.listBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxSettings.FormattingEnabled = true;
            this.listBoxSettings.Items.AddRange(new object[] {
            "Backup in cloud"});
            this.listBoxSettings.Location = new System.Drawing.Point(13, 13);
            this.listBoxSettings.Name = "listBoxSettings";
            this.listBoxSettings.Size = new System.Drawing.Size(129, 251);
            this.listBoxSettings.Sorted = true;
            this.listBoxSettings.TabIndex = 0;
            // 
            // panelBackCloud
            // 
            this.panelBackCloud.Controls.Add(this.buttonSave);
            this.panelBackCloud.Controls.Add(this.buttonTest);
            this.panelBackCloud.Controls.Add(this.textBoxPassw);
            this.panelBackCloud.Controls.Add(this.label3);
            this.panelBackCloud.Controls.Add(this.textBoxUsern);
            this.panelBackCloud.Controls.Add(this.label2);
            this.panelBackCloud.Controls.Add(this.textBoxIp);
            this.panelBackCloud.Controls.Add(this.label1);
            this.panelBackCloud.Location = new System.Drawing.Point(149, 13);
            this.panelBackCloud.Name = "panelBackCloud";
            this.panelBackCloud.Size = new System.Drawing.Size(514, 251);
            this.panelBackCloud.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(436, 225);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(6, 136);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(112, 23);
            this.buttonTest.TabIndex = 6;
            this.buttonTest.Text = "Connect and setup";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // textBoxPassw
            // 
            this.textBoxPassw.Location = new System.Drawing.Point(6, 110);
            this.textBoxPassw.Name = "textBoxPassw";
            this.textBoxPassw.Size = new System.Drawing.Size(112, 20);
            this.textBoxPassw.TabIndex = 5;
            this.textBoxPassw.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // textBoxUsern
            // 
            this.textBoxUsern.Location = new System.Drawing.Point(6, 71);
            this.textBoxUsern.Name = "textBoxUsern";
            this.textBoxUsern.Size = new System.Drawing.Size(112, 20);
            this.textBoxUsern.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username:";
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(6, 33);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(112, 20);
            this.textBoxIp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 287);
            this.Controls.Add(this.panelBackCloud);
            this.Controls.Add(this.listBoxSettings);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.panelBackCloud.ResumeLayout(false);
            this.panelBackCloud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSettings;
        private System.Windows.Forms.Panel panelBackCloud;
        private System.Windows.Forms.TextBox textBoxPassw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUsern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonTest;
    }
}