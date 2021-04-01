using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Property;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
{
    // <影视，制作公司>
    public class WorkCompany
    {
        public int WorkId { get; set; }
        public Work Work { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }


        public CompanyType Type { get; set; }
    }
}
