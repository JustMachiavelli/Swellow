using Swellow.Model.SqlModel.Works;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Episode
{
    public class EpisodeTv
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 【引用导航】所属影视作品
        public int IdTv { get; set; }
        public Tv Tv { get; set; }

        // 2 第几季，比如“S1”
        public string NoSeason { get; set; }

        // 3 第几集，比如“E2”
        public string NoEpisode { get; set; }

        // 4 其他属性，比如“.720p.修复版”
        public string Propertys { get; set; }

        // 5 视频文件的路径
        public string Path { get; set; }
    }
}
