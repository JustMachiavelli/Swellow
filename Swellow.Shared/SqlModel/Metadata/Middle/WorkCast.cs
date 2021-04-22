using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.Metadata.Media;
using Swellow.Shared.SqlModel.Metadata.Person;

namespace Swellow.Shared.SqlModel.Metadata.Middle
{
    public class WorkCast
    {
        //[Required]
        public int WorkId { get; set; }
        public Work? Work { get; set; }


        //[Required]
        public int CastId { get; set; }
        public Cast? Cast { get; set; }


        public CastType Type { get; set; } = CastType.Actor;

    }
}
