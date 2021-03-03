using Swellow.Shared.SqlModel.People;
using Swellow.Shared.SqlModel.Works;

namespace Swellow.Shared.SqlModel.Middle
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
