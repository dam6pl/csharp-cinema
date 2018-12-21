using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class FakturaForAllView
    {
        public int IdFaktury { get; set; }
        public string Numer { get; set; }
        public DateTime? DataWystawienia { get; set; }
        public string KontrahentKod { get; set; }
        public string KontrahentNazwa { get; set; }
        public string KontrahentNip { get; set; }
        public DateTime? TerminPlatnosci { get; set; }
        public string SposobPlatnosciNazwa { get; set; }
    }
}
