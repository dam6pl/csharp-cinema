//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinqPrzyklady
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wyplaty
    {
        public int IdWyplaty { get; set; }
        public int IdPracownika { get; set; }
        public Nullable<decimal> Kwota { get; set; }
    
        public virtual Pracownicy Pracownicy { get; set; }
    }
}