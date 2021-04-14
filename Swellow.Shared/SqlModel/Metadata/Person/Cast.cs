using Swellow.Shared.SqlModel.MetaData.Middle;
using System.Collections.Generic;

namespace Swellow.Shared.SqlModel.MetaData.Person
{
    // 演职人员
    public class Cast
    {
        // 0 主键 ID
        //[Key]
        public int Id { get; set; }

        //[Required]
        // 1 名字原始
        public string Name { get; set; } = "未知演员";


        // 2 照片路径
        //public string? Poster { get; set; }


        // 3【集合导航】【中间件】<影视作品，演职人员>
        public IEnumerable<WorkCast>? WorkCasts { get; set; } = new List<WorkCast>();

    }
}
