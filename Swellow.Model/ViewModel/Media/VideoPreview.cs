using System;
using System.Collections.Generic;
using System.Text;

namespace Swellow.Model.ViewModel.Media
{
    public class VideoPreview
    {
        // 0 影视ID
        public int Id { set; get; }
        // 1 影视标题
        public string Title { set; get; }
        // 2 海报路径 静态文件相对路径
        public string PathPoster { set; get; }
        // 3 发行年份
        public string Year { set; get; }
        // 4 影视类别
        public string Type { set; get; }
    }
}
