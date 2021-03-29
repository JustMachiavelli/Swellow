using Swellow.Model.ViewModel.Dto;
using Swellow.Shared.SqlModel.Property;
using System.Collections.Generic;

namespace Swellow.Model.ViewModel.Media
{
    public class MovieDetail
    {
        public string Display { get; set; }
        public string Year { get; set; }
        public byte Score { get; set; }
        public string Fanart { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string DoubanId { get; set; }
        public string TmdbId { get; set; }
        public string ImdbId { get; set; }

        public IEnumerable<CastPreview> Casts { get; set; } = new List<CastPreview>();

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
