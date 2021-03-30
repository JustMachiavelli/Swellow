using Swellow.Model.SqlModel.Organization;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Works.Film
{
    public class CD
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 第几集，比如“-cd1”
        public int No { get; set; }

        // 2 其他属性，比如“.720p.修复版”
        public string Propertys { get; set; }

        // 3【引用导航】所属影视作品
        public int MovieId { get; set; }
        public MoviePart Movie { get; set; }
    }
}
