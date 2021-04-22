using System.Collections.Generic;
using Swellow.Shared.SqlModel.Metadata.Property;
using Swellow.Shared.Environment;
using Swellow.Shared.Enum;

namespace Swellow.Shared.Dto.Metadata.Media
{
    public class WorkDetail
    {
        #region Item属性
        public int Id { get; set; }
        public string Name { get; set; } = "未知对象";
        public string? Outline { get; set; }
        public string? Region { get; set; }
        public string? DoubanId { get; set; }
        public string? TmdbId { get; set; }
        public string? ImdbId { get; set; }
        #endregion


        #region Work扩展
        public WorkType Type { get; set; } = WorkType.Mix;
        public int? Runtime { get; set; }
        public int? Year { get; set; }
        public int? EndYear { get; set; }
        public System.DateTime? Date { get; set; }
        public string? Score { get; set; }
        public string? Directory { get; set; }
        public string? Poster { get; set; }
        public string? Fanart { get; set; }
        public int? SeriesId { get; set; }
        #endregion
    }
}
