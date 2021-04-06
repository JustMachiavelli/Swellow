using Swellow.Model.Enum;
using Swellow.Model.SqlModel.MetaData.Media.Film;
using Swellow.Model.SqlModel.MetaData.Media.Television;
using Swellow.Model.SqlModel.MetaData.Middle;
using Swellow.Model.SqlModel.MetaData.Property;
using Swellow.Model.SqlModel.View;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.MetaData.Media
{
    public class Work : Item
    {
        // 1 类型
        public WorkType Type { get; set; } = WorkType.Mix;
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
        // 16【集合导航】制作公司
        public IEnumerable<WorkCompany>? WorkCompanys { get; set; } = new List<WorkCompany>();
        // 18【集合导航】类型
        public IEnumerable<WorkGenre>? WorkGenres { get; set; } = new List<WorkGenre>();
        // 19【集合导航】标签
        public IEnumerable<WorkTag>? WorkTags { get; set; } = new List<WorkTag>();


        // 1【集合导航】所含剧季
        public IEnumerable<Season>? Seasons { get; set; } = new List<Season>();

        // 2【集合导航】所属library
        public IEnumerable<Movie>? Movies { get; set; } = new List<Movie>();


        // 【引用导航】所属系列
        public int? SeriesId { get; set; }
        public Series? Series { get; set; }


        // 3【引用导航】所属library
        public int? LibraryId { get; set; }
        public Library? Library { get; set; }
    }
}
