using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.MetaData.Media.Television
{
    public class Episode
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }


        // 1 第几集，比如“E2”
        public int No { get; set; }


        // 2 集标题
        public string Title { get; set; }


        // 3 集剧情
        public string Plot { get; set; }


        // 4 其他属性，比如“.720p.修复版”
        public string Property { get; set; }


        // 5 可以播放的
        public bool HasResourse { get; set; } = false;


        // 5 【引用导航】所属影视作品
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
