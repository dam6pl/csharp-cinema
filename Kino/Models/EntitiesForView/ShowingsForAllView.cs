using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.EntitiesForView
{
    public class ShowingsForAllView
    {
        public int IdSeansu { get; set; }
        public string NazwaSali { get; set; }
        public string NazwaFilmu  { get; set; }
        public DateTime? Data { get; set; }
        public string TypSeansu { get; set; }
    }
}
