using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PozycjeFakturyForAllView
    {
        public string TowarKod { get; set; }
        public string TowarNazwa { get; set; }
        public decimal? Cena { get; set; }
        public decimal? Ilosc { get; set; }
        public decimal? Rabat { get; set; }
        public decimal? Wartosc { get; set; }
    }
}
