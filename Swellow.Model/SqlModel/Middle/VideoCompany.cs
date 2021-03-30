using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
{
    // <影视，制作公司>
    public class WorkCompany
    {
        public int VideoId { get; set; }
        public Work Video { get; set; }

        public int StudioId { get; set; }
        public Company Studio { get; set; }

        public CompanyType Type { get; set; }
    }
}
