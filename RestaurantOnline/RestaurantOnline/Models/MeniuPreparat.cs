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
    
    public partial class MeniuPreparat
    {
        public int fk_meniu { get; set; }
        public int fk_preparat { get; set; }
        public int cantitate { get; set; }
        public int id1 { get; set; }
    
        public virtual Meniu Meniu { get; set; }
        public virtual Preparat Preparat { get; set; }
    }
}
