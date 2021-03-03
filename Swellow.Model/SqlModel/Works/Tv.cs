using Swellow.Shared.SqlModel.Episode;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.Works
{
    // 电视剧
    public class Tv : Video
    {
        public Tv()
        {
            EpisodeTvs = new List<EpisodeTv>();
        }

        // 23 豆瓣编号
        public string IdDouban { get; set; }
        // 24 TMDB编号
        public string IdTmdb { get; set; }
        // 25 IMDB编号
        public string IdImdb { get; set; }

        // 26【集合导航】视频文件的路径
        public List<EpisodeTv> EpisodeTvs { get; set; }
    }
}
