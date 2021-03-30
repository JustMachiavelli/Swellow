using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
{
    // <影视，特征>
    public class WorkGenre
    {
        public int VideoId { get; set; }
        public Work Video { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
