using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class TicketTypes : DatabaseClass
    {
        #region Constructor
        public TicketTypes(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public IQueryable<ComboboxKeyAndValue> getTicketTypesComboboxItems()
        {
            return
                (
                    from typBiletu in kinoEntities.TypyBiletow
                    select new ComboboxKeyAndValue
                    {
                        Key = typBiletu.IdTypuBiletu,
                        Value = typBiletu.Nazwa + " (Cena: " + typBiletu.Cena + ")"
                    }
                ).ToList().AsQueryable();
        }
    }
}
