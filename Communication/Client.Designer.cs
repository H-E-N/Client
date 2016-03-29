namespace Communication
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.panel2 = new System.Windows.Forms.Panel();
            this.TabClient = new CCWin.SkinControl.SkinTabControl();
            this.tabContacts = new CCWin.SkinControl.SkinTabPage();
            this.chatshow = new CCWin.SkinControl.ChatListBox();
            this.rightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.头像显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大头像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小头像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新联系人ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabGroup = new CCWin.SkinControl.SkinTabPage();
            this.lName = new System.Windows.Forms.Label();
            this.lIP = new System.Windows.Forms.Label();
            this.btnSet = new CCWin.SkinControl.SkinButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lSignature = new System.Windows.Forms.Label();
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            this.minIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.minMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TipSignature = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.TabClient.SuspendLayout();
            this.tabContacts.SuspendLayout();
            this.rightMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.minMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TabClient);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(4, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 436);
            this.panel2.TabIndex = 1;
            // 
            // TabClient
            // 
            this.TabClient.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.TabClient.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.TabClient.Controls.Add(this.tabContacts);
            this.TabClient.Controls.Add(this.tabGroup);
            this.TabClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabClient.HeadBack = null;
            this.TabClient.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.TabClient.ItemSize = new System.Drawing.Size(70, 36);
            this.TabClient.Location = new System.Drawing.Point(0, 0);
            this.TabClient.Name = "TabClient";
            this.TabClient.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("TabClient.PageArrowDown")));
            this.TabClient.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("TabClient.PageArrowHover")));
            this.TabClient.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("TabClient.PageCloseHover")));
            this.TabClient.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("TabClient.PageCloseNormal")));
            this.TabClient.PageDown = ((System.Drawing.Image)(resources.GetObject("TabClient.PageDown")));
            this.TabClient.PageHover = ((System.Drawing.Image)(resources.GetObject("TabClient.PageHover")));
            this.TabClient.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.TabClient.PageNorml = null;
            this.TabClient.SelectedIndex = 0;
            this.TabClient.Size = new System.Drawing.Size(283, 436);
            this.TabClient.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabClient.TabIndex = 1;
            // 
            // tabContacts
            // 
            this.tabContacts.BackColor = System.Drawing.Color.White;
            this.tabContacts.Controls.Add(this.chatshow);
            this.tabContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContacts.Location = new System.Drawing.Point(0, 36);
            this.tabContacts.Name = "tabContacts";
            this.tabContacts.Size = new System.Drawing.Size(283, 400);
            this.tabContacts.TabIndex = 0;
            this.tabContacts.TabItemImage = null;
            this.tabContacts.Text = "联系人";
            // 
            // chatshow
            // 
            this.chatshow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chatshow.ContextMenuStrip = this.rightMenu;
            this.chatshow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatshow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatshow.ForeColor = System.Drawing.Color.Black;
            this.chatshow.FriendsMobile = true;
            this.chatshow.ListSubItemMenu = null;
            this.chatshow.Location = new System.Drawing.Point(0, 0);
            this.chatshow.Name = "chatshow";
            this.chatshow.SelectSubItem = null;
            this.chatshow.Size = new System.Drawing.Size(283, 400);
            this.chatshow.SubItemMenu = null;
            this.chatshow.TabIndex = 0;
            this.chatshow.Text = "chatListBox1";
            this.chatshow.DoubleClickSubItem += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.chatshow_DoubleClickSubItem);
            // 
            // rightMenu
            // 
            this.rightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.头像显示ToolStripMenuItem,
            this.刷新联系人ToolStripMenuItem});
            this.rightMenu.Name = "rightMenu";
            this.rightMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // 头像显示ToolStripMenuItem
            // 
            this.头像显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大头像ToolStripMenuItem,
            this.小头像ToolStripMenuItem});
            this.头像显示ToolStripMenuItem.Name = "头像显示ToolStripMenuItem";
            this.头像显示ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.头像显示ToolStripMenuItem.Text = "头像显示";
            // 
            // 大头像ToolStripMenuItem
            // 
            this.大头像ToolStripMenuItem.Image = global::Communication.Properties.Resources.menu_check;
            this.大头像ToolStripMenuItem.Name = "大头像ToolStripMenuItem";
            this.大头像ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.大头像ToolStripMenuItem.Text = "大头像";
            // 
            // 小头像ToolStripMenuItem
            // 
            this.小头像ToolStripMenuItem.Name = "小头像ToolStripMenuItem";
            this.小头像ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.小头像ToolStripMenuItem.Text = "小头像";
            // 
            // 刷新联系人ToolStripMenuItem
            // 
            this.刷新联系人ToolStripMenuItem.Name = "刷新联系人ToolStripMenuItem";
            this.刷新联系人ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.刷新联系人ToolStripMenuItem.Text = "刷新好友列表";
            // 
            // tabGroup
            // 
            this.tabGroup.BackColor = System.Drawing.Color.White;
            this.tabGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGroup.Location = new System.Drawing.Point(0, 36);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Size = new System.Drawing.Size(249, 400);
            this.tabGroup.TabIndex = 1;
            this.tabGroup.TabItemImage = null;
            this.tabGroup.Text = "群组";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("宋体", 15F);
            this.lName.Location = new System.Drawing.Point(102, 25);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(0, 20);
            this.lName.TabIndex = 1;
            this.lName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lIP
            // 
            this.lIP.AutoSize = true;
            this.lIP.Location = new System.Drawing.Point(104, 54);
            this.lIP.Name = "lIP";
            this.lIP.Size = new System.Drawing.Size(0, 12);
            this.lIP.TabIndex = 2;
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSet.DownBack = null;
            this.btnSet.Location = new System.Drawing.Point(124, 99);
            this.btnSet.MouseBack = null;
            this.btnSet.Name = "btnSet";
            this.btnSet.NormlBack = null;
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lSignature);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Controls.Add(this.lIP);
            this.panel1.Controls.Add(this.lName);
            this.panel1.Controls.Add(this.pictureIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 155);
            this.panel1.TabIndex = 0;
            // 
            // lSignature
            // 
            this.lSignature.AutoSize = true;
            this.lSignature.Location = new System.Drawing.Point(104, 78);
            this.lSignature.Name = "lSignature";
            this.lSignature.Size = new System.Drawing.Size(0, 12);
            this.lSignature.TabIndex = 5;
            // 
            // pictureIcon
            // 
            this.pictureIcon.Location = new System.Drawing.Point(13, 26);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(78, 77);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureIcon.TabIndex = 0;
            this.pictureIcon.TabStop = false;
            // 
            // minIcon
            // 
            this.minIcon.ContextMenuStrip = this.minMenu;
            this.minIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("minIcon.Icon")));
            this.minIcon.Text = "最小化";
            this.minIcon.Visible = true;
            this.minIcon.DoubleClick += new System.EventHandler(this.minIcon_DoubleClick);
            // 
            // minMenu
            // 
            this.minMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主菜单ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.minMenu.Name = "minMenu";
            this.minMenu.Size = new System.Drawing.Size(137, 48);
            // 
            // 显示主菜单ToolStripMenuItem
            // 
            this.显示主菜单ToolStripMenuItem.Name = "显示主菜单ToolStripMenuItem";
            this.显示主菜单ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示主菜单ToolStripMenuItem.Text = "显示主菜单";
            this.显示主菜单ToolStripMenuItem.Click += new System.EventHandler(this.显示主菜单ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(308, 597);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Client_Load);
            this.MouseEnter += new System.EventHandler(this.Client_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Client_MouseLeave);
            this.panel2.ResumeLayout(false);
            this.TabClient.ResumeLayout(false);
            this.tabContacts.ResumeLayout(false);
            this.rightMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.minMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private CCWin.SkinControl.SkinTabControl TabClient;
        private CCWin.SkinControl.SkinTabPage tabContacts;
        private CCWin.SkinControl.SkinTabPage tabGroup;
        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lIP;
        private CCWin.SkinControl.SkinButton btnSet;
        private System.Windows.Forms.Panel panel1;
        private CCWin.SkinControl.ChatListBox chatshow;
        private System.Windows.Forms.NotifyIcon minIcon;
        private System.Windows.Forms.ContextMenuStrip minMenu;
        private System.Windows.Forms.ToolStripMenuItem 显示主菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label lSignature;
        private System.Windows.Forms.ToolTip TipSignature;
        private System.Windows.Forms.ContextMenuStrip rightMenu;
        private System.Windows.Forms.ToolStripMenuItem 头像显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大头像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小头像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新联系人ToolStripMenuItem;
    }
}