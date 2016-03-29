namespace Communication
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.pictureicon = new CCWin.SkinControl.SkinPictureBox();
            this.lName = new CCWin.SkinControl.SkinLabel();
            this.rtbMsg = new CCWin.SkinControl.RtfRichTextBox();
            this.rtbSend = new CCWin.SkinControl.RtfRichTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.skToolMenu = new CCWin.SkinControl.SkinToolStrip();
            this.toolFont = new System.Windows.Forms.ToolStripButton();
            this.toolCountenance = new System.Windows.Forms.ToolStripButton();
            this.toolVibration = new System.Windows.Forms.ToolStripButton();
            this.toolPicture = new System.Windows.Forms.ToolStripButton();
            this.toolCut = new System.Windows.Forms.ToolStripButton();
            this.btnSend = new CCWin.SkinControl.SkinButton();
            this.btnClose = new CCWin.SkinControl.SkinButton();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.toolFaceTime = new System.Windows.Forms.ToolStripButton();
            this.toolVoice = new System.Windows.Forms.ToolStripButton();
            this.toolFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolSendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSendFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.lSignature = new CCWin.SkinControl.SkinLabel();
            this.PanelFile = new CCWin.SkinControl.SkinPanel();
            this.lSender = new System.Windows.Forms.Label();
            this.ProgressBarFile = new CCWin.SkinControl.SkinProgressBar();
            this.llRefuse = new System.Windows.Forms.LinkLabel();
            this.llAccept = new System.Windows.Forms.LinkLabel();
            this.tipSignature = new System.Windows.Forms.ToolTip(this.components);
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureicon)).BeginInit();
            this.skToolMenu.SuspendLayout();
            this.skinToolStrip1.SuspendLayout();
            this.PanelFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.pictureicon);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(7, 7);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(52, 49);
            this.skinPanel1.TabIndex = 0;
            // 
            // pictureicon
            // 
            this.pictureicon.BackColor = System.Drawing.Color.Transparent;
            this.pictureicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureicon.Location = new System.Drawing.Point(3, 3);
            this.pictureicon.Name = "pictureicon";
            this.pictureicon.Size = new System.Drawing.Size(46, 43);
            this.pictureicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureicon.TabIndex = 9;
            this.pictureicon.TabStop = false;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.BackColor = System.Drawing.Color.Transparent;
            this.lName.BorderColor = System.Drawing.Color.White;
            this.lName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lName.Location = new System.Drawing.Point(65, 9);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(88, 25);
            this.lName.TabIndex = 1;
            this.lName.Text = "我的好友";
            // 
            // rtbMsg
            // 
            this.rtbMsg.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.rtbMsg.Location = new System.Drawing.Point(12, 98);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ReadOnly = true;
            this.rtbMsg.Size = new System.Drawing.Size(534, 198);
            this.rtbMsg.TabIndex = 3;
            this.rtbMsg.Text = "";
            this.rtbMsg.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // rtbSend
            // 
            this.rtbSend.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.rtbSend.Location = new System.Drawing.Point(12, 329);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Size = new System.Drawing.Size(534, 146);
            this.rtbSend.TabIndex = 4;
            this.rtbSend.Text = "";
            this.rtbSend.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // skToolMenu
            // 
            this.skToolMenu.Arrow = System.Drawing.Color.Black;
            this.skToolMenu.Back = System.Drawing.Color.White;
            this.skToolMenu.BackColor = System.Drawing.Color.Transparent;
            this.skToolMenu.BackRadius = 4;
            this.skToolMenu.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skToolMenu.Base = System.Drawing.Color.Transparent;
            this.skToolMenu.BaseFore = System.Drawing.Color.Black;
            this.skToolMenu.BaseForeAnamorphosis = false;
            this.skToolMenu.BaseForeAnamorphosisBorder = 4;
            this.skToolMenu.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skToolMenu.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skToolMenu.BaseHoverFore = System.Drawing.Color.White;
            this.skToolMenu.BaseItemAnamorphosis = true;
            this.skToolMenu.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.BaseItemBorderShow = true;
            this.skToolMenu.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skToolMenu.BaseItemDown")));
            this.skToolMenu.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skToolMenu.BaseItemMouse")));
            this.skToolMenu.BaseItemNorml = null;
            this.skToolMenu.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.BaseItemRadius = 4;
            this.skToolMenu.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenu.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.BindTabControl = null;
            this.skToolMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.skToolMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skToolMenu.Fore = System.Drawing.Color.Black;
            this.skToolMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skToolMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skToolMenu.HoverFore = System.Drawing.Color.White;
            this.skToolMenu.ItemAnamorphosis = true;
            this.skToolMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemBorderShow = true;
            this.skToolMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemRadius = 4;
            this.skToolMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFont,
            this.toolCountenance,
            this.toolVibration,
            this.toolPicture,
            this.toolCut});
            this.skToolMenu.Location = new System.Drawing.Point(14, 301);
            this.skToolMenu.Name = "skToolMenu";
            this.skToolMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenu.Size = new System.Drawing.Size(122, 27);
            this.skToolMenu.SkinAllColor = true;
            this.skToolMenu.TabIndex = 8;
            this.skToolMenu.Text = "skinToolStrip2";
            this.skToolMenu.TitleAnamorphosis = true;
            this.skToolMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skToolMenu.TitleRadius = 4;
            this.skToolMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolFont
            // 
            this.toolFont.AutoSize = false;
            this.toolFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFont.Image = global::Communication.Properties.Resources.aio_quickbar_font;
            this.toolFont.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFont.Name = "toolFont";
            this.toolFont.Size = new System.Drawing.Size(23, 24);
            this.toolFont.Text = "字体选择工具栏";
            this.toolFont.Click += new System.EventHandler(this.toolFont_Click);
            // 
            // toolCountenance
            // 
            this.toolCountenance.AutoSize = false;
            this.toolCountenance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCountenance.Image = global::Communication.Properties.Resources.aio_quickbar_face;
            this.toolCountenance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCountenance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCountenance.Name = "toolCountenance";
            this.toolCountenance.Size = new System.Drawing.Size(24, 24);
            this.toolCountenance.Text = "表情选择工具栏";
            this.toolCountenance.Click += new System.EventHandler(this.toolCountenance_Click);
            // 
            // toolVibration
            // 
            this.toolVibration.AutoSize = false;
            this.toolVibration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolVibration.Image = global::Communication.Properties.Resources.aio_quickbar_twitter;
            this.toolVibration.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolVibration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolVibration.Name = "toolVibration";
            this.toolVibration.Size = new System.Drawing.Size(24, 24);
            this.toolVibration.Text = "向你的好友发送震动";
            this.toolVibration.Click += new System.EventHandler(this.toolVibration_Click);
            // 
            // toolPicture
            // 
            this.toolPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPicture.Image = global::Communication.Properties.Resources.aio_quickbar_sendpic;
            this.toolPicture.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPicture.Name = "toolPicture";
            this.toolPicture.Size = new System.Drawing.Size(24, 24);
            this.toolPicture.Text = "向你的好友发送图片";
            this.toolPicture.Click += new System.EventHandler(this.toolPicture_Click);
            // 
            // toolCut
            // 
            this.toolCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCut.Image = global::Communication.Properties.Resources.aio_quickbar_cut;
            this.toolCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCut.Name = "toolCut";
            this.toolCut.Size = new System.Drawing.Size(24, 24);
            this.toolCut.Text = "截图";
            this.toolCut.Click += new System.EventHandler(this.toolCut_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.btnSend.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSend.DownBack = global::Communication.Properties.Resources.button_login_down;
            this.btnSend.Location = new System.Drawing.Point(471, 484);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnSend.MouseBack = global::Communication.Properties.Resources.button_login_hover;
            this.btnSend.Name = "btnSend";
            this.btnSend.NormlBack = global::Communication.Properties.Resources.button_login_normal;
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.btnClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClose.DownBack = global::Communication.Properties.Resources.button_login_down;
            this.btnClose.Location = new System.Drawing.Point(390, 484);
            this.btnClose.MouseBack = global::Communication.Properties.Resources.button_login_normal;
            this.btnClose.Name = "btnClose";
            this.btnClose.NormlBack = global::Communication.Properties.Resources.button_login_normal;
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // skinToolStrip1
            // 
            this.skinToolStrip1.Arrow = System.Drawing.Color.Black;
            this.skinToolStrip1.Back = System.Drawing.Color.White;
            this.skinToolStrip1.BackRadius = 4;
            this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip1.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseForeAnamorphosis = false;
            this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip1.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.BaseItemAnamorphosis = true;
            this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.skinToolStrip1.BaseItemBorderShow = true;
            this.skinToolStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemDown")));
            this.skinToolStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemMouse")));
            this.skinToolStrip1.BaseItemNorml = null;
            this.skinToolStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemRadius = 4;
            this.skinToolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BindTabControl = null;
            this.skinToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip1.Fore = System.Drawing.Color.Black;
            this.skinToolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip1.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.ItemAnamorphosis = true;
            this.skinToolStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemBorderShow = true;
            this.skinToolStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemRadius = 4;
            this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFaceTime,
            this.toolVoice,
            this.toolFile});
            this.skinToolStrip1.Location = new System.Drawing.Point(7, 59);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(144, 33);
            this.skinToolStrip1.SkinAllColor = true;
            this.skinToolStrip1.TabIndex = 2;
            this.skinToolStrip1.Text = "skinToolStrip1";
            this.skinToolStrip1.TitleAnamorphosis = true;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolFaceTime
            // 
            this.toolFaceTime.AutoSize = false;
            this.toolFaceTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolFaceTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFaceTime.Image = ((System.Drawing.Image)(resources.GetObject("toolFaceTime.Image")));
            this.toolFaceTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolFaceTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFaceTime.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolFaceTime.Name = "toolFaceTime";
            this.toolFaceTime.Size = new System.Drawing.Size(36, 28);
            this.toolFaceTime.Text = "视频聊天";
            // 
            // toolVoice
            // 
            this.toolVoice.AutoSize = false;
            this.toolVoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolVoice.Image = ((System.Drawing.Image)(resources.GetObject("toolVoice.Image")));
            this.toolVoice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolVoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolVoice.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolVoice.Name = "toolVoice";
            this.toolVoice.Size = new System.Drawing.Size(40, 28);
            this.toolVoice.Text = "语音聊天";
            // 
            // toolFile
            // 
            this.toolFile.AutoSize = false;
            this.toolFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSendFile,
            this.toolSendFiles});
            this.toolFile.Image = ((System.Drawing.Image)(resources.GetObject("toolFile.Image")));
            this.toolFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFile.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolFile.Name = "toolFile";
            this.toolFile.Size = new System.Drawing.Size(50, 30);
            this.toolFile.Text = "发送文件";
            // 
            // toolSendFile
            // 
            this.toolSendFile.Name = "toolSendFile";
            this.toolSendFile.Size = new System.Drawing.Size(136, 22);
            this.toolSendFile.Text = "发送文件";
            this.toolSendFile.Click += new System.EventHandler(this.toolSendFile_Click);
            // 
            // toolSendFiles
            // 
            this.toolSendFiles.Name = "toolSendFiles";
            this.toolSendFiles.Size = new System.Drawing.Size(136, 22);
            this.toolSendFiles.Text = "发送文件夹";
            this.toolSendFiles.Click += new System.EventHandler(this.toolSendFiles_Click);
            // 
            // lSignature
            // 
            this.lSignature.AutoSize = true;
            this.lSignature.BackColor = System.Drawing.Color.Transparent;
            this.lSignature.BorderColor = System.Drawing.Color.White;
            this.lSignature.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lSignature.Location = new System.Drawing.Point(67, 39);
            this.lSignature.Name = "lSignature";
            this.lSignature.Size = new System.Drawing.Size(0, 17);
            this.lSignature.TabIndex = 9;
            // 
            // PanelFile
            // 
            this.PanelFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PanelFile.Controls.Add(this.lSender);
            this.PanelFile.Controls.Add(this.ProgressBarFile);
            this.PanelFile.Controls.Add(this.llRefuse);
            this.PanelFile.Controls.Add(this.llAccept);
            this.PanelFile.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.PanelFile.DownBack = null;
            this.PanelFile.Location = new System.Drawing.Point(14, 248);
            this.PanelFile.MouseBack = null;
            this.PanelFile.Name = "PanelFile";
            this.PanelFile.NormlBack = null;
            this.PanelFile.Size = new System.Drawing.Size(242, 48);
            this.PanelFile.TabIndex = 10;
            this.PanelFile.Visible = false;
            // 
            // lSender
            // 
            this.lSender.AutoSize = true;
            this.lSender.ForeColor = System.Drawing.Color.Blue;
            this.lSender.Location = new System.Drawing.Point(9, 29);
            this.lSender.Name = "lSender";
            this.lSender.Size = new System.Drawing.Size(125, 12);
            this.lSender.TabIndex = 11;
            this.lSender.Text = "Name向你发送一个文件";
            // 
            // ProgressBarFile
            // 
            this.ProgressBarFile.Back = null;
            this.ProgressBarFile.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBarFile.BarBack = null;
            this.ProgressBarFile.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ProgressBarFile.ForeColor = System.Drawing.Color.Red;
            this.ProgressBarFile.Location = new System.Drawing.Point(138, 11);
            this.ProgressBarFile.Name = "ProgressBarFile";
            this.ProgressBarFile.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.ProgressBarFile.Size = new System.Drawing.Size(75, 14);
            this.ProgressBarFile.TabIndex = 11;
            // 
            // llRefuse
            // 
            this.llRefuse.AutoSize = true;
            this.llRefuse.LinkColor = System.Drawing.Color.Red;
            this.llRefuse.Location = new System.Drawing.Point(65, 11);
            this.llRefuse.Name = "llRefuse";
            this.llRefuse.Size = new System.Drawing.Size(29, 12);
            this.llRefuse.TabIndex = 11;
            this.llRefuse.TabStop = true;
            this.llRefuse.Text = "拒绝";
            this.llRefuse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRefuse_LinkClicked);
            // 
            // llAccept
            // 
            this.llAccept.AutoSize = true;
            this.llAccept.LinkColor = System.Drawing.Color.Green;
            this.llAccept.Location = new System.Drawing.Point(16, 11);
            this.llAccept.Name = "llAccept";
            this.llAccept.Size = new System.Drawing.Size(29, 12);
            this.llAccept.TabIndex = 11;
            this.llAccept.TabStop = true;
            this.llAccept.Text = "接收";
            this.llAccept.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAccept_LinkClicked);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(158)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(571, 514);
            this.Controls.Add(this.PanelFile);
            this.Controls.Add(this.lSignature);
            this.Controls.Add(this.skToolMenu);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbSend);
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.skinToolStrip1);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.skinPanel1);
            this.EffectCaption = CCWin.TitleType.None;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Chat";
            this.ShowDrawIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.skinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureicon)).EndInit();
            this.skToolMenu.ResumeLayout(false);
            this.skToolMenu.PerformLayout();
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.PanelFile.ResumeLayout(false);
            this.PanelFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinLabel lName;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private System.Windows.Forms.ToolStripButton toolFaceTime;
        private System.Windows.Forms.ToolStripButton toolVoice;
        private System.Windows.Forms.ToolStripDropDownButton toolFile;
        private CCWin.SkinControl.RtfRichTextBox rtbMsg;
        private CCWin.SkinControl.SkinButton btnClose;
        private CCWin.SkinControl.SkinButton btnSend;
        private CCWin.SkinControl.SkinPictureBox pictureicon;
        private System.Windows.Forms.ToolStripMenuItem toolSendFile;
        private System.Windows.Forms.ToolStripMenuItem toolSendFiles;
        private CCWin.SkinControl.SkinToolStrip skToolMenu;
        private System.Windows.Forms.ToolStripButton toolFont;
        private System.Windows.Forms.ToolStripButton toolCountenance;
        private System.Windows.Forms.ToolStripButton toolVibration;
        private System.Windows.Forms.ToolStripButton toolPicture;
        private System.Windows.Forms.ToolStripButton toolCut;
        private System.Windows.Forms.FontDialog fontDialog1;
        public CCWin.SkinControl.RtfRichTextBox rtbSend;
        private CCWin.SkinControl.SkinLabel lSignature;
        private CCWin.SkinControl.SkinPanel PanelFile;
        private System.Windows.Forms.LinkLabel llRefuse;
        private System.Windows.Forms.LinkLabel llAccept;
        private CCWin.SkinControl.SkinProgressBar ProgressBarFile;
        private System.Windows.Forms.Label lSender;
        private System.Windows.Forms.ToolTip tipSignature;
    }
}