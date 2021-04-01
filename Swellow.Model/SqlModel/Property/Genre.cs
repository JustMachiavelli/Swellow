using Swellow.Model.SqlModel.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Property
{
    // 【多对多】特征
    public class Genre
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }


        // 1 名称
        public string Name { get; set; }


        // 2【集合导航】【中间件】<影视作品，特征>
        public IEnumerable<WorkGenre> WorkGenres { get; set; } = new List<WorkGenre>();
    }
}
