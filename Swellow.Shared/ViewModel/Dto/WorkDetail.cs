using Swellow.Shared.ViewModel.Dto;
using System.Collections.Generic;
using Swellow.Shared.SqlModel.MetaData.Property;
using Swellow.Shared.Environment;

namespace Swellow.Shared.ViewModel.Media
{
    public class WorkDetail
    {
        // 0 影视ID
        public int Id { get; set; }


        // 2 标题
        public string? Display { get; set; }


        // 4 发行年份
        public int? Year { get; set; }


        // 5 剧终年份
        public int? EndYear { get; set; }


        public byte Score { get; set; }


        public string? Plot { get; set; }


        public string? DoubanId { get; set; }
        public string? TmdbId { get; set; }
        public string? ImdbId { get; set; }


        // 11 所在文件夹【相对路径】
        public string? Directory { get; set; }


        // 6 Fanart
        public string? Poster { get; set; }


        public IEnumerable<CastPreview> Casts { get; set; } = new List<CastPreview>();

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();


    }
}
