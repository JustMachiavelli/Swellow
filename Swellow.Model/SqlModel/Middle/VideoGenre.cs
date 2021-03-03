using Swellow.Shared.SqlModel.Property;
using Swellow.Shared.SqlModel.Works;

namespace Swellow.Shared.SqlModel.Middle
{
    // <影视，特征>
    public class VideoGenre
    {
        public int IdVideo { get; set; }
        public Video Video { get; set; }

        public int IdGenre { get; set; }
        public Genre Genre { get; set; }
    }
}
