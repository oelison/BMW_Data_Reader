namespace BMW_Data_Reader
{
    partial class FPassword
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
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.BOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBPassword
            // 
            this.TBPassword.Location = new System.Drawing.Point(12, 12);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '#';
            this.TBPassword.Size = new System.Drawing.Size(147, 20);
            this.TBPassword.TabIndex = 0;
            this.TBPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBPassword_KeyDown);
            // 
            // BOK
            // 
            this.BOK.Location = new System.Drawing.Point(255, 12);
            this.BOK.Name = "BOK";
            this.BOK.Size = new System.Drawing.Size(75, 23);
            this.BOK.TabIndex = 1;
            this.BOK.Text = "Ok";
            this.BOK.UseVisualStyleBackColor = true;
            this.BOK.Click += new System.EventHandler(this.BOK_Click);
            // 
            // FPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 44);
            this.Controls.Add(this.BOK);
            this.Controls.Add(this.TBPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FPassword";
            this.Text = "FPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.Button BOK;
    }
}