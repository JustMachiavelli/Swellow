using Swellow.Data.SqlModel.Property;
using Swellow.Data.SqlModel.Works;

namespace Swellow.Data.SqlModel.Middle
{
    // <影视作品，发行商>
    public class VideoPublisher
    {
        public int IdVideo { get; set; }
        public Video Video { get; set; }

        public int IdPublisher { get; set; }
        public Publisher Publisher { get; set; }
    }
}
