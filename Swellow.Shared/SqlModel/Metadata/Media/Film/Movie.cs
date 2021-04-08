using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.LocalData;
using Swellow.Shared.SqlModel.MetaData.Media.Television;
using Swellow.Shared.SqlModel.MetaData.Middle;
using Swellow.Shared.SqlModel.MetaData.Property;
using Swellow.Shared.SqlModel.View;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.MetaData.Media.Film
{
    // 电影
    public class Movie : Item
    {
        // 7 时长 = 0;
        public int? Runtime { get; set; }

        // 8 发行年份 = "1900";
        public string? Year { get; set; }

        // 9 发行日期 = "1900-01-01";
        public string? Date { get; set; }

        // 10 评分 = 0;
        public byte? Score { get; set; }

        // 15【集合导航】演职人员
        public IEnumerable<WorkCast>? WorkCasts { get; set; } = new List<WorkCast>();
        // 16【集合导航】公司
        public IEnumerable<WorkCompany>? WorkCompanys { get; set; } = new List<WorkCompany>();
        // 18【集合导航】类型
        public IEnumerable<WorkGenre>? WorkGenres { get; set; } = new List<WorkGenre>();
        // 19【集合导航】标签
        public IEnumerable<WorkTag>? WorkTags { get; set; } = new List<WorkTag>();



        // 1 类型  Tv，一般电影
        public MovieType Type { get; set; } = MovieType.Common;


        // 2【集合导航】包含CDs
        public IEnumerable<CD>? CDs { get; set; } = new List<CD>();


        // 5 可以播放的
        public bool HasResourse
        {
            get { return CDs == null; }
            set { }
        }


        // 3【引用导航】所属Work
        public int? WorkId { get; set; }
        public Work? Work { get; set; }

    }
}
