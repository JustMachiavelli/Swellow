using Swellow.Model.SqlModel.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Property
{
    // 【多对多】制作商
    public class Company
    {
        public Company()
        {
            VideoCompanys = new List<WorkCompany>();
        }

        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 原始名称
        public string Name { get; set; }

        // 2 名称
        public string NameOrigin { get; set; }

        // 3【集合导航】【中间件】<影视作品，制作商>
        public List<WorkCompany> VideoCompanys { get; set; }
    }
}
