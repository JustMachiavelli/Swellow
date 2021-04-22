using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.SqlModel.Metadata.Property;

namespace Swellow.Shared.SqlModel.Metadata.Middle
{
    // <影视，标签>
    public class WorkTag
    {
        //[Required]
        public int WorkId { get; set; }
        //[Required]
        public Work? Work { get; set; }


        //[Required]
        public int TagId { get; set; }
        //[Required]
        public Tag? Tag { get; set; }


    }
}
