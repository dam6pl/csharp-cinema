//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kino.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypyBiletow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypyBiletow()
        {
            this.Zamowienia = new HashSet<Zamowienia>();
        }
    
        public int IdTypuBiletu { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public Nullable<decimal> Cena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zamowienia> Zamowienia { get; set; }
    }
}