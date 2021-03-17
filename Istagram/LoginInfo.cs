using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istagram
{
    public static class LoginInfo
    {
        private static UserInfo _userinfo;

        private static int _logID;

        public static UserInfo UserInfo
        {
            get { return _userinfo; }
            set { _userinfo = value; }
        }

        public static int LogID
        {
            get { return _logID; }
            set { _logID = value; }
        }
    }
}
