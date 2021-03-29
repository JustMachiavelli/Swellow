using Swellow.Shared.SqlModel.Works;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Shared.SqlModel.Property
{
    public class Series
    {
        public Series()
        {
            Videos = new List<Video>();
        }

        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 原始名称，如英语
        public string Name { get; set; }

        // 2 名称
        public string NameOrigin { get; set; }


        // 3【集合导航】影片
        public List<Video> Videos { get; set; }
    }
}
