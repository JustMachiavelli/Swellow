using Swellow.Data.SqlModel.LocalFile;
using Swellow.Data.SqlModel.Works;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Data.SqlModel.View
{
    // Swellow中的媒体库
    public class Library
    {
        public Library()
        {
            PathDirectorys = new List<PathDirectory>();
        }

        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 名称
        public string Name { get; set; }

        // 2 类型
        public string Type { get; set; }

        // 3 预览图路径
        public string PathPicture { get; set; }

        // 4【集合导航】包含的文件夹的路径们
        public List<PathDirectory> PathDirectorys { get; set; }

        // 5【集合导航】包含的影视剧
        public List<Video> Videos { get; set; }
    }
}
