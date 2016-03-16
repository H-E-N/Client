using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        private string ip;

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string picture;

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }
    }
}
