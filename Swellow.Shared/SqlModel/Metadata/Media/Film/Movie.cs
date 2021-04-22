using Swellow.Shared.Enum;
using Swellow.Shared.Environment;
using Swellow.Shared.SqlModel.LocalData;
using Swellow.Shared.SqlModel.Metadata.Media;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.Metadata.Media.Film
{
    // 电影
    public class Movie : Item
    {
        public Movie()
        {

        }


        public Movie(string dierctory)
        {
            Directory = dierctory;
            Poster = $"{dierctory}/poster.jpg";
        }


        // 1 类型 Movie，一般电影
        public MovieType Type { get; set; } = MovieType.Common;


        // 2 在剧场版系列中No
        public int No { get; set; }


        // 7 时长 = 0;
        public int? Runtime { get; set; }


        // 8 发行年份 = "1900";
        public int? Year { get; set; }


        // 9 发行日期 = "1900-01-01";
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }


        // 10 评分 = 0;
        public byte? Score { get; set; }


        // 11 所在文件夹【相对路径】
        public string? Directory { get; set; }


        // 12 Poster
        public string? Poster { get; set; }


        // 3【集合导航】包含CDs
        public IEnumerable<CD>? CDs { get; set; } = new List<CD>();


        // 4【引用导航】所属Work
        public int? WorkId { get; set; }
        public Work? Work { get; set; }

    }
}
