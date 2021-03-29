using Swellow.Model.Enum;
using Swellow.Shared.SqlModel.People;
using Swellow.Shared.SqlModel.Works;

namespace Swellow.Model.SqlModel.Middle
{
    public class VideoCast
    {
        public int VideoId { get; set; }

        public Video Video { get; set; }


        public int CastId { get; set; }

        public Cast Cast { get; set; }

        public CastType Type { get; set; }

    }
}
