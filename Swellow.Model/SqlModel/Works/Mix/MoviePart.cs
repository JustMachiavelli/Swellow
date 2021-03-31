using Swellow.Model.Enum;
using Swellow.Model.SqlModel.Middle;
using Swellow.Model.SqlModel.Works.Mix;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swellow.Model.SqlModel.Works.Film
{
    // 电影
    public class MoviePart : Work
    {
        // 2【引用导航】包含CDs
        public IEnumerable<CD> CDs { get; set; }
    }
}
