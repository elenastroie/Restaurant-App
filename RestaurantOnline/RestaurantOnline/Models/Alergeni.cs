//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alergeni
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alergeni()
        {
            this.AlergeniPreparats = new HashSet<AlergeniPreparat>();
        }
    
        public int id { get; set; }
        public string nume { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlergeniPreparat> AlergeniPreparats { get; set; }
    }
}
