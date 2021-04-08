using Swellow.Shared.SqlModel.MetaData.Media.Film;
using Swellow.Shared.SqlModel.MetaData.Media.Television;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.LocalData
{
    public class CD
    {
        // 0 主键
        [Key]
        public int Id { get; set; }

        [Required]
        // 1【集合导航】第几CD？
        public int No { get; set; } = 0;


        // 2 其他属性，比如“.720p.修复版”；剧集依此区分，电影分片不重要；
        public string? Property { get; set; }


        // 3【引用导航】所属Movie
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }


        // 4【引用导航】所属剧集
        public int? EpisodeId { get; set; }
        public Episode? Episode { get; set; }
    }
}
