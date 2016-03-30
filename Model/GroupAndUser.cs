using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GroupAndUser
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string userIP;

        public string UserIP
        {
            get { return userIP; }
            set { userIP = value; }
        }
        private int groupID;

        public int GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }
    }
}
