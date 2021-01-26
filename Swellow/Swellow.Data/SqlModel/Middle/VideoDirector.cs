using Swellow.Data.SqlModel.People;
using Swellow.Data.SqlModel.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swellow.Data.SqlModel.Middle
{
    // <影视，导演>
    public class VideoDirector
    {
        public int IdVideo { get; set; }
        public Video Video { get; set; }

        public int IdCast { get; set; }
        public Cast Cast { get; set; }
    }
}
