using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Middle;
using Swellow.Model.SqlModel.View;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Works.Television
{
    // 电视剧
    public class Tv : Work
    {
        // 1 类型  Tv，一般电影、OVA、SP
        public WorkType Type { get; set; } = WorkType.Tv;


        // 1【集合导航】剧季
        public IEnumerable<Season> Seasons { get; set; } = new List<Season>();


        // 22【引用导航】所属library
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
