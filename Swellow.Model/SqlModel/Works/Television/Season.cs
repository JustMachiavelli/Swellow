using Swellow.Model.SqlModel.Works.Part;
using System.Collections.Generic;

namespace Swellow.Model.SqlModel.Works.Television
{
    // 电视剧
    public class Season
    {
        // 1 季 剧情
        public string Plot { get; set; }

        // 26【集合导航】视频文件的路径
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
