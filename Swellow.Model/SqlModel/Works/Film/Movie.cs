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
        public WorkType Type { get; set; } = WorkType.Movie;


        // 2【引用导航】包含CDs
        public IEnumerable<CD> CDs { get; set; }


        // 3【引用导航】所属library
        public int LibraryId { get; set; }
        public Library Library { get; set; }

    }
}
