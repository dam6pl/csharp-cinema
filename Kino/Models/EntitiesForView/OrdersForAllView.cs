using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.EntitiesForView
{
    public class OrdersForAllView
    {
        public int IdZamowienia { get; set; }
        public string Seans { get; set; }
        public string NazwaKlienta  { get; set; }
        public string TypBiletu  { get; set; }
        public string Pracownik  { get; set; }
        public DateTime? Data { get; set; }
        public bool? Status  { get; set; }
    }
}
