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
    public partial class Directory : Form
    {
        delegate void AppendStringCallback(string text);
        AppendStringCallback appendStringCallback;

        delegate void RemoveStringCallback(string text);
        RemoveStringCallback removeStringCallback;
        //使用的接收端口号(上下线)
        private int port = 8001;
        private UdpClient udpClient;
        bool b = true;
        public Directory()
        {
            InitializeComponent();
            appendStringCallback = new AppendStringCallback(AppendString);
            removeStringCallback = new RemoveStringCallback(RemoveString);
        }

        private void Directory_Load(object sender, EventArgs e)
        {
            lbName.Text = "";
            btnOutLogin.Enabled = false;
            Thread myThread = new Thread(ReceiveData);          //接收上下线信息
            myThread.IsBackground = true;
            myThread.Start();
            Thread myThread1 = new Thread(ReceviceData);        //接收发送过来的信息
            myThread1.IsBackground = true;
            myThread1.Start();
        }
        #region 上下线
        /// <summary>
        /// 发送上下线信息（本地）
        /// </summary>
        private void ReceiveData()
        {
            udpClient = new UdpClient(port);
            IPEndPoint remote = null;
            while (true)
            {
                try
                {

                    byte[] bytes = udpClient.Receive(ref remote);
                    string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    string[] strs = str.Split(',');
                    if (strs[1].ToString() == "上线了")
                        AppendString(string.Format("{0}:{1}", remote, str));
                    if (strs[1].ToString() == "下线了")
                    {
                        AppendString(string.Format("{0}:{1}", remote, str));
                        //RemoveString(string.Format("{0}:{1}", remote, str));
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                Thread TSend = new Thread(Send);
                TSend.IsBackground = true;
                btnOutLogin.Enabled = true;
                btnLogin.Enabled = false;
                b = true;
                TSend.Start();
            }
        }
        /// <summary>
        /// 登录（广播）
        /// </summary>
        private void Send()
        {
            UdpClient myudpClient = new UdpClient();
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, port);
                byte[] bytes = Encoding.UTF8.GetBytes(txtName.Text + ",上线了");
                while (b)
                {
                    myudpClient.Send(bytes, bytes.Length, iep);
                    Thread.Sleep(500);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "登录失败");
            }
            finally
            {
                myudpClient.Close();
            }

        }
        /// <summary>
        /// 下线（广播）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutLogin_Click(object sender, EventArgs e)
        {
            UdpClient myudpClient = new UdpClient();
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, port);
                byte[] bytes = Encoding.UTF8.GetBytes(txtName.Text + ",下线了");
                btnOutLogin.Enabled = false;
                btnLogin.Enabled = true;
                b = false;
                myudpClient.Send(bytes, bytes.Length, iep);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "登录失败");
            }
            finally
            {
                myudpClient.Close();
            }
        }
        /// <summary>
        /// 增加信息
        /// </summary>
        /// <param name="text"></param>
        private void AppendString(string text)
        {
            if (lbName.InvokeRequired == true)
            {
                this.Invoke(appendStringCallback, text);
            }
            else
            {
                if (lbName.Items.Contains(text))
                { }
                else
                {
                    lbName.Items.Add(text);
                    lbName.SelectedIndex = lbName.Items.Count - 1;
                    lbName.ClearSelected();
                }
            }
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="text"></param>
        private void RemoveString(string text)
        {
            if (lbName.InvokeRequired == true)
            {
                this.Invoke(removeStringCallback, text);
            }
            else
            {
                lbName.Items.Remove(text);
            }
        }
        #endregion

        #region 接收数据
        UdpClient uc = new UdpClient(8002);
        /// <summary>
        /// 在后台运行的接收数据线程
        /// </summary>
        private void ReceviceData()
        {
            IAsyncResult ar = uc.BeginReceive(ReceviceCallback, uc);
            ar.AsyncWaitHandle.WaitOne();
        }
        /// <summary>
        /// 接收数据回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void ReceviceCallback(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)ar.AsyncState;
            IPEndPoint remote = null;
            byte[] bytes = u.EndReceive(ar, ref remote);
            ChatLog chat = Base.DeSerialize<ChatLog>(bytes);
            //string message = Encoding.UTF8.GetString(bytes, 0, bytes.Length);



            Thread TSave = new Thread(Save);
            //TSave.Start(message);
            TSave.Start(chat);
            ReceviceData();
        }
        /// <summary>
        /// 保存数据到数据库中
        /// </summary>
        /// <param name="message"></param>
        private void Save(object message)
        {
            //ChatLog chat = Base.Decryption(message.ToString());
            ChatLogService.InsertChatLog((ChatLog)message);
        } 
        #endregion


        /// <summary>
        /// 打开对话窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbName_DoubleClick(object sender, EventArgs e)
        {
            string str = lbName.SelectedItem.ToString();
            //Chat from1 = Chat.GetInstance(str);
            Chat from1 = new Chat(str);
            from1.Show();
        }
    }
    }
}
