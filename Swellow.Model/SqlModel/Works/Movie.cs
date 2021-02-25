using Swellow.Model.SqlModel.Episode;
using System.Collections.Generic;

namespace Swellow.Model.SqlModel.Works
{
    // 电影
    public class Movie : Video
    {
        public Movie()
        {
            EpisodeMovies = new List<EpisodeMovie>();
        }

        // 23 豆瓣编号
        public string IdDouban { get; set; }
        // 24 TMDB编号
        public string IdTmdb { get; set; }
        // 25 IMDB编号
        public string IdImdb { get; set; }

        // 26【集合导航】用户已拥有的CD
        public List<EpisodeMovie> EpisodeMovies { get; set; }
    }
}
