using BLL;
using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communication
{
    public partial class Chat : CCSkinMain
    {
        private User user;
        private ChatLog chatlog;
        ChatManager chatManager;
        const int WM_COPYDATA = 0x004A;//文本类型参数
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
            chatManager = new ChatManager(rtbMsg);
            this.user = chatManager.GetUser(ip);
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            pictureicon.ImageLocation = user.Picture;
            lName.Text = user.Name;
            lSignature.Text = user.Signature;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    chatlog = new ChatLog();
                    Type mytype = mystr.GetType();
                    mystr = (COPYDATASTRUCT)m.GetLParam(mytype);
                    string message = mystr.lpData;
                    chatManager.ReceiveChatlog(message);
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
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
            chatManager.SendVibration(user.IP);
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
        #endregion
    }
}
