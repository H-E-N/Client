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
        private byte[] groupPicture;

        public byte[] GroupPicture
        {
            get { return groupPicture; }
            set { groupPicture = value; }
        }

        private string groupSignature;

        public string GroupSignature
        {
            get { return groupSignature; }
            set { groupSignature = value; }
        }
        private int group;

        public int Groups
        {
            get { return group; }
            set { group = value; }
        }
    }
}
