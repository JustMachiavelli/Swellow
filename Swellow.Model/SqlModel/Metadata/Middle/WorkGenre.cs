using Swellow.Shared.SqlModel.MetaData.Media;
using Swellow.Shared.SqlModel.MetaData.Property;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.MetaData.Middle
{
    // <影视，特征>
    public class WorkGenre
    {
        [Required]
        public int WorkId { get; set; }
        public Work? Work { get; set; }


        [Required]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
