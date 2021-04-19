using Swellow.Shared.Environment;
using Swellow.Shared.SqlModel.Metadata.Media;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.MetaData.Media.Television
{
    // 电视剧
    public class Season
    {
        public Season()
        {

        }

        public Season(string dierctory)
        {
            Directory = dierctory;
            Poster = $"{dierctory}/poster.jpg";
        }


        //[Key]
        public int Id { get; set; }


        //[Required]
        // 1 第几季？
        public int No { get; set; } = 1;


        // 2 剧情简介
        public string? Outline { get; set; }


        // 3 经历年份 = "1996";
        public int? Year { get; set; }
        public int? EndYear { get; set; }


        // 11 所在文件夹【相对路径】
        public string? Directory { get; set; }


        // 12 Poster
        public string? Poster { get; set; }


        // 3【集合导航】视频文件的路径
        public IEnumerable<Episode>? Episodes { get; set; } = new List<Episode>();


        // 4【引用导航】所属Work
        public int? WorkId { get; set; }
        public Work? Work { get; set; }

    }
}
