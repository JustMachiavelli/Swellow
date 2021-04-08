using Swellow.Shared.SqlModel.MetaData.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.MetaData.Organization
{
    // 【多对多】制作商
    public class Company
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        [Required]
        // 1 原始名称
        public string Name { get; set; } = "未知公司";


        // 3【集合导航】【中间件】<影视作品，制作商>
        public IEnumerable<WorkCompany>? WorkCompanys { get; set; } = new List<WorkCompany>();
    }
}
