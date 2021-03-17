using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istagram
{
    public class UserInfo
    {
        private string _username;
        private int _userid;

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
    }
}
