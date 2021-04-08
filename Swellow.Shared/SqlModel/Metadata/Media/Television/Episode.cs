using Swellow.Shared.Environment;
using Swellow.Shared.SqlModel.LocalData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.MetaData.Media.Television
{
    public class Episode
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        [Required]
        // 1 第几集，比如“E2”
        public int No { get; set; } = 0;


        // 2 集标题
        public string? Title { get; set; }


        public string Display { get; set; } = "未知影视作品 - S00E00 - 未知剧集标题";


        // 3 集剧情
        public string? Plot { get; set; }


        // 单集剧照
        //public string Fanart { get; set; } = StaticFiles.EpisodeDefaultPosterPath;


        // 【集合导航】包含CDs
        public IEnumerable<CD>? CDs { get; set; } = new List<CD>();


        // 5 可以播放的
        public bool HasResourse
        {
            get { return CDs == null; }
            set { }
        }


        // 5 【引用导航】所属影视作品
        public int? SeasonId { get; set; }
        public Season? Season { get; set; }
    }
}
