using Swellow.Data.SqlModel.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Data.SqlModel.Property
{
    // 【多对多】制作商
    public class Studio
    {
        public Studio()
        {
            VideoStudios = new List<VideoStudio>();
        }

        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 名称
        public string Name { get; set; }

        // 2 原始名称
        public string NameOriginal { get; set; }

        // 3【集合导航】【中间件】<影视作品，制作商>
        public List<VideoStudio> VideoStudios { get; set; }
    }
}
