using Swellow.Model.Enum;
using Swellow.Shared.SqlModel.Property;
using Swellow.Shared.SqlModel.Works;

namespace Swellow.Shared.SqlModel.Middle
{
    // <影视，制作公司>
    public class VideoCompany
    {
        public int VideoId { get; set; }
        public Video Video { get; set; }

        public int StudioId { get; set; }
        public Company Studio { get; set; }

        public CompanyType Type { get; set; }
    }
}
