namespace BMW_Data_Reader
{
    partial class FBMWDataReader
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.BReadData = new System.Windows.Forms.Button();
            this.TBLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBVIN = new System.Windows.Forms.TextBox();
            this.BSave = new System.Windows.Forms.Button();
            this.TBDebug = new System.Windows.Forms.TextBox();
            this.BChangePath = new System.Windows.Forms.Button();
            this.LPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BReadData
            // 
            this.BReadData.Location = new System.Drawing.Point(12, 12);
            this.BReadData.Name = "BReadData";
            this.BReadData.Size = new System.Drawing.Size(131, 78);
            this.BReadData.TabIndex = 0;
            this.BReadData.Text = "Read data";
            this.BReadData.UseVisualStyleBackColor = true;
            this.BReadData.Click += new System.EventHandler(this.BReadData_Click);
            // 
            // TBLogin
            // 
            this.TBLogin.Location = new System.Drawing.Point(149, 41);
            this.TBLogin.Name = "TBLogin";
            this.TBLogin.Size = new System.Drawing.Size(136, 20);
            this.TBLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // TBPassword
            // 
            this.TBPassword.Location = new System.Drawing.Point(291, 41);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '#';
            this.TBPassword.Size = new System.Drawing.Size(136, 20);
            this.TBPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "VIN";
            // 
            // TBVIN
            // 
            this.TBVIN.Location = new System.Drawing.Point(433, 41);
            this.TBVIN.Name = "TBVIN";
            this.TBVIN.Size = new System.Drawing.Size(136, 20);
            this.TBVIN.TabIndex = 5;
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(575, 38);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(75, 23);
            this.BSave.TabIndex = 7;
            this.BSave.Text = "Save";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // TBDebug
            // 
            this.TBDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDebug.Location = new System.Drawing.Point(12, 96);
            this.TBDebug.Multiline = true;
            this.TBDebug.Name = "TBDebug";
            this.TBDebug.Size = new System.Drawing.Size(776, 342);
            this.TBDebug.TabIndex = 8;
            // 
            // BChangePath
            // 
            this.BChangePath.Location = new System.Drawing.Point(575, 67);
            this.BChangePath.Name = "BChangePath";
            this.BChangePath.Size = new System.Drawing.Size(75, 23);
            this.BChangePath.TabIndex = 10;
            this.BChangePath.Text = "Path";
            this.BChangePath.UseVisualStyleBackColor = true;
            this.BChangePath.Click += new System.EventHandler(this.BChangePath_Click);
            // 
            // LPath
            // 
            this.LPath.AutoSize = true;
            this.LPath.Location = new System.Drawing.Point(149, 72);
            this.LPath.Name = "LPath";
            this.LPath.Size = new System.Drawing.Size(22, 13);
            this.LPath.TabIndex = 11;
            this.LPath.Text = "C:\\";
            // 
            // FBMWDataReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LPath);
            this.Controls.Add(this.BChangePath);
            this.Controls.Add(this.TBDebug);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBVIN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBLogin);
            this.Controls.Add(this.BReadData);
            this.Name = "FBMWDataReader";
            this.Text = "BMW Data Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBMWDataReader_FormClosing);
            this.Load += new System.EventHandler(this.FBMWDataReader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BReadData;
        private System.Windows.Forms.TextBox TBLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBVIN;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.TextBox TBDebug;
        private System.Windows.Forms.Button BChangePath;
        private System.Windows.Forms.Label LPath;
    }
}

