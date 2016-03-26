using BLL;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communication
{
    public partial class Information : CCSkinMain
    {
        ChatLog chatlog;
        public Information()
        {
            InitializeComponent();
        }
        public Information(ChatLog chatlog)
        {
            this.chatlog = chatlog;
        }

        private void Information_Load(object sender, EventArgs e)
        {
            ChatManager chatManager = new ChatManager();
            User user = chatManager.GetUser(chatlog.Sender);
            picbIcon.ImageLocation = user.Picture;
            lName.Text = user.Name;
            lData.Text = chatlog.Data;

            //初始化窗口出现位置
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            this.PointToScreen(p);
            this.Location = p;
            NativeMethods.AnimateWindow(this.Handle, 130, AW.AW_SLIDE + AW.AW_VER_NEGATIVE);//开始窗体动画
        }

        private void timeshow_Tick(object sender, EventArgs e)
        {
            //鼠标不在窗体内时
            if (!this.Bounds.Contains(Cursor.Position))
            {
                this.Close();
            }
        }

        private void Information_DoubleClick(object sender, EventArgs e)
        {
            Chat chat = new Chat(chatlog.Sender);
            chat.Show();
        }
    }
}
