namespace UsbBackupper
{
    partial class FormAdd
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
            this.buttonBackupPath = new System.Windows.Forms.Button();
            this.textBoxBackupPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonComplex = new System.Windows.Forms.RadioButton();
            this.radioButtonSingle = new System.Windows.Forms.RadioButton();
            this.radioButtonLight = new System.Windows.Forms.RadioButton();
            this.radioButtonFast = new System.Windows.Forms.RadioButton();
            this.checkBoxBackCloud = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBackupPath
            // 
            this.buttonBackupPath.Location = new System.Drawing.Point(712, 72);
            this.buttonBackupPath.Name = "buttonBackupPath";
            this.buttonBackupPath.Size = new System.Drawing.Size(75, 23);
            this.buttonBackupPath.TabIndex = 2;
            this.buttonBackupPath.Text = "Browse";
            this.buttonBackupPath.UseVisualStyleBackColor = true;
            this.buttonBackupPath.Click += new System.EventHandler(this.buttonBackupPath_Click);
            // 
            // textBoxBackupPath
            // 
            this.textBoxBackupPath.Location = new System.Drawing.Point(12, 72);
            this.textBoxBackupPath.Name = "textBoxBackupPath";
            this.textBoxBackupPath.Size = new System.Drawing.Size(677, 20);
            this.textBoxBackupPath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select the USB drive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select the backup path";
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(12, 32);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(134, 21);
            this.comboBoxDevice.TabIndex = 6;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(711, 224);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(630, 224);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Calcel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonComplex);
            this.groupBox1.Controls.Add(this.radioButtonSingle);
            this.groupBox1.Controls.Add(this.radioButtonLight);
            this.groupBox1.Controls.Add(this.radioButtonFast);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 110);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup mode";
            // 
            // radioButtonComplex
            // 
            this.radioButtonComplex.AutoSize = true;
            this.radioButtonComplex.Location = new System.Drawing.Point(7, 87);
            this.radioButtonComplex.Name = "radioButtonComplex";
            this.radioButtonComplex.Size = new System.Drawing.Size(65, 17);
            this.radioButtonComplex.TabIndex = 3;
            this.radioButtonComplex.TabStop = true;
            this.radioButtonComplex.Text = "Complex";
            this.radioButtonComplex.UseVisualStyleBackColor = true;
            // 
            // radioButtonSingle
            // 
            this.radioButtonSingle.AutoSize = true;
            this.radioButtonSingle.Location = new System.Drawing.Point(7, 66);
            this.radioButtonSingle.Name = "radioButtonSingle";
            this.radioButtonSingle.Size = new System.Drawing.Size(86, 17);
            this.radioButtonSingle.TabIndex = 2;
            this.radioButtonSingle.TabStop = true;
            this.radioButtonSingle.Text = "Single Folder";
            this.radioButtonSingle.UseVisualStyleBackColor = true;
            // 
            // radioButtonLight
            // 
            this.radioButtonLight.AutoSize = true;
            this.radioButtonLight.Location = new System.Drawing.Point(7, 43);
            this.radioButtonLight.Name = "radioButtonLight";
            this.radioButtonLight.Size = new System.Drawing.Size(48, 17);
            this.radioButtonLight.TabIndex = 1;
            this.radioButtonLight.TabStop = true;
            this.radioButtonLight.Text = "Light";
            this.radioButtonLight.UseVisualStyleBackColor = true;
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
            // 
            // checkBoxBackCloud
            // 
            this.checkBoxBackCloud.AutoSize = true;
            this.checkBoxBackCloud.Enabled = false;
            this.checkBoxBackCloud.Location = new System.Drawing.Point(218, 119);
            this.checkBoxBackCloud.Name = "checkBoxBackCloud";
            this.checkBoxBackCloud.Size = new System.Drawing.Size(108, 17);
            this.checkBoxBackCloud.TabIndex = 10;
            this.checkBoxBackCloud.Text = "Backup on Cloud";
            this.checkBoxBackCloud.UseVisualStyleBackColor = true;
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 259);
            this.Controls.Add(this.checkBoxBackCloud);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBackupPath);
            this.Controls.Add(this.buttonBackupPath);
            this.Name = "FormAdd";
            this.Text = "Add";
            this.Load += new System.EventHandler(this.Add_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBackupPath;
        private System.Windows.Forms.TextBox textBoxBackupPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonComplex;
        private System.Windows.Forms.RadioButton radioButtonSingle;
        private System.Windows.Forms.RadioButton radioButtonLight;
        private System.Windows.Forms.RadioButton radioButtonFast;
        private System.Windows.Forms.CheckBox checkBoxBackCloud;
    }
}