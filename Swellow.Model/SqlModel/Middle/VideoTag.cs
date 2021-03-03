using Swellow.Shared.SqlModel.Property;
using Swellow.Shared.SqlModel.Works;

namespace Swellow.Shared.SqlModel.Middle
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
