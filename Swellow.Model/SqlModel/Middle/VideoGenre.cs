using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
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
