using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
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
        //private string picture;

        //public string Picture
        //{
        //    get { return picture; }
        //    set { picture = value; }
        //}
        private byte[] picture;

        public byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        private string signature;

        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }
    }
}
