using CCWin.SkinControl;
using CCWin.Win32;
using CCWin.Win32.Const;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class ClientManager
    {
        private ChatListBox chat;
        private ChatListItem listItem;
        private int port = 8001;
        private UdpClient udpclient;
        List<UdpPacket> udpPackets = new List<UdpPacket>();
        int number = 0;
        [DllImport("user32.dll ", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        const int WM_COPYDATA = 0x004A;//文本类型参数

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;//用户定义数据
            public int cbData;//数据大小
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;//指向数据的指针
        }//消息中传递的结构体
        public ClientManager(ChatListBox chatlistbox)
        {
            CreateGroupUsers();
            CreateTableUsers();
            udpclient = new UdpClient(port);
            chat = chatlistbox;
            listItem = new ChatListItem("我的好友");
            chat.Items.Add(listItem);
            //AddItem();
            AddFriend();
        }
        public ClientManager()
        {
            CreateGroupUsers();
            CreateTableUsers();
        }
        /// <summary>
        /// 创建Users表
        /// </summary>
        private void CreateTableUsers()
        {
            ClientService.CreateTableUsers();
            if (ClientService.GetUserByIP(Base.GetAddressIP()) == null)
            {
                User user = new User();
                user.IP = Base.GetAddressIP();
                user.Name = "Administrator";
                Image img = Image.FromFile("head/4.png");
                user.Picture = Base.ChangeToBytes(img);
                user.Signature = " ";
                user.Group = 0;
                ClientService.InsertUser(user);
            }
        }
        /// <summary>
        /// 创建联系人分组表
        /// </summary>
        private void CreateGroupUsers()
        {
            UsersGroupService.CreateUsersGroup();
            UsersGroup ug = new UsersGroup();
            ug.GroupName = "我的好友";
            if (!UsersGroupService.GetIDByUsersGroupName(ug.GroupName))
            {
                UsersGroupService.InsertUsersGroup(ug);
            }
        }
        /// <summary>
        /// 通过IP获取用户信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public User GetUserByIP(string ip)
        {
            CreateGroupUsers();
            CreateTableUsers();
            return ClientService.GetUserByIP(ip);
        }
        /// <summary>
        /// 更新个人资料
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            ClientService.UpdateUser(user);
        }
        /// <summary>
        /// 添加好友
        /// </summary>
        private void AddFriend()
        {
            List<User> userlist=ClientService.GetUsers();
            if (userlist.Count > 0)
            {
                for (int i = 0; i < userlist.Count; i++)
                {
                    ChatListSubItem subItem = new ChatListSubItem(userlist[i].IP, userlist[i].Name, userlist[i].Signature);
                    subItem.HeadImage = Base.ChageToImage(userlist[i].Picture);
                    subItem.IpAddress = userlist[i].IP;
                    subItem.Status = ChatListSubItem.UserStatus.Online;
                    if (userlist[i].IP != Base.GetAddressIP())
                    {
                        subItem.HeadImage = subItem.GetDarkImage();
                        subItem.Status = ChatListSubItem.UserStatus.OffLine;
                    }
                    listItem.SubItems.AddAccordingToStatus(subItem);
                    listItem.SubItems.Sort();
                }
            }
            //chat.SendToBack();
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        public void ReceviceData()
        {
            IAsyncResult ar = udpclient.BeginReceive(ReceviceCallback, udpclient);
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
            byte[] udpPacketbytes = u.EndReceive(ar, ref remote);
            UdpPacket udpPacketDate = Base.DeSerialize<UdpPacket>(udpPacketbytes);

            if (udpPacketDate.Total - 1 <= number)
            {
                udpPackets.Add(udpPacketDate);
                byte[] bytes = Base.CopyDataUdpPacket(udpPackets);
                udpPackets.Clear();
                number = 0;
                ManageMsg(bytes);
            }
            else
            {
                udpPackets.Add(udpPacketDate);
                number++;
            }
            ReceviceData();
        }
        /// <summary>
        /// 消息处理函数
        /// </summary>
        /// <param name="bytes"></param>
        private void ManageMsg(byte[] bytes)
        {
            try
            {
                byte[] msgHead = new byte[12], msgBody = new byte[bytes.Length - 12];
                Buffer.BlockCopy(bytes, 0, msgHead, 0, 12);
                Buffer.BlockCopy(bytes, 12, msgBody, 0, bytes.Length - 12);
                string keyword = Encoding.Unicode.GetString(msgHead);
                switch (keyword)
                {
                    /*
                     * 用户上线时广播上线信息,收到这个消息将对方加入到联系人中，并返回自己在线信息
                     */
                    case "User::":
                        {
                            try
                            {
                                User user = Base.DeSerialize<User>(msgBody);
                                Thread TSave = new Thread(LoginUser);
                                TSave.IsBackground = true;
                                TSave.Start(user);
                            }
                            catch (Exception)
                            {
                            }
                            break;
                            /*
                             * 收到对方在线信息，将对方加入到联系人中
                             */
                        }
                    case "REPY::":
                        {
                            try
                            {
                                User user = Base.DeSerialize<User>(msgBody);
                                Thread TSave = new Thread(RepyUser);
                                TSave.IsBackground = true;
                                TSave.Start(user);
                            }
                            catch (Exception)
                            { }
                            break;
                        }
                    /*
                     * 接收到信息后保存到数据库（声音提醒）
                     */
                    case "MESG::":
                        {
                            try
                            {
                                string message = Encoding.Unicode.GetString(msgBody, 0, msgBody.Length);
                                Thread TSave = new Thread(SaveChatLog);
                                TSave.IsBackground = true;
                                TSave.Start(message);
                            }
                            catch { }
                            break;
                        }
                    /*
                     * 接收到退出广播，头像变黑
                     */
                    case "QUIT::":
                        {
                            try
                            {
                                User user = Base.DeSerialize<User>(msgBody);
                                Thread TSave = new Thread(QuitUser);
                                TSave.IsBackground = true;
                                TSave.Start(user);
                            }
                            catch { }
                            break;
                        }
                    case "FILE::":
                        {
                            try
                            {
                                string message = Encoding.Unicode.GetString(msgBody, 0, msgBody.Length);
                                Thread TSave = new Thread(SaveFile);
                                TSave.IsBackground = true;
                                TSave.Start(message);
                            }
                            catch { }
                            break;
                        }
                    case "ACEP::":
                        {
                            try
                            {
                                string message = Encoding.Unicode.GetString(msgBody, 0, msgBody.Length);
                                Thread TSave = new Thread(SendFile);
                                TSave.IsBackground = true;
                                TSave.Start(message);
                            }
                            catch { }
                            break;
                        }
                }
            }
            catch(Exception e)
            {
                Base.WriteLog(e.Message);
            }
        }
        /// <summary>
        /// 保存数据到数据库中,并添加到联系人,并返回信息
        /// </summary>
        /// <param name="message"></param>
        private void LoginUser(object message)
        {
            try
            {
                User user = (User)message;
                if (user.IP != Base.GetAddressIP())
                {
                    ChatListSubItem subItem = new ChatListSubItem(user.IP, user.Name, user.Signature);
                    subItem.HeadImage = Base.ChageToImage(user.Picture);
                    subItem.IpAddress = user.IP;
                    subItem.Status = ChatListSubItem.UserStatus.Online;
                    ChatListSubItem[] listSubItem = chat.GetSubItemsByIp(user.IP);
                    if (listSubItem.Length > 0)
                    {
                        listItem.SubItems.Remove(listSubItem[0]);
                        UpdateUser(user);
                    }
                    else
                    {
                        user.Group = 0;
                        ClientService.InsertUser(user);
                    }
                    listItem.SubItems.AddAccordingToStatus(subItem);
                    BoardCast bc = new BoardCast();
                    bc.BCReply(user.IP);
                }
            }
            catch(Exception e)
            {
                Base.WriteLog(e.Message);
            }
        }
        /// <summary>
        /// 保存数据到数据库中,并添加到联系人
        /// </summary>
        /// <param name="message"></param>
        private void RepyUser(object message)
        {
            User user = (User)message;
            if (user.IP != Base.GetAddressIP())
            {
                ChatListSubItem subItem = new ChatListSubItem(user.IP, user.Name, user.Signature);
                subItem.HeadImage = Base.ChageToImage(user.Picture);
                subItem.IpAddress = user.IP;
                subItem.Status = ChatListSubItem.UserStatus.Online;
                ChatListSubItem[] listSubItem = chat.GetSubItemsByIp(user.IP);
                if (listSubItem.Length > 0)
                {
                    listItem.SubItems.Remove(listSubItem[0]);
                    UpdateUser(user);
                }
                else
                {
                    user.Group = 0;
                    ClientService.InsertUser(user);
                }
                listItem.SubItems.AddAccordingToStatus(subItem);
            }
        }
        /// <summary>
        /// 保存聊天记录
        /// </summary>
        /// <param name="message"></param>
        private void SaveChatLog(object message)
        {
            ChatLog chatlog = Base.Decryption(message.ToString());
            User user = ClientService.GetUserByIP(chatlog.Sender);
            string windowsName = "与 " + user.Name + " 对话中";
            IntPtr handle = NativeMethods.FindWindow(null, windowsName);

            if (handle != IntPtr.Zero)
            {
                //对要发送的数据进行封装，直接发string类型，收到会出错
                byte[] sarr = Encoding.Default.GetBytes(message.ToString());
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = message.ToString();
                cds.cbData = len + 1;

                SendMessage(handle, WM_COPYDATA, 0, ref cds);
                NativeMethods.FlashWindow(handle, true);
            }
            else
            {
                chat.GetSubItemsByIp(chatlog.Sender)[0].IsTwinkle = true;
                Thread TShowInfo = new Thread(ShowInformation);
                TShowInfo.Start(chatlog);
            }
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @"Music/msg.wav";
            sp.Play();
            ChatLogService.InsertChatLog(chatlog);
        }
        private void ShowInformation(object chat)
        {
            ChatLog chatlog = (ChatLog)chat;
            Information info = new Information(chatlog);
            info.ShowDialog();
        }
        /// <summary>
        /// 用户退出
        /// </summary>
        /// <param name="message"></param>
        private void QuitUser(object message)
        {
            User user = (User)message;
            ChatListSubItem subItem = new ChatListSubItem(user.IP, user.Name, user.Signature);
            subItem.HeadImage = Base.ChageToImage(user.Picture);
            subItem.HeadImage = subItem.GetDarkImage();
            subItem.IpAddress = user.IP;
            subItem.Status = ChatListSubItem.UserStatus.OffLine;
            if (Base.GetAddressIP() != user.IP)
            {
                ChatListSubItem[] listSubItem=chat.GetSubItemsByIp(user.IP);
                if (listSubItem.Length > 0)
                {
                    listItem.SubItems.Remove(listSubItem[0]);
                    listItem.SubItems.AddAccordingToStatus(subItem);
                }
            }
        }
        /// <summary>
        /// 收到接收图片请求
        /// </summary>
        /// <param name="message"></param>
        public void SaveFile(object message)
        {
            ChatLog chatlog = Base.Decryption(message.ToString());
            User user = ClientService.GetUserByIP(chatlog.Sender);
            string windowsName = "与 " + user.Name + " 对话中";
            IntPtr handle = NativeMethods.FindWindow(null, windowsName);

            if (handle != IntPtr.Zero)
            {
                //对要发送的数据进行封装，直接发string类型，收到会出错
                byte[] sarr = Encoding.Default.GetBytes(message.ToString());
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = message.ToString();
                cds.cbData = len + 1;

                SendMessage(handle, WM_COPYDATA, 0, ref cds);
                NativeMethods.FlashWindow(handle, true);
            }
            else
            {
                chat.GetSubItemsByIp(chatlog.Sender)[0].IsTwinkle = true;
                //FrmChat formRMsg = new FrmChat(msgIP, msgFrom, msgID, msgDetail);
                //formRMsg.Text = "与 " + msgFrom + " 对话中";
                //formRMsg.WindowState = FormWindowState.Minimized;
                //formRMsg.ShowDialog();
                //formRMsg.Show();
                //formRMsg.WindowState = FormWindowState.Minimized;
                //IntPtr newHandle = FindWindow(null, formRMsg.Text);                
                //FlashWindow(newHandle, true);
            }
        }
        /// <summary>
        /// 发送图片
        /// </summary>
        /// <param name="message"></param>
        public void SendFile(object message)
        {
            ChatLog chatlog = Base.Decryption(message.ToString());
            chatlog.Data = Base.AESDecryption(chatlog.Data);
            FileManager sendfileManager = new FileManager(chatlog.Data, chatlog.Sender);
            sendfileManager.TCPSendFile();
        }
    }
}
