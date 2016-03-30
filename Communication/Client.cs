using BLL;
using CCWin;
using CCWin.SkinControl;
using CCWin.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communication
{
    public partial class Client : CCSkinMain
    {
        int state;
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 20;
            this.Top = 0;
            this.ShowInTaskbar = false;
            Init();
            System.Media.SystemSounds.Question.Play();
            //监听事件
            ClientManager clientManager = new ClientManager(chatshow);
            Thread ReceiveData = new Thread(clientManager.ReceviceData);
            ReceiveData.IsBackground = true;
            ReceiveData.Start();


            //上线广播
            BoardCast bc = new BoardCast();
            Thread.Sleep(100);
            bc.LoginBoardCast();
        }

        /// <summary>
        /// 个人信息初始化
        /// </summary>
        private void Init()
        {
            lIP.Text = Base.GetAddressIP();
            ClientManager clientManager = new ClientManager();
            User user = clientManager.GetUserByIP(lIP.Text);
            lName.Text = user.Name;
            pictureIcon.Image = Base.ChageToImage(user.Picture);
            if (user.Signature.Length > 10)
            {
                lSignature.Text = user.Signature.Substring(0, 10)+"...";
                TipSignature.SetToolTip(lSignature, user.Signature);
            }
            else lSignature.Text = user.Signature;
        }
        /// <summary>
        /// 打开聊天窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="es"></param>
        private void chatshow_DoubleClickSubItem(object sender, CCWin.SkinControl.ChatListEventArgs e, MouseEventArgs es)
        {
            ChatListSubItem item = e.SelectSubItem;
            item.IsTwinkle = false;

            string windowsName = "与 " + item.DisplayName + " 对话中";
            IntPtr handle = NativeMethods.FindWindow(null, windowsName);
            if (handle != IntPtr.Zero)
            {
                Form frm = (Form)Form.FromHandle(handle);
                frm.Activate();
            }
            else
            {
                Chat fChat = new Chat(item.NicName);
                fChat.Text = "与 " + item.DisplayName + " 对话中";
                fChat.Show();
            }
        }
        /// <summary>
        /// 下线前发送下线广播
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                minIcon.Visible = false;
                BoardCast bc = new BoardCast();
                bc.OutLoginBoardCast();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch(Exception ex)
            {
                Base.WriteLog(ex.Message);
            }
        }
        /// <summary>
        /// 个人设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            Setting set = new Setting(Base.GetAddressIP());
            if(set.ShowDialog()==DialogResult.OK)
            {
                Init();
                BoardCast bc = new BoardCast();
                bc.LoginBoardCast();
            }
        }
        #region 窗体隐藏
        private void Client_MouseEnter(object sender, EventArgs e)
        {
            if (state == 0)
            {
                state = 1;
                int t = this.Top;
                for (int i = t; i <= 0; i = i + 10)
                {
                    this.Top = i;
                    Application.DoEvents();
                }
                state = 0;
            }
        }
        private void Client_MouseLeave(object sender, EventArgs e)
        {
            if (this.Top <= 0 && state == 0)
            {
                state = 1;
                int t = this.Top;
                for (int i = t; i > -this.Height + 2; i--)
                {
                    this.Top = i;
                    Application.DoEvents();
                }
                state = 0;
            }
        }
        /// <summary>
        /// 图标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minIcon_DoubleClick(object sender, EventArgs e)
        {
            if(this.ShowInTaskbar==false)
            {
                this.Show();
                this.Activate();
                this.WindowState = FormWindowState.Normal;
                Client_MouseEnter(sender, e);
            }
        }
        /// <summary>
        /// 右击退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                minIcon.Visible = false;
                BoardCast bc = new BoardCast();
                bc.OutLoginBoardCast();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                Base.WriteLog(ex.Message);
            }
        }
        #endregion

        #region 右击按钮
        /// <summary>
        /// 右击显示主菜单按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 显示主菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
            this.WindowState = FormWindowState.Normal;
            Client_MouseEnter(sender, e);
        }
        /// <summary>
        /// 头像变大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemLargeIcon_Click(object sender, EventArgs e)
        {
            chatshow.IconSizeMode = ChatListItemIcon.Large;
            ItemLargeIcon.Image = Communication.Properties.Resources.menu_check;
            ItemSmallIcon.Image = null;
        }
        /// <summary>
        /// 头像变小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSmallIcon_Click(object sender, EventArgs e)
        {
            chatshow.IconSizeMode = ChatListItemIcon.Small;
            ItemSmallIcon.Image = Communication.Properties.Resources.menu_check;
            ItemLargeIcon.Image = null;
        }
        /// <summary>
        /// 刷新好友列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemFlush_Click(object sender, EventArgs e)
        {
            //ClientManager clientManager = new ClientManager(chatshow);
            BoardCast bc = new BoardCast();
            bc.LoginBoardCast();
        }
        #endregion
    }
}
