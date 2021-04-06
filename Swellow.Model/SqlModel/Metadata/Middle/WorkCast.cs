using Swellow.Model.Enum;
using Swellow.Model.SqlModel.People;

namespace Swellow.Model.SqlModel.MetaData.Middle
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
