using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istagram.Entities
{
    public class Log
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public DateTime LogInTime { get; set; }
        public DateTime LogOutTime { get; set; }
        public override string ToString()
        {
            return UserID + " " + LogInTime + " " + LogOutTime;
        }
    }
}
