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
    
    public partial class Seasons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seasons()
        {
            this.Episodes = new HashSet<Episodes>();
        }
    
        public int Id { get; set; }
        public int No { get; set; }
        public string Outline { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> EndYear { get; set; }
        public Nullable<int> WorkId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Episodes> Episodes { get; set; }
        public virtual Works Works { get; set; }
    }
}
