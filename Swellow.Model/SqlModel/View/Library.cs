using Swellow.Model.Enum;
using Swellow.Model.SqlModel.LocalFile;
using Swellow.Model.SqlModel.Works;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.View
{
    // Swellow中的媒体库
    public class Library
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }


        // 1 名称
        public string Name { get; set; }


        // 2 类型
        public LibraryType Type { get; set; }


        // 3 预览图路径
        public string Fanart { get; set; }


        // 4【集合导航】包含的文件夹的路径们
        public IEnumerable<MeidaDirectory> Directorys { get; set; } = new List<MeidaDirectory>();


        // 5【集合导航】包含的影视剧
        public IEnumerable<Work> Works { get; set; } = new List<Work>();
    }
}
