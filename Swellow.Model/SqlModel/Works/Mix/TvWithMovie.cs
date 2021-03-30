using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Middle;
using Swellow.Model.SqlModel.View;
using Swellow.Model.SqlModel.Works.Film;
using Swellow.Model.SqlModel.Works.Television;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swellow.Model.SqlModel.Works.Mix
{
    public class TvWithMovie : Work
    {
        // 1 类型  Tv，一般电影、OVA、SP
        public WorkType Type { get; set; } = WorkType.Mix;

        // 2【引用导航】所属library
        public int LibraryId { get; set; }
        public Library Library { get; set; }

        public IEnumerable<Season> Seasons { get; set; } = new List<Season>();

        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();


    }
}
