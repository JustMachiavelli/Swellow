using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Middle;
using Swellow.Shared.SqlModel.Middle;
using Swellow.Shared.SqlModel.Property;
using Swellow.Shared.SqlModel.View;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.Works
{
    public class Video
    {
        public Video()
        {
            VideoCompanys = new List<VideoCompany>();
            VideoGenres = new List<VideoGenre>();
            VideoTags = new List<VideoTag>();
            VideoCasts = new List<VideoCast>();
        }

        // 0 本地编号
        [Key]
        public int Id { get; set; }
        // 1 视频类型，电影、电视剧
        public VideoType Type { get; set; }
        // 2 展示的标题
        public string Display { get; set; }
        // 3 所在文件夹名称
        public string Folder { get; set; }
        // 3 原标题
        public string Title { get; set; }
        // 4 中文标题
        public string TitleOrigin { get; set; }
        // 5 剧情，英语，原始语言
        public string Plot { get; set; }
        // 6 剧情
        public string PlotOrigin { get; set; }
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

        // 15【集合导航】演职人员
        public List<VideoCast> VideoCasts { get; set; }
        // 16【集合导航】制作公司
        public List<VideoCompany> VideoCompanys { get; set; }
        // 18【集合导航】类型
        public List<VideoGenre> VideoGenres { get; set; }
        // 19【集合导航】标签
        public List<VideoTag> VideoTags { get; set; }

        // 21【引用导航】系列
        public int SeriesId { get; set; }
        public Series Series { get; set; }
        // 22【引用导航】所属library
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
