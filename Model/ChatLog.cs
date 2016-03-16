using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class ChatLog
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string sender;
        /// <summary>
        /// 发送者
        /// </summary>
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        private string receiver;
        /// <summary>
        /// 接收者
        /// </summary>
        public string Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }
        private string time;
        /// <summary>
        /// 时间
        /// </summary>
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        private string data;
        /// <summary>
        /// 数据
        /// </summary>
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
