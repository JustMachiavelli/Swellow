using Swellow.Shared.Enum;
using Swellow.Shared.Environment;
using Swellow.Shared.SqlModel.MetaData;
using Swellow.Shared.SqlModel.MetaData.Media.Film;
using Swellow.Shared.SqlModel.MetaData.Media.Television;
using Swellow.Shared.SqlModel.MetaData.Middle;
using Swellow.Shared.SqlModel.MetaData.Property;
using Swellow.Shared.SqlModel.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swellow.Shared.SqlModel.Metadata.Media
{
    public class Work : Item
    {
        public Work()
        {

        }


        public Work(string dierctory)
        {
            Directory = dierctory;
            Poster = $"{Directory}/poster.jpg";
        }


        // 8 影视作品类型
        public WorkType Type { get; set; } = WorkType.Mix;


        // 9 时长 = 0;
        public int? Runtime { get; set; }


        // 10 发行年份 = "1900";
        public int? Year { get; set; }


        // 11 剧终年份
        public int? EndYear { get; set; }


        // 12 发行日期 = "1900-01-01";
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }


        // 13 评分 = 0;
        public byte? Score { get; set; }


        // 14 所在文件夹【相对路径】
        public string? Directory { get; set; }


        // 15 Poster
        public string? Poster { get; set; }


        // 16【集合导航】演职人员
        public IEnumerable<WorkCast>? WorkCasts { get; set; } = new List<WorkCast>();
        // 17【集合导航】公司
        public IEnumerable<WorkCompany>? WorkCompanys { get; set; } = new List<WorkCompany>();
        // 18【集合导航】类型
        public IEnumerable<WorkGenre>? WorkGenres { get; set; } = new List<WorkGenre>();
        // 19【集合导航】标签
        public IEnumerable<WorkTag>? WorkTags { get; set; } = new List<WorkTag>();


        // 20【集合导航】所含剧季
        public IEnumerable<Season>? Seasons { get; set; } = new List<Season>();


        // 21【集合导航】所含Movies
        public IEnumerable<Movie>? Movies { get; set; } = new List<Movie>();


        // 22【引用导航】所属系列
        public int? SeriesId { get; set; }
        public Series? Series { get; set; }


        // 23【引用导航】所属library
        public int? LibraryId { get; set; }
        public Library? Library { get; set; }

    }
}
