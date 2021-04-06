using Swellow.Model.SqlModel.MetaData.Media.Film;
using Swellow.Model.SqlModel.MetaData.Media.Television;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.LocalData
{
    public class CD
    {
        // 0 主键
        [Key]
        public int Id { get; set; }


        // 1【集合导航】第几CD？
        public int No { get; set; } = 0;


        // 2 其他属性，比如“.720p.修复版”
        public string? Property { get; set; }


        // 3【引用导航】所属Movie
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }


        public int? EpisodeId { get; set; }
        public Episode? Episode { get; set; }
    }
}
