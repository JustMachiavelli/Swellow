using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Middle;
using Swellow.Model.SqlModel.View;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Works.Film
{
    // 电影
    public class Movie : Work
    {
        // 1 类型  Tv，一般电影
        public MovieType Type { get; set; }


        // 2 系列的第几集
        public int No { get; set; }


        // 3【集合导航】包含CDs
        public IEnumerable<CD> CDs { get; set; } = new List<CD>();


        // 4【引用导航】所属library
        public int LibraryId { get; set; }
        public Library Library { get; set; }


        // 5【引用导航】所属Mix
        public int MixId { get; set; }
        public Mix Mix { get; set; }

    }
}
