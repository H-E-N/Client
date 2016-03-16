namespace Communication
{
    partial class Directory
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnOutLogin = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(308, 24);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnOutLogin
            // 
            this.btnOutLogin.Location = new System.Drawing.Point(525, 24);
            this.btnOutLogin.Name = "btnOutLogin";
            this.btnOutLogin.Size = new System.Drawing.Size(75, 23);
            this.btnOutLogin.TabIndex = 2;
            this.btnOutLogin.Text = "注销";
            this.btnOutLogin.UseVisualStyleBackColor = true;
            // 
            // lbName
            // 
            this.lbName.FormattingEnabled = true;
            this.lbName.ItemHeight = 12;
            this.lbName.Location = new System.Drawing.Point(29, 81);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(617, 220);
            this.lbName.TabIndex = 3;
            // 
            // Directory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 338);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnOutLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtName);
            this.Name = "Directory";
            this.Text = "Directory";
            this.Load += new System.EventHandler(this.Directory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnOutLogin;
        private System.Windows.Forms.ListBox lbName;
    }
}