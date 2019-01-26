using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BussinesLogic
{
    class TowarB : DatabaseClass
    {
        #region Constructor
        public TowarB(FakturyEntities fakturyEntities)
            : base(fakturyEntities)
        {
        }
        #endregion

        #region ViewFunctions
        public IQueryable<ComboboxKeyAndValue> getTowaryComboboxItems()
        {
            return 
                (
                    from towar in fakturyEntities.Towaries
                    select new ComboboxKeyAndValue
                    {
                        Key = towar.IdTowaru,
                        Value = towar.Nazwa + " " + towar.Kod
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
