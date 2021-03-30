using Swellow.Model.Enum;
using Swellow.Model.SqlModel.People;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
{
    public class WorkCast
    {
        public int VideoId { get; set; }

        public Work Video { get; set; }


        public int CastId { get; set; }

        public Cast Cast { get; set; }

        public CastType Type { get; set; }

    }
}
