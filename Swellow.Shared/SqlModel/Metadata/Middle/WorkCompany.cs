using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.SqlModel.MetaData.Organization;

namespace Swellow.Shared.SqlModel.MetaData.Middle
{
    // <影视，制作公司>
    public class WorkCompany
    {
        //[Required]
        public int WorkId { get; set; }
        public Work? Work { get; set; }

        //[Required]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }


        public CompanyType Type { get; set; } = CompanyType.Producer;


    }
}
