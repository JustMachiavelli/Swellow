using Swellow.Model.SqlModel.People;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
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
