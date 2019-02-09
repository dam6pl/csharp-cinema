using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    // To jest klasa pomocniczna do uzupełniania klucza obcego przez ComboBox
    public class ComboBoxKeyAndValue
    {
        public int Key { get; set; }    // to co się w tle wybierzes
        public string Value { get; set; }   // to co się wyświetli
    }
}
