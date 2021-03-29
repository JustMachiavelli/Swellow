using Swellow.Shared.SqlModel.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.Property
{
    // 【多对多】制作商
    public class Company
    {
        public Company()
        {
            VideoCompanys = new List<VideoCompany>();
        }

        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 原始名称
        public string Name { get; set; }

        // 2 名称
        public string NameOrigin { get; set; }

        // 3【集合导航】【中间件】<影视作品，制作商>
        public List<VideoCompany> VideoCompanys { get; set; }
    }
}
