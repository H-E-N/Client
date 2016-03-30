using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GroupData
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int groupID;

        public int GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }
        private string senderIP;

        public string SenderIP
        {
            get { return senderIP; }
            set { senderIP = value; }
        }
        private byte[] data;

        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
