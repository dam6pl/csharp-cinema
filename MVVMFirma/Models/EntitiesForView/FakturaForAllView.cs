using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    // To jest klasa pomocniczna która zamiast kluczy obcych które są w Fakutrze wyświetla odpowiednie dane z tabel powiązancyh 
    public class FakturaForAllView
    {
        public int IdFaktury
        {
            get;
            set;
        }
        public string NumerFaktury
        {
            get;
            set;
        }
        public DateTime? DataWystawienia { get; set; } 
        // To są pola które są zamiast klucza obcego
        public string KontrahentKod { get; set; }
        public string KontrahentNazwa { get; set; }
        public string KontrahentNIP { get; set; }
        public DateTime? TerminPlatnosci { get; set; }
        // To jest pole zamiast klucza obcego
        public string SposobPlatnosciNazwa { get; set; }
    }
}
