using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Works.Television
{
    // 电视剧
    public class Season
    {
        [Key]
        public int Id { get; set; }

        // 1 第几季？
        public int No { get; set; }


        // 2 剧情简介
        public string Plot { get; set; }


        // 3【集合导航】视频文件的路径
        public IEnumerable<Episode> Episodes { get; set; } = new List<Episode>();


        // 4【引用导航】所属TV
        public int TvId { get; set; }

        public Tv Tv { get; set; }


        // 5【引用导航】所属Mix
        public int MixId { get; set; }

        public Mix Mix { get; set; }

    }
}
