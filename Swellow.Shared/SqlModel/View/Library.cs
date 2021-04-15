using Swellow.Shared.Enum;
using Swellow.Shared.Environment;
using Swellow.Shared.SqlModel.LocalData;
using Swellow.Shared.SqlModel.Metadata.Media;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.View
{
    // Swellow中的媒体库
    public class Library
    {
        // 0 主键 ID
        //[Key]
        public int Id { get; set; }


        //[Required]
        // 1 名称
        public string Name { get; set; } = "新媒体库";


        // 3 预览图路径 【注：需要后期重新依据Id更新】
        public string Fanart { get; set; } = StaticFiles.LibraryDefaultFanart;


        // 4【集合导航】包含的文件夹的路径们
        public IEnumerable<VideoFolder>? VideoFolders { get; set; }


        // 5【集合导航】包含的影视剧
        public IEnumerable<Work>? Works { get; set; }


    }
}
