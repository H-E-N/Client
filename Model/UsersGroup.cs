using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class UsersGroup
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
    }
}
