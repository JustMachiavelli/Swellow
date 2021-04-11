using Swellow.Shared.Enum;
using Swellow.Shared.SqlModel.LocalData;
using Swellow.Shared.SqlModel.Metadata.Media;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.View
{
    // Swellow中的媒体库
    public class Library
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }


        [Required]
        // 1 名称
        public string Name { get; set; } = "新媒体库";


        // 2 类型
        //public LibraryType Type { get; set; } = LibraryType.Mix;


        // 3 预览图路径
        public string Fanart { get; set; } = Environment.StaticFiles.LibraryDefaultFanartPath;


        // 4【集合导航】包含的文件夹的路径们
        public IEnumerable<VideoFolder>? VideoFolders { get; set; }


        // 5【集合导航】包含的影视剧
        public IEnumerable<Work>? Works { get; set; }


    }
}
