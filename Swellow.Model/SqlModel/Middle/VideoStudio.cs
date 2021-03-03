using Swellow.Shared.SqlModel.Property;
using Swellow.Shared.SqlModel.Works;

namespace Swellow.Shared.SqlModel.Middle
{
    // <影视，制作公司>
    public class VideoStudio
    {
        public int IdVideo { get; set; }
        public Video Video { get; set; }

        public int IdStudio { get; set; }
        public Studio Studio { get; set; }
    }
}
