using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BoardCast
    {
        private int port = 8001;
        User user;
        public BoardCast()
        {
            user = new User();
            user.IP = Base.GetAddressIP();
            user = ClientService.GetUser(user.IP);
        }
        /// <summary>
        /// 收到上线通知后的回复
        /// </summary>
        /// <param name="ipReply"></param>
        public void BCReply(string ipReply)
        {
            IPAddress remoteIP;
            if(IPAddress.TryParse(ipReply,out remoteIP)==false)
            {}
            else
            {
                IPEndPoint iep = new IPEndPoint(remoteIP, port);
                byte[] bytes = Base.Serialize<User>(user);
                bytes=CopyTOByte("REPY::",bytes);
                SendBoardCast(iep, bytes);
            }
        }
        /// <summary>
        /// 上线广播
        /// </summary>
        public void LoginBoardCast()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, port);
            byte[] bytes = Base.Serialize<User>(user);
            bytes = CopyTOByte("User::", bytes);
            SendBoardCast(iep, bytes);
        }
        /// <summary>
        /// 下线广播
        /// </summary>
        public void OutLoginBoardCast()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, port);
            byte[] bytes = Base.Serialize<User>(user);
            bytes = CopyTOByte("QUIT::", bytes);
            SendBoardCast(iep, bytes);
        }
        /// <summary>
        /// 发送聊天消息
        /// </summary>
        /// <param name="iep"></param>
        /// <param name="message"></param>
        public void SendMsg(IPEndPoint iep,string message)
        {
            byte[] bytes=Encoding.Unicode.GetBytes(message);
            bytes=CopyTOByte("MESG::",bytes);
            SendBoardCast(iep, bytes);
        }
        /// <summary>
        /// 发送广播
        /// </summary>
        /// <param name="iep"></param>
        /// <param name="bytes"></param>
        private void SendBoardCast(IPEndPoint iep,byte[] bytes)
        {
            UdpClient udpclient = new UdpClient();
            try
            {
                IAsyncResult ar = udpclient.BeginSend(bytes, bytes.Length, iep, SendCallback, udpclient);
            }
            catch { }
        }
        /// <summary>
        /// 广播回调函数
        /// </summary>
        /// <param name="ar"></param>
        private void SendCallback(IAsyncResult ar)
        {
            UdpClient udpclient = (UdpClient)ar.AsyncState;
            udpclient.EndSend(ar);
            udpclient.Close();
        }
        private byte[] CopyTOByte(string str,byte[]bytes)
        {
            byte[] strByte = Encoding.Unicode.GetBytes(str);
            List<byte> bytelist = new List<byte>();
            bytelist.AddRange(strByte);
            bytelist.AddRange(bytes);
            bytes = new byte[bytelist.Count];
            bytelist.CopyTo(bytes);
            return bytes;
        }
    }
}
