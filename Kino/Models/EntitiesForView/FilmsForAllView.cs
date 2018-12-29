using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.EntitiesForView
{
    public class FilmsForAllView
    {
        public int IdFilmu { get; set; }
        public string Tytul { get; set; }
        public string Opis  { get; set; }
        public string NazwaGatunku  { get; set; }
        public string Rezyser  { get; set; }
        public int? RokProdukcji  { get; set; }
        public decimal? CzasTrwania  { get; set; }
        public int? LimitWiekowy  { get; set; }
    }
}
