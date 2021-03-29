using Swellow.Shared.SqlModel.Episode;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.Works
{
    // 电影
    public class Movie : Video
    {
        public Movie()
        {
            EpisodeMovies = new List<EpisodeMovie>();
        }

        // 23 豆瓣编号
        public string DoubanId { get; set; }
        // 24 TMDB编号
        public string TmdbId { get; set; }
        // 25 IMDB编号
        public string ImdbId { get; set; }

        // 26【集合导航】用户已拥有的CD
        public List<EpisodeMovie> EpisodeMovies { get; set; }
    }
}
