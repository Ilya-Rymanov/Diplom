//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Value
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Value()
        {
            this.characteristic = new HashSet<characteristic>();
        }
    
        public int id_Value { get; set; }
        public string Name_Value { get; set; }
        public Nullable<int> id_Unit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<characteristic> characteristic { get; set; }
        public virtual Unit Unit { get; set; }
    }
}