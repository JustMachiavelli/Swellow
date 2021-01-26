using Swellow.Data.SqlModel.Property;
using Swellow.Data.SqlModel.Works;

namespace Swellow.Data.SqlModel.Middle
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
