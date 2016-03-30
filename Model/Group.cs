using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Group
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string groupName;

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        private byte[] roupPicture;

        public byte[] RoupPicture
        {
            get { return roupPicture; }
            set { roupPicture = value; }
        }
        private string groupSignaure;

        public string GroupSignaure
        {
            get { return groupSignaure; }
            set { groupSignaure = value; }
        }
        private int group;

        public int Groups
        {
            get { return group; }
            set { group = value; }
        }
    }
}
