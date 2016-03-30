namespace Communication
{
    partial class Setting
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
            this.components = new System.ComponentModel.Container();
            this.pictureIcon = new CCWin.SkinControl.SkinPictureBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.txtName = new CCWin.SkinControl.SkinTextBox();
            this.txtSignature = new CCWin.SkinControl.SkinTextBox();
            this.btnPicture = new CCWin.SkinControl.SkinButton();
            this.btnSubmit = new CCWin.SkinControl.SkinButton();
            this.btnCannel = new CCWin.SkinControl.SkinButton();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureIcon
            // 
            this.pictureIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureIcon.Location = new System.Drawing.Point(17, 64);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(87, 83);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureIcon.TabIndex = 0;
            this.pictureIcon.TabStop = false;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.skinLabel1.Location = new System.Drawing.Point(116, 67);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(75, 20);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "昵      称：";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.skinLabel2.Location = new System.Drawing.Point(116, 138);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(79, 20);
            this.skinLabel2.TabIndex = 2;
            this.skinLabel2.Text = "个性签名：";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.DownBack = null;
            this.txtName.Icon = null;
            this.txtName.IconIsButton = false;
            this.txtName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtName.IsPasswordChat = '\0';
            this.txtName.IsSystemPasswordChar = false;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(188, 62);
            this.txtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtName.MaxLength = 32767;
            this.txtName.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtName.MouseBack = null;
            this.txtName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.NormlBack = null;
            this.txtName.Padding = new System.Windows.Forms.Padding(5);
            this.txtName.ReadOnly = false;
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.Size = new System.Drawing.Size(134, 28);
            // 
            // 
            // 
            this.txtName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtName.SkinTxt.Name = "BaseText";
            this.txtName.SkinTxt.Size = new System.Drawing.Size(124, 18);
            this.txtName.SkinTxt.TabIndex = 0;
            this.txtName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtName.SkinTxt.WaterText = "";
            this.txtName.TabIndex = 3;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtName.WaterText = "";
            this.txtName.WordWrap = true;
            // 
            // txtSignature
            // 
            this.txtSignature.BackColor = System.Drawing.Color.Transparent;
            this.txtSignature.DownBack = null;
            this.txtSignature.Icon = null;
            this.txtSignature.IconIsButton = false;
            this.txtSignature.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSignature.IsPasswordChat = '\0';
            this.txtSignature.IsSystemPasswordChar = false;
            this.txtSignature.Lines = new string[0];
            this.txtSignature.Location = new System.Drawing.Point(188, 132);
            this.txtSignature.Margin = new System.Windows.Forms.Padding(0);
            this.txtSignature.MaxLength = 32767;
            this.txtSignature.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSignature.MouseBack = null;
            this.txtSignature.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSignature.Multiline = false;
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.NormlBack = null;
            this.txtSignature.Padding = new System.Windows.Forms.Padding(5);
            this.txtSignature.ReadOnly = false;
            this.txtSignature.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSignature.Size = new System.Drawing.Size(134, 28);
            // 
            // 
            // 
            this.txtSignature.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSignature.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSignature.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSignature.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSignature.SkinTxt.Name = "BaseText";
            this.txtSignature.SkinTxt.Size = new System.Drawing.Size(124, 18);
            this.txtSignature.SkinTxt.TabIndex = 0;
            this.txtSignature.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSignature.SkinTxt.WaterText = "";
            this.txtSignature.TabIndex = 4;
            this.txtSignature.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSignature.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSignature.WaterText = "";
            this.txtSignature.WordWrap = true;
            // 
            // btnPicture
            // 
            this.btnPicture.BackColor = System.Drawing.Color.Transparent;
            this.btnPicture.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPicture.DownBack = null;
            this.btnPicture.Location = new System.Drawing.Point(21, 165);
            this.btnPicture.MouseBack = null;
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.NormlBack = null;
            this.btnPicture.Size = new System.Drawing.Size(75, 23);
            this.btnPicture.TabIndex = 5;
            this.btnPicture.Text = "头像设置";
            this.btnPicture.UseVisualStyleBackColor = false;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSubmit.DownBack = null;
            this.btnSubmit.Location = new System.Drawing.Point(80, 206);
            this.btnSubmit.MouseBack = null;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.NormlBack = null;
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCannel
            // 
            this.btnCannel.BackColor = System.Drawing.Color.Transparent;
            this.btnCannel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCannel.DownBack = null;
            this.btnCannel.Location = new System.Drawing.Point(198, 206);
            this.btnCannel.MouseBack = null;
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.NormlBack = null;
            this.btnCannel.Size = new System.Drawing.Size(75, 23);
            this.btnCannel.TabIndex = 7;
            this.btnCannel.Text = "取消";
            this.btnCannel.UseVisualStyleBackColor = false;
            this.btnCannel.Click += new System.EventHandler(this.btnCannel_Click);
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.skinLabel3.Location = new System.Drawing.Point(133, 16);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(92, 27);
            this.skinLabel3.TabIndex = 8;
            this.skinLabel3.Text = "个人设置";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 252);
            this.ControlBox = false;
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.btnCannel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.txtSignature);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.pictureIcon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Load += new System.EventHandler(this.Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPictureBox pictureIcon;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinTextBox txtName;
        private CCWin.SkinControl.SkinTextBox txtSignature;
        private CCWin.SkinControl.SkinButton btnPicture;
        private CCWin.SkinControl.SkinButton btnSubmit;
        private CCWin.SkinControl.SkinButton btnCannel;
        private CCWin.SkinControl.SkinLabel skinLabel3;
    }
}