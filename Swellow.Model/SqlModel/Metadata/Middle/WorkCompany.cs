using Swellow.Model.Enum;

namespace Swellow.Model.SqlModel.MetaData.Middle
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
