using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istagram.Entities
{
    public class Image
    {
        public int ImageID { get; set; }

        public int UserID { get; set; }

        public int TagID { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public int LikeCount { get; set; }
    }
}
