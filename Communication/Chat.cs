using BLL;
using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Communication
{
    public partial class Chat : CCSkinMain
    {
        private string myselfIP;            //自己的IP
        private User user;
        ChatManager chatManager;
        ClientManager clientManager;
        bool b = false;                  //判断是否在读取数据库，是则不进行震动、文件传输等操作
        bool IsEnter = true;            //判断是否使用Enter快捷键
        const int WM_COPYDATA = 0x004A;//文本类型参数
        private string filePath = string.Empty;     //文件路径
        string fileName = string.Empty;//文件名字
        private long fileLength;            //文件长度
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;//用户定义数据
            public int cbData;//数据大小
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;//指向数据的指针
        }//消息中传递的结构体
        public Chat()
        {
            InitializeComponent();
        }
        public Chat(string ip)
        {
            InitializeComponent();
            clientManager = new ClientManager();
            this.user = clientManager.GetUserByIP(ip);
            myselfIP=Base.GetAddressIP();
            chatManager = new ChatManager(myselfIP, ip);
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            PanelFile.Visible = false;
            pictureicon.Image = Base.ChageToImage(user.Picture);
            lName.Text = user.Name;
            if (user.Signature.Length > 35)
            {
                lSignature.Text = user.Signature.Substring(0, 35) + "...";
                tipSignature.SetToolTip(lSignature, user.Signature);
            }
            else
                lSignature.Text = user.Signature;
            Thread TGetChatlogs = new Thread(GetChatlogs);
            TGetChatlogs.IsBackground = true;
            TGetChatlogs.Start();
        }
        /// <summary>
        /// 获取聊天记录
        /// </summary>
        private void GetChatlogs()
        {
            List<ChatLog> chatloglist = chatManager.GetChatlogs();
            foreach (ChatLog chatlog in chatloglist)
            {
                chatlog.Data = Base.AESDecryption(chatlog.Data);
                b = true;
                DisplayMsg(rtbMsg, chatlog);
            }
            b = false;
        }

        #region 聊天信息
        /// <summary>
        /// 发送聊天信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (rtbSend.Text != "")
            {
                ChatLog chatlog = new ChatLog();
                chatlog.Sender = myselfIP;
                chatlog.Time = Base.GetDateTime();
                chatlog.Receiver = user.IP;
                chatlog.Data = rtbSend.Rtf;
                Thread TSendMsg = new Thread(new ThreadStart(delegate
                    {
                        SendMsg(chatlog);
                    }));
                TSendMsg.IsBackground = true;
                TSendMsg.Start();
                //清空输入框
                this.rtbSend.Rtf = string.Empty;
                this.rtbSend.Focus();
            }
        }
        private void SendMsg(ChatLog chatlog)
        {
            chatManager.SendChatlog(chatlog);
            chatlog.Data = Base.AESDecryption(chatlog.Data);
            DisplayMsg(rtbMsg, chatlog);
        } 

        /// <summary>
        /// 接收传递的消息
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                    ChatLog chatlog = new ChatLog();
                    Type mytype = mystr.GetType();
                    mystr = (COPYDATASTRUCT)m.GetLParam(mytype);
                    string message = mystr.lpData;
                    ReceiveChatlog(message);
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
        /// <summary>
        /// 接收聊天信息
        /// </summary>
        /// <param name="message"></param>
        public void ReceiveChatlog(string message)
        {
            ChatLog chatlog = Base.Decryption(message);
            chatlog.Data = Base.AESDecryption(chatlog.Data);
            DisplayMsg(rtbMsg, chatlog);
        }
        /// <summary>
        /// 消息发送快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsEnter && e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSend.PerformClick();
            }
            if (!IsEnter && e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSend.PerformClick();
            }
        }
        #endregion
        #region 显示到屏幕
        delegate void AddChatlogDelegate(RtfRichTextBox rtbMsg, ChatLog chatlog);
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="chatlog"></param>
        public void DisplayMsg(RtfRichTextBox rtbMsg, ChatLog chatlog)
        {
            if (rtbMsg.InvokeRequired)
            {
                AddChatlogDelegate d = new AddChatlogDelegate(DisplayMsg);
                rtbMsg.Invoke(d, new object[] { rtbMsg, chatlog });
            }
            else
            {
                if (chatlog.Data.Length > 6 && chatlog.Data.Substring(0, 6) == "【发送震动】")
                {
                    this.rtbMsg.AppendTextAsRtf(chatlog.Sender + "  " + chatlog.Time + "\r\n",
                        new Font(rtbMsg.Font, FontStyle.Regular), RtfRichTextBox.RtfColor.Red);
                    this.rtbMsg.SelectionColor = Color.Red;
                    this.rtbMsg.AppendTextAsRtf("   ");
                    this.rtbMsg.AppendText(clientManager.GetUserByIP(chatlog.Sender).Name + "给您发送了窗口抖动。\n");
                    //this.txtRMsg.AppendTextAsRtf("\n");
                    this.rtbMsg.ForeColor = Color.Black;
                    this.rtbMsg.Select(rtbMsg.Text.Length, 0);
                    this.rtbMsg.ScrollToCaret();
                    if(!b)
                        Vibration();
                }
                else if (chatlog.Data.Length > 6 && chatlog.Data.Substring(0, 6) == "【发送信息】")
                {
                    string senderName = clientManager.GetUserByIP(chatlog.Sender).Name;
                    this.rtbMsg.AppendTextAsRtf(senderName + "  " + chatlog.Time + "\r\n",
                    new Font(rtbMsg.Font, FontStyle.Regular), RtfRichTextBox.RtfColor.Green);
                    this.rtbMsg.SelectionColor = Color.Red;
                    this.rtbMsg.AppendText(chatlog.Data + "\n");
                    //this.txtRMsg.AppendTextAsRtf("\n");
                    this.rtbMsg.ForeColor = Color.Black;
                    this.rtbMsg.Select(rtbMsg.Text.Length, 0);
                    this.rtbMsg.ScrollToCaret();
                }
                else if (chatlog.Data.Length > 6 && chatlog.Data.Substring(0, 6) == "【发送文件】")
                {

                    filePath = chatlog.Data.Substring(6, chatlog.Data.IndexOf('(') - 6);
                    string[] fileNames = filePath.Split('\\');
                    fileName = fileNames[fileNames.Length - 1].ToString();
                    fileLength = Convert.ToInt64(chatlog.Data.Substring(chatlog.Data.IndexOf('(') + 1, chatlog.Data.IndexOf(')') - chatlog.Data.IndexOf('(') - 1));
                    string senderName = clientManager.GetUserByIP(chatlog.Sender).Name;
                    this.rtbMsg.AppendTextAsRtf(senderName + "  " + chatlog.Time + "\r\n",
                    new Font(rtbMsg.Font, FontStyle.Regular), RtfRichTextBox.RtfColor.Green);
                    this.rtbMsg.AppendTextAsRtf("   ");
                    this.rtbMsg.AppendText("【发送文件】" + fileName + "\n");
                    //this.txtRMsg.AppendTextAsRtf("\n");
                    this.rtbMsg.Select(rtbMsg.Text.Length, 0);
                    this.rtbMsg.ScrollToCaret();
                    if (chatlog.Receiver == myselfIP)        //自己为接收方
                    {
                        lSender.Text = user.Name + "给你发送一个文件";
                        PanelFile.Visible = true;
                    }
                }
                else
                {
                    if (chatlog.Sender == myselfIP)       //自己为发送方
                    {
                        string senderName = clientManager.GetUserByIP(chatlog.Sender).Name;
                        this.rtbMsg.AppendTextAsRtf(senderName + "  " + chatlog.Time + "\r\n",
                        new Font(rtbMsg.Font, FontStyle.Regular), RtfRichTextBox.RtfColor.Blue);
                        this.rtbMsg.AppendTextAsRtf("   ");
                        this.rtbMsg.AppendRtf(chatlog.Data);
                        //this.txtRMsg.AppendTextAsRtf("\n");
                        this.rtbMsg.Select(rtbMsg.Text.Length, 0);
                        this.rtbMsg.ScrollToCaret();
                    }
                    else                                //自己为接收方
                    {
                        string senderName = clientManager.GetUserByIP(chatlog.Sender).Name;
                        this.rtbMsg.AppendTextAsRtf(senderName + "  " + chatlog.Time + "\r\n",
                        new Font(rtbMsg.Font, FontStyle.Regular), RtfRichTextBox.RtfColor.Green);
                        this.rtbMsg.AppendTextAsRtf("   ");
                        this.rtbMsg.AppendRtf(chatlog.Data);
                        //this.txtRMsg.AppendTextAsRtf("\n");
                        this.rtbMsg.Select(rtbMsg.Text.Length, 0);
                        this.rtbMsg.ScrollToCaret();
                    }
                }
            }
        } 
        #endregion
        #region 按钮控件
        #region 文字
        /// <summary>
        /// 文字按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolFont_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == fontDialog1.ShowDialog())
            {
                this.rtbSend.Font = fontDialog1.Font;
                this.rtbSend.ForeColor = fontDialog1.Color;
            }
        }
        #endregion
        #region 表情
        #region 表情窗体与事件
        public Countenance _faceForm = null;
        public Countenance FaceForm
        {
            get
            {
                if (this._faceForm == null)
                {
                    this._faceForm = new Countenance(this)
                    {

                        ImagePath = "Face\\",
                        CustomImagePath = "Face\\Custom\\",
                        CanManage = true,
                        ShowDemo = true,
                    };

                    this._faceForm.Init(24, 24, 8, 8, 12, 8);
                    this._faceForm.Selected += this._faceForm_AddFace;

                }

                return this._faceForm;
            }
        }

        string imgName = "";
        void _faceForm_AddFace(object sender, SelectFaceArgs e)
        {
            this.imgName = e.Img.FullName.Replace(Application.StartupPath + "\\", "");
            this.rtbSend.InsertImage(e.Img.Image);
        }
        #endregion
        /// <summary>
        /// 表情按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolCountenance_Click(object sender, EventArgs e)
        {

            Point pt = this.PointToScreen(new Point(skToolMenu.Left + 30 - this.FaceForm.Width / 2, (skToolMenu.Top - this.FaceForm.Height)));
            this.FaceForm.Show(pt.X, pt.Y, skToolMenu.Height);
        }
        #endregion
        #region 震动
        /// <summary>
        /// 震动按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolVibration_Click(object sender, EventArgs e)
        {
            chatManager.SendVibration();
            Vibration();
        }
        /// <summary>
        /// 震动方法
        /// </summary>
        private void Vibration()
        {
            Point pOld = this.Location;//原来的位置
            int radius = 3;//半径
            for (int n = 0; n < 3; n++) //旋转圈数
            {
                //右半圆逆时针
                for (int i = -radius; i <= radius; i++)
                {
                    int x = Convert.ToInt32(Math.Sqrt(radius * radius - i * i));
                    int y = -i;

                    this.Location = new Point(pOld.X + x, pOld.Y + y);
                    Thread.Sleep(10);
                }
                //左半圆逆时针
                for (int j = radius; j >= -radius; j--)
                {
                    int x = -Convert.ToInt32(Math.Sqrt(radius * radius - j * j));
                    int y = -j;

                    this.Location = new Point(pOld.X + x, pOld.Y + y);
                    Thread.Sleep(10);
                }
            }
            //抖动完成，恢复原来位置
            this.Location = pOld;
        }
        #endregion
        #region 图片
        /// <summary>
        /// 图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolPicture_Click(object sender, EventArgs e)
        {
            FileSend("PNG文件|*.png|GIF文件|*.gif|BMP文件|*.bmp|JPG文件|*.jpg|所有文件(*.*)|*.*");
        }
        #endregion
        #region 截图
        /// <summary>
        /// 截图按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolCut_Click(object sender, EventArgs e)
        {
            this.StartCapture();
        }
        //截图方法
        private FrmCapture m_frmCapture;
        private void StartCapture()
        {
            if (m_frmCapture == null || m_frmCapture.IsDisposed)
                m_frmCapture = new FrmCapture(rtbSend);
            m_frmCapture.IsCaptureCursor = false;
            m_frmCapture.Show();
        }
        #endregion 
        #region 文件
        private void toolSendFile_Click(object sender, EventArgs e)
        {
            FileSend("所有文件(*.*)|*.*");
        }

        private void toolSendFiles_Click(object sender, EventArgs e)
        {
            FilesSend();
        }
        #endregion
        #region 按钮
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 下拉按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            btnDown.StopState = StopStates.Pressed;
            DownMenu.Show(btnDown, new Point(0, btnDown.Height + 5));
        }
        /// <summary>
        /// 设置Enter发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSetEnter_Click(object sender, EventArgs e)
        {
            //修改显示的图片，设置快捷键
            ItemSetEnter.Image = Communication.Properties.Resources.menu_check;
            ItemSetCtrlEnter.Image = null;
            IsEnter = true;
        }
        /// <summary>
        /// 设置Ctrl+Enter发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSetCtrlEnter_Click(object sender, EventArgs e)
        {
            //修改显示的图片，设置快捷键
            ItemSetCtrlEnter.Image = Communication.Properties.Resources.menu_check;
            ItemSetEnter.Image = null;
            IsEnter = false;
        }
        private void DownMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            //选择菜单关闭时按钮变回原样
            btnDown.StopState = StopStates.NoStop;
            btnDown.ControlState = ControlState.Normal;
        }
        #endregion
        #endregion
        #region 文件发送接收
        //文件发送方法
        private void FileSend(string Filter)
        {
            try
            {
                OpenFileDialog Dlg = new OpenFileDialog();
                Dlg.Filter = Filter;
                Dlg.CheckFileExists = true;
                Dlg.InitialDirectory = "C:\\Documents and Settings\\" + System.Environment.UserName + "\\桌面\\";

                if (Dlg.ShowDialog() == DialogResult.OK)
                {
                    FileInfo FI = new FileInfo(Dlg.FileName);
                    ChatLog chatlog = new ChatLog();
                    chatlog.Sender = myselfIP;
                    chatlog.Receiver = user.IP;
                    chatlog.Data = "【发送文件】" + Dlg.FileName + "(" + FI.Length + ")";
                    chatlog.Time = Base.GetDateTime();
                    chatManager.SendFile(chatlog);
                    chatlog.Data = Base.AESDecryption(chatlog.Data);
                    DisplayMsg(rtbMsg, chatlog);
                }
            }
            catch(Exception e)
            {
                Base.WriteLog(e.Message);
                MessageBox.Show("文件发送失败！" + "\r\n");
            }
        }
        private void FilesSend()
        {
            try
            {
                FolderBrowserDialog fbDialog = new FolderBrowserDialog();
                fbDialog.SelectedPath = Directory.GetCurrentDirectory();
                if(fbDialog.ShowDialog()==DialogResult.OK)
                {
                    string path=fbDialog.SelectedPath;
                    ZipClass zip = new ZipClass();
                    zip.ZipFileFromDirectory(path, path, 1);
                }
            }
            catch(Exception e)
            {
                Base.WriteLog(e.Message);
            }
        }
        /// <summary>
        /// 接收文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llAccept_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetFile();
        }
        delegate void AcceptOrNotfDelete();
        /// <summary>
        /// 回复同意接收文件
        /// </summary>
        private void GetFile()
        {
            llAccept.Enabled = false;
            llRefuse.Enabled = false;
            Thread TBeginGetFile = new Thread(BeginGetFile);
            TBeginGetFile.IsBackground = true;
            TBeginGetFile.Start();

        }
        delegate void BeginGetFileDelegate();
        private void BeginGetFile()
        {
            if (this.PanelFile.InvokeRequired)
            {
                BeginGetFileDelegate d = BeginGetFile;
                this.PanelFile.Invoke(d);
            }
            else
            {
                try
                {
                    ChatLog chatlog = new ChatLog();
                    chatlog.Sender = myselfIP;
                    chatlog.Receiver = user.IP;
                    chatlog.Data = filePath;
                    chatlog.Time = Base.GetDateTime();
                    FileManager fileManager = new FileManager(fileName, chatlog.Sender);
                    fileManager.TCPListen();
                    chatManager.BeginGetFile(chatlog);
                    fileManager.TCPReviceFile(ProgressBarFile, fileLength);
                    chatlog.Data = "【发送信息】文件已保存";
                    chatlog.Time = Base.GetDateTime();
                    DisplayMsg(rtbMsg, chatlog);
                    chatlog.Data = "【发送信息】文件已发送成功";
                    chatManager.SendChatlog(chatlog);
                    this.llAccept.Enabled = true;
                    this.llRefuse.Enabled = true;
                    this.ProgressBarFile.Value = 0;
                    this.PanelFile.Visible = false;
                }
                catch (Exception e)
                {
                    Base.WriteLog(e.Message);
                };
            }
        }
        /// <summary>
        /// 拒绝接受文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llRefuse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChatLog chatlog = new ChatLog();
            chatlog.Sender = myselfIP;
            chatlog.Time = Base.GetDateTime();
            chatlog.Receiver = user.IP;
            chatlog.Data = "【发送信息】拒绝接收文件";
            PanelFile.Visible = false;
            chatManager.SendChatlog(chatlog);
        }
        #endregion
    }
}
