using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
{
    // <影视，标签>
    public class VideoTag
    {
        public int IdVideo { get; set; }
        public Video Video { get; set; }

        public int IdTag { get; set; }
        public Tag Tag { get; set; }
    }
}
