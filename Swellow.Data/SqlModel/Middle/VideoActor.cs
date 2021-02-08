using Swellow.Data.SqlModel.People;
using Swellow.Data.SqlModel.Works;

namespace Swellow.Data.SqlModel.Middle
{
    // <影视，演职人员>
    public class VideoActor
    {
        public int IdVideo { get; set; }
        public Video Video { get; set; }

        public int IdCast { get; set; }
        public Cast Cast { get; set; }
    }
}
