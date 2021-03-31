using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Works.Television
{
    // 电视剧
    public class Season
    {
        [Key]
        public int Id { get; set; }

        public int No { get; set; }


        // 1 季 剧情
        public string Plot { get; set; }


        // 2【集合导航】视频文件的路径
        public List<Episode> Episodes { get; set; } = new List<Episode>();


        // 2【引用导航】所属TV
        public int TvId { get; set; }

        public Tv Tv { get; set; }

    }
}
