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
    
    public partial class Meniu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meniu()
        {
            this.ComandaMenius = new HashSet<ComandaMeniu>();
            this.MeniuPreparats = new HashSet<MeniuPreparat>();
        }
    
        public int id { get; set; }
        public string nume { get; set; }
        public int fk_categorie { get; set; }
    
        public virtual Categorie Categorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComandaMeniu> ComandaMenius { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeniuPreparat> MeniuPreparats { get; set; }
    }
}
