

namespace Swellow.Shared.SqlModel.MetaData
{
    public class Item
    {
        // 0 本地编号
        public int Id { get; set; }


        // 2 原标题
        public string Name { get; set; } = "未知对象";


        // 3 简介
        public string? Outline { get; set; }


        // 4 国家地区
        public string? Region { get; set; }


        // 5 豆瓣编号 = "26266893";
        public string? DoubanId { get; set; }
        // 6 TMDB编号 = "535167";
        public string? TmdbId { get; set; }
        // 7 IMDB编号 = "tt7605074";
        public string? ImdbId { get; set; }

    }
}
