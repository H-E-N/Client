namespace Communication
{
    partial class Countenance
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Demo = new System.Windows.Forms.PictureBox();
            this.ImageMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Demo)).BeginInit();
            this.ImageMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Demo
            // 
            this.Demo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Demo.Location = new System.Drawing.Point(5, 5);
            this.Demo.Name = "Demo";
            this.Demo.Size = new System.Drawing.Size(72, 72);
            this.Demo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Demo.TabIndex = 0;
            this.Demo.TabStop = false;
            // 
            // ImageMenu
            // 
            this.ImageMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddItem,
            this.DeleteItem});
            this.ImageMenu.Name = "ImageMenu";
            this.ImageMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // AddItem
            // 
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(152, 22);
            this.AddItem.Text = "增加(&A)";
            // 
            // DeleteItem
            // 
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(117, 22);
            this.DeleteItem.Text = "删除(&D)";
            // 
            // Countenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 318);
            this.ControlBox = false;
            this.Controls.Add(this.Demo);
            this.Name = "Countenance";
            this.ShowDrawIcon = false;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.Demo)).EndInit();
            this.ImageMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Demo;
        private System.Windows.Forms.ContextMenuStrip ImageMenu;
        private System.Windows.Forms.ToolStripMenuItem AddItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteItem;


    }
}
