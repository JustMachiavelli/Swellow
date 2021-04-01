using Swellow.Model.SqlModel.Middle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swellow.Model.SqlModel.Works
{
    public class Work
    {
        // 0 本地编号
        [Key]
        public int Id { get; set; }
        // 2 展示的标题
        public string Display { get; set; }
        // 3 原标题
        public string Title { get; set; }
        // 5 剧情，英语，原始语言
        public string Plot { get; set; }
        // 7 时长
        public int Runtime { get; set; }
        // 8 发行年份
        public string Year { get; set; }
        // 9 发行日期
        public string Date { get; set; }
        // 10 评分
        public byte Score { get; set; }
        // 11 国家地区
        public string Region { get; set; }
        // 12 封面
        public string Fanart { get; set; }
        // 14 海报
        public string Poster { get; set; }
        // 23 豆瓣编号
        public string DoubanId { get; set; }
        // 24 TMDB编号
        public string TmdbId { get; set; }
        // 25 IMDB编号
        public string ImdbId { get; set; }


        // 15【集合导航】演职人员
        public IEnumerable<WorkCast> WorkCasts { get; set; } = new List<WorkCast>();
        // 16【集合导航】制作公司
        public IEnumerable<WorkCompany> WorkCompanys { get; set; } = new List<WorkCompany>();
        // 18【集合导航】类型
        public IEnumerable<WorkGenre> WorkGenres { get; set; } = new List<WorkGenre>();
        // 19【集合导航】标签
        public IEnumerable<WorkTag> WorkTags { get; set; } = new List<WorkTag>();
    }
}
