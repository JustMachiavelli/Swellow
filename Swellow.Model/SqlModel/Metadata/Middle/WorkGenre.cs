using Swellow.Model.SqlModel.Property;

namespace Swellow.Model.SqlModel.MetaData.Middle
{
    // <影视，特征>
    public class WorkGenre
    {
        public int WorkId { get; set; }
        public Work Work { get; set; }


        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
