//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SposobyPlatnosci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SposobyPlatnosci()
        {
            this.Faktury = new HashSet<Faktury>();
        }
    
        public int IdSposobuPlatnosci { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public Nullable<bool> CzyAktywny { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faktury> Faktury { get; set; }
    }
}
