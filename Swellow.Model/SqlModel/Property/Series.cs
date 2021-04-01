﻿using Swellow.Model.SqlModel.Works;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Property
{
    public class Series
    {
        // 0 主键 ID
        [Key]
        public int Id { get; set; }


        // 1 名称
        public string Name { get; set; }


        // 2【集合导航】影片
        public IEnumerable<Work> Works { get; set; } = new List<Work>();
    }
}
