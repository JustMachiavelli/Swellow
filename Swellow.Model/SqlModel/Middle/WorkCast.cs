using Swellow.Model.Enum;
using Swellow.Model.SqlModel.People;
using Swellow.Model.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
{
    public class WorkCast
    {
        public int WorkId { get; set; }
        public Work Work { get; set; }


        public int CastId { get; set; }
        public Cast Cast { get; set; }


        public CastType Type { get; set; }

    }
}
