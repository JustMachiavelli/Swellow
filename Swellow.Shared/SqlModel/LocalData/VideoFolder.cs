using Swellow.Shared.Environment;
using Swellow.Shared.SqlModel.View;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.LocalData
{
    // 媒体库所包含的文件夹
    public class VideoFolder
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        [Required]
        // 1 绝对路径
        public string Path { get; set; } = StaticFiles.DefaultDirectory;

        // 2 【引用导航】所属媒体库
        public int? LibraryId { get; set; }
        public Library? Library { get; set; }
    }
}
