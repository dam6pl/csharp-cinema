using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KontrahenciForAllView
    {
        public int IdKontrahenta { get; set; }
        public string Kod { get; set; }
        public string NIP { get; set; }
        public string Nazwa { get; set; }
        public string Rodzaj { get; set; }
        public string Adres { get; set; }
    }
}
