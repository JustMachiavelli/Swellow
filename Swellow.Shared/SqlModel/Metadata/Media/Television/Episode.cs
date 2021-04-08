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
        public int No { get; set; } = 1;


        // 2 集标题
        public string? Title { get; set; }


        // 3 集剧情
        public string? Plot { get; set; }


        // 单集剧照
        public string Fanart { get; set; } = StaticFiles.EpisodeDefaultPosterPath;
        

        // 4 其他属性，比如“.720p.修复版”
        public string? Property { get; set; }


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
