using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
{
    // <影视，标签>
    public class WorkTag
    {
        public int VideoId { get; set; }
        public Work Video { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
