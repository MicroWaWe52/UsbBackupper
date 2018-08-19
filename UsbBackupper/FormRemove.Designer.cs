namespace UsbBackupper
{
    partial class FormRemove
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRemove = new System.Windows.Forms.ComboBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.checkBoxRemoveDelete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleziona il dispositivo da rimuovere";
            // 
            // comboBoxRemove
            // 
            this.comboBoxRemove.FormattingEnabled = true;
            this.comboBoxRemove.Location = new System.Drawing.Point(47, 31);
            this.comboBoxRemove.Name = "comboBoxRemove";
            this.comboBoxRemove.Size = new System.Drawing.Size(173, 21);
            this.comboBoxRemove.TabIndex = 1;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(97, 87);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Rimuovi";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // checkBoxRemoveDelete
            // 
            this.checkBoxRemoveDelete.AutoSize = true;
            this.checkBoxRemoveDelete.Location = new System.Drawing.Point(65, 64);
            this.checkBoxRemoveDelete.Name = "checkBoxRemoveDelete";
            this.checkBoxRemoveDelete.Size = new System.Drawing.Size(131, 17);
            this.checkBoxRemoveDelete.TabIndex = 3;
            this.checkBoxRemoveDelete.Text = "Cancella tutti i backup";
            this.checkBoxRemoveDelete.UseVisualStyleBackColor = true;
            // 
            // FormRemove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 125);
            this.Controls.Add(this.checkBoxRemoveDelete);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.comboBoxRemove);
            this.Controls.Add(this.label1);
            this.Name = "FormRemove";
            this.Text = "Rimuovi";
            this.Load += new System.EventHandler(this.FormRemove_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRemove;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.CheckBox checkBoxRemoveDelete;
    }
}