using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.LocalData;
using Swellow.Shared.SqlModel.Metadata.Media;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.MetaData.Media.Film
{
    // 电影
    public class Movie : Item
    {
        // 1 类型 Movie，一般电影
        public MovieType Type { get; set; } = MovieType.Common;


        // 7 时长 = 0;
        public int? Runtime { get; set; }

        // 8 发行年份 = "1900";
        public string? Year { get; set; }

        // 9 发行日期 = "1900-01-01";
        public string? Date { get; set; }

        // 10 评分 = 0;
        public byte? Score { get; set; }


        // 3【集合导航】包含CDs
        public IEnumerable<CD>? CDs { get; set; } = new List<CD>();


        // 4【引用导航】所属Work
        public int? WorkId { get; set; }
        public Work? Work { get; set; }

    }
}
