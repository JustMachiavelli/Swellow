using System;
using System.Collections.Generic;
using System.Text;

namespace Swellow.Shared.Dto.Metadata.Media.Film
{
    public class MoviePreview
    {
        #region Item属性
        public int Id { get; set; }
        public string Name { get; set; } = "未知对象";
        //public string? Outline { get; set; }
        //public string? DoubanId { get; set; }
        //public string? TmdbId { get; set; }
        //public string? ImdbId { get; set; }
        #endregion


        #region Movie扩展
        public int No { get; set; }
        //public int? Runtime { get; set; }
        public int? Year { get; set; }
        public System.DateTime? Date { get; set; }
        public byte? Score { get; set; }
        //public string? Directory { get; set; }
        public string? Poster { get; set; }
        #endregion
    }
}
