
namespace Swellow.Web.ModelComponents
{
    public class VideoPreview
    {
        // 0 影视ID
        public int Id { set; get; }
        // 1 影视标题
        public string Title { set; get; }
        // 2 海报路径 相对静态
        public string PathPoster { set; get; }
        // 3 年份
        public string Year { set; get; }
        // 4 视频类别
        public string Type { set; get; }
    }
}
