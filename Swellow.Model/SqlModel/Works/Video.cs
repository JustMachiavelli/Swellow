using Swellow.Model.Enum;
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
            VideoDirectors = new List<VideoDirector>();
            VideoStudios = new List<VideoStudio>();
            VideoPublishers = new List<VideoPublisher>();
            VideoGenres = new List<VideoGenre>();
            VideoTags = new List<VideoTag>();
            VideoActors = new List<VideoActor>();
        }

        // 0 本地编号
        [Key]
        public int Id { get; set; }
        // 1 视频类型，电影、电视剧
        public VideoType Type { get; set; }
        // 2 标题
        public string Title { get; set; }
        // 3 原标题
        public string TitleOrigin { get; set; }
        // 4 原标题
        public string TitleOriginZh { get; set; }
        // 5 剧情
        public string Plot { get; set; }
        // 6 剧情，英语等
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
        public string PathFanart
        {
            get
            {
                return $@"/SwellowData/Images/Video/{TitleOriginZh[0]}/{TitleOriginZh[^1]}/{TitleOriginZh}/({Year}/fanart.jpg";
            }
            set { }
        }
        // 14 海报
        public string PathPoster
        {
            get
            {
                return $@"/SwellowData/Images/Video/{TitleOriginZh[0]}/{TitleOriginZh[^1]}/{TitleOriginZh}/({Year}/poster.jpg";
            }
            set { }
        }

        // 15【集合导航】导演
        public List<VideoDirector> VideoDirectors { get; set; }
        // 20【集合导航】演员
        public List<VideoActor> VideoActors { get; set; }
        // 16【集合导航】制作公司
        public List<VideoStudio> VideoStudios { get; set; }
        // 17【集合导航】发行公司
        public List<VideoPublisher> VideoPublishers { get; set; }
        // 18【集合导航】类型
        public List<VideoGenre> VideoGenres { get; set; }
        // 19【集合导航】标签
        public List<VideoTag> VideoTags { get; set; }

        // 21【引用导航】系列
        public int IdSeries { get; set; }
        public Series Series { get; set; }
        // 22【引用导航】所属library
        public int IdLibrary { get; set; }
        public Library Library { get; set; }
    }
}
