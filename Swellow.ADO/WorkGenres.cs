//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Swellow.ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkGenres
    {
        public int WorkId { get; set; }
        public int GenreId { get; set; }
        public int Weighting { get; set; }
    
        public virtual Genres Genres { get; set; }
        public virtual Works Works { get; set; }
    }
}
