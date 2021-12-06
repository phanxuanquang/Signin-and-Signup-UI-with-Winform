using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    class account
    {
        private string username;
        private string password;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public account()
        {
            username = "";
            password = "";
        }
        public account(string user, string pass)
        {
            username = user;
            password = pass;
        }
        public bool isValid(string user, string pass)
        {
            if (user == username && pass == password)
                return true;
            return false;
        }
    }
}
