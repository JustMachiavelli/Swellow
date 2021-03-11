using Swellow.Shared.SqlModel.Property;
using System.Collections.Generic;

namespace Swellow.Model.ViewModel.Media
{
    public class MovieDetail
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public byte Score { get; set; }
        public string PathFanart { get; set; }
        public string PathPoster { get; set; }
        public string Plot { get; set; }
        public string IdDouban { get; set; }
        public string IdTmdb { get; set; }
        public string IdImdb { get; set; }

        public IEnumerable<CastPreview> Actors { get; set; } = new List<CastPreview>();

        public IEnumerable<CastPreview> Directors { get; set; } = new List<CastPreview>();

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
