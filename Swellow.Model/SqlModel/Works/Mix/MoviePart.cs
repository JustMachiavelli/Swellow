using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Middle;
using Swellow.Model.SqlModel.Works.Mix;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Works.Film
{
    // 电影
    public class MoviePart : Work
    {
        // 1 类型  Tv，一般电影、OVA、SP
        public MovieType Type { get; set; }

        // 2【集合导航】用户已拥有的CD
        public List<CD> CDs { get; set; } = new List<CD>();

        // 3【引用导航】系列
        public int TvWithMovieId { get; set; }
        public TvWithMovie TvWithMovie { get; set; }
    }
}
