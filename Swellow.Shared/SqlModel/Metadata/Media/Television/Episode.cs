using Swellow.Shared.Environment;
using Swellow.Shared.SqlModel.LocalData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.MetaData.Media.Television
{
    public class Episode
    {
        public Episode(string dierctory)
        {
            Directory = dierctory;
            Fanart = $"{Directory}/fanart.jpg";
        }


        // 0 主键 ID
        //[Key]
        public int Id { get; set; }

        //[Required]
        // 1 第几集，比如“E2”
        public int No { get; set; } = 0;


        // 2 集标题
        public string? Title { get; set; }


        // 3 集剧情
        public string? Plot { get; set; }


        // 上映日期
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }


        // 11 所在文件夹【相对路径】
        public string Directory { get; set; }


        // 12 Fanart
        public string Fanart { get; set; }


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
