using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Works.Television
{
    public class Episode
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 视频文件的路径
        public string Name { get; set; }

        // 2 第几集，比如“E2”
        public int No { get; set; }

        // 3 其他属性，比如“.720p.修复版”
        public string Propertys { get; set; }

        // 1 集 剧情
        public string Plot { get; set; }

        // 4 【引用导航】所属影视作品
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
