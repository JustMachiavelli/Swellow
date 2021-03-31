using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swellow.Model.SqlModel.Works.Film
{
    public class CD
    {
        // 0 主键
        [Key]
        public int Id { get; set; }


        // 1【集合导航】第几CD？
        public int No { get; set; } = 1;


        // 2 其他属性，比如“.720p.修复版”
        public string Property { get; set; }
    }
}
