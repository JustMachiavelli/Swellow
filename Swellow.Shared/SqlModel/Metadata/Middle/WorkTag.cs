using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.SqlModel.MetaData.Property;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.MetaData.Middle
{
    // <影视，标签>
    public class WorkTag
    {
        [Required]
        public int WorkId { get; set; }
        [Required]
        public Work? Work { get; set; }


        [Required]
        public int TagId { get; set; }
        [Required]
        public Tag? Tag { get; set; }


        // 加权值，出现在该作品中的次数
        public int Weighting { get; set; } = 0;


    }
}
