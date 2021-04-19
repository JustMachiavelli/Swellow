using Swellow.Shared.ViewModel.Dto;
using System.Collections.Generic;
using Swellow.Shared.SqlModel.MetaData.Property;
using Swellow.Shared.Environment;

namespace Swellow.Shared.ViewModel.Media
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
        public int? Runtime { get; set; }
        public int? Year { get; set; }
        public int? EndYear { get; set; }
        public System.DateTime? Date { get; set; }
        public byte? Score { get; set; }
        public string? Directory { get; set; }
        public string? Poster { get; set; }
        public int? SeriesId { get; set; }
        #endregion
    }
}
