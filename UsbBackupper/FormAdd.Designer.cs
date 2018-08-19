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
            this.SuspendLayout();
            // 
            // buttonBackupPath
            // 
            this.buttonBackupPath.Location = new System.Drawing.Point(712, 72);
            this.buttonBackupPath.Name = "buttonBackupPath";
            this.buttonBackupPath.Size = new System.Drawing.Size(75, 23);
            this.buttonBackupPath.TabIndex = 2;
            this.buttonBackupPath.Text = "Sfoglia";
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
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleziona il dispositivo USB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seleziona il percorso del backup";
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(16, 32);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(134, 21);
            this.comboBoxDevice.TabIndex = 6;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(711, 134);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Aggiungi";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(630, 134);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Annulla";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 169);
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
    }
}