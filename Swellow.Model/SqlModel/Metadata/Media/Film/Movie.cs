using Swellow.Model.Enum;
using Swellow.Model.SqlModel.LocalData;
using System.Collections.Generic;

namespace Swellow.Model.SqlModel.MetaData.Media.Film
{
    // 电影
    public class Movie
    {
        // 1 类型  Tv，一般电影
        public MovieType Type { get; set; }


        // 2【集合导航】包含CDs
        public IEnumerable<CD> CDs { get; set; } = new List<CD>();


        // 3【引用导航】所属Mix
        public int? WorkId { get; set; }
        public Work? Work { get; set; }

    }
}
