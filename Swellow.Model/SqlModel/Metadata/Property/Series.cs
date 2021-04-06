using Swellow.Model.SqlModel.MetaData.Media;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.MetaData.Property
{
    public class Series
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        [Required]
        // 1 名称
        public string Name { get; set; } = "未知系列";


        // 2【集合导航】影片
        public IEnumerable<Work>? Works { get; set; } = new List<Work>();
    }
}
