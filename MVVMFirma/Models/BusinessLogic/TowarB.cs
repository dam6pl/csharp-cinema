using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BusinessLogic
{
    public class TowarB : DataBaseClass
    {
        #region Constructor
        public TowarB(FakturyEntities fakturyEntities) 
            : base(fakturyEntities) // wywołuje z klasy bazowej połączenie z bazą danych fakturyEntities
        {
            
        }
        #endregion Constructor

        #region ViewFunction
        // PONIŻEJ TO JEST FUNKCJA A NIE PROPERTIES WIĘC JEST () I BEZ GET
        public IQueryable<ComboBoxKeyAndValue> GetTowaryComboBoxItems()
        {
                return
                    (
                        from towar in fakturyEntities.Towary
                        select new ComboBoxKeyAndValue
                        {
                            Key = towar.IdTowaru,
                            Value = towar.Nazwa + "|" + towar.Kod
                        }
                    ).ToList().AsQueryable();   
        }
        #endregion ViewFunction
    }
}
