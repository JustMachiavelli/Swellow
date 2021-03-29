using Swellow.Model.SqlModel.Middle;
using Swellow.Shared.SqlModel.Middle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Swellow.Shared.SqlModel.People
{
    // 演职人员
    public class Cast
    {
        public Cast()
        {
            VideoCasts = new List<VideoCast>();
        }

        // 0 主键 ID
        [Key]
        public int Id { get; set; }

        // 2 名字原始
        public string Name { get; set; }

        // 3 名字
        public string NameOrigin { get; set; }

        // 4 照片路径
        public string Poster { get; set; }


        // 6【集合导航】【中间件】<影视作品，演职人员>
        public List<VideoCast> VideoCasts { get; set; }

    }
}
