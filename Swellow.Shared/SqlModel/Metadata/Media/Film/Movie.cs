using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.LocalData;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.MetaData.Media.Film
{
    // 电影
    public class Movie
    {
        // 1 类型  Tv，一般电影
        public MovieType Type { get; set; } = MovieType.Common;


        // 2【集合导航】包含CDs
        public IEnumerable<CD>? CDs { get; set; } = new List<CD>();


        // 5 可以播放的
        public bool HasResourse
        {
            get { return CDs == null; }
            set { }
        }


        // 3【引用导航】所属Work
        public int? WorkId { get; set; }
        public Work? Work { get; set; }

    }
}
