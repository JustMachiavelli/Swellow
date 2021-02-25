using Swellow.Model.SqlModel.View;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.LocalFile
{
    // 媒体库所包含的文件夹
    public class PathDirectory
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 绝对路径
        public string Path { get; set; }

        // 2 【引用导航】所属媒体库
        public int IdLibrary { get; set; }
        public Library Library { get; set; }
    }
}
