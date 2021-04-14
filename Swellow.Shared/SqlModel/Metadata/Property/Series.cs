using Swellow.Shared.SqlModel.Metadata.Media;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.MetaData.Property
{
    public class Series
    {
        // 0 主键 ID
        //[Key]
        public int Id { get; set; }


        //[Required]
        // 1 名称
        public string Name { get; set; } = "未知系列";


        // 2【集合导航】影片
        public IEnumerable<Work>? Works { get; set; } = new List<Work>();
    }
}
