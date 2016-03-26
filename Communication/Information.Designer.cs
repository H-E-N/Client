namespace Communication
{
    partial class Information
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
            this.picbIcon = new CCWin.SkinControl.SkinPictureBox();
            this.lName = new CCWin.SkinControl.SkinLabel();
            this.lData = new CCWin.SkinControl.SkinLabel();
            this.timeshow = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picbIcon
            // 
            this.picbIcon.BackColor = System.Drawing.Color.Transparent;
            this.picbIcon.Location = new System.Drawing.Point(7, 7);
            this.picbIcon.Name = "picbIcon";
            this.picbIcon.Size = new System.Drawing.Size(25, 23);
            this.picbIcon.TabIndex = 0;
            this.picbIcon.TabStop = false;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.BackColor = System.Drawing.Color.Transparent;
            this.lName.BorderColor = System.Drawing.Color.White;
            this.lName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lName.Location = new System.Drawing.Point(46, 11);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(0, 17);
            this.lName.TabIndex = 1;
            // 
            // lData
            // 
            this.lData.AutoSize = true;
            this.lData.BackColor = System.Drawing.Color.Transparent;
            this.lData.BorderColor = System.Drawing.Color.White;
            this.lData.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.lData.Location = new System.Drawing.Point(17, 52);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(0, 27);
            this.lData.TabIndex = 2;
            // 
            // timeshow
            // 
            this.timeshow.Interval = 3000;
            this.timeshow.Tick += new System.EventHandler(this.timeshow_Tick);
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 127);
            this.Controls.Add(this.lData);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.picbIcon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Information";
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.Load += new System.EventHandler(this.Information_Load);
            this.DoubleClick += new System.EventHandler(this.Information_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.picbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPictureBox picbIcon;
        private CCWin.SkinControl.SkinLabel lName;
        private CCWin.SkinControl.SkinLabel lData;
        private System.Windows.Forms.Timer timeshow;
    }
}