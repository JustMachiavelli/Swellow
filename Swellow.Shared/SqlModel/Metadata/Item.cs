

namespace Swellow.Shared.SqlModel.MetaData
{
    public class Item
    {
        // 0 本地编号
        public int Id { get; set; }
        // 2 展示的标题
        public string? Display { get; set; }

        // 3 原标题
        public string Name { get; set; } = "未知对象";

        // 5 简介
        public string? Outline { get; set; }
        // 11 国家地区
        public string? Region { get; set; }
        // 12 封面
        //public string? Fanart { get; set; }
        // 14 海报
        //public string? Poster { get; set; }
        // 23 豆瓣编号 = "26266893";
        public string? DoubanId { get; set; }
        // 24 TMDB编号 = "535167";
        public string? TmdbId { get; set; }
        // 25 IMDB编号 = "tt7605074";
        public string? ImdbId { get; set; }

    }
}
