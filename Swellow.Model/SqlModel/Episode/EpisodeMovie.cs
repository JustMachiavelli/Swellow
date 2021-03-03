using Swellow.Shared.SqlModel.Works;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.Episode
{
    public class EpisodeMovie
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1【引用导航】所属影视作品
        public int IdMovie { get; set; }
        public Movie Movie { get; set; }

        // 2 第几集，比如“-cd1”
        public string NoEpisode { get; set; }
        // 3 其他属性，比如“.720p.修复版”
        public string Propertys { get; set; }

        // 4 视频文件的路径
        public string Path { get; set; }
    }
}
