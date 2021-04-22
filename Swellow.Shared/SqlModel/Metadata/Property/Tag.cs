using Swellow.Shared.SqlModel.Metadata.Middle;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.Metadata.Property
{
    // 【多对多】标签
    public class Tag
    {
        // 0 主键 ID
        //[Key]
        public int Id { get; set; }


        //[Required]
        // 1 名称
        public string Name { get; set; } = "未知tag";


        // 2 【集合导航】【中间件】<影视作品，标签>
        public IEnumerable<WorkTag>? WorkTags { get; set; } = new List<WorkTag>();
    }
}
