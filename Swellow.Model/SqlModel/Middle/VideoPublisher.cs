using Swellow.Shared.SqlModel.Property;
using Swellow.Shared.SqlModel.Works;

namespace Swellow.Shared.SqlModel.Middle
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
