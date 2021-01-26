using Swellow.Data.SqlModel.Middle;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Data.SqlModel.Property
{
    // 发行商，【多对多】多发行商对多影片
    public class Publisher
    {
        // 【多对多】发行商
        public Publisher()
        {
            VideoPublishers = new List<VideoPublisher>();
        }

        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 1 名称
        public string Name { get; set; }

        // 2 原名称，英文等名称
        public string NameOriginal { get; set; }


        // 3【集合导航】【中间件】<影视作品，发行商>
        public List<VideoPublisher> VideoPublishers { get; set; }
    }
}
