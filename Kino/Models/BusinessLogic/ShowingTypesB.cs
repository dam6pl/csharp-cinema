using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class ShowingTypesB : DatabaseClass
    {
        #region Constructor
        public ShowingTypesB(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public IQueryable<ComboboxKeyAndValue> getShowingTypesComboboxItems()
        {
            return
                (
                    from typSeansu in kinoEntities.TypySeansow
                    select new ComboboxKeyAndValue
                    {
                        Key = typSeansu.IdTypuSeansu,
                        Value = typSeansu.Nazwa
                    }
                ).ToList().AsQueryable();
        }
    }
}
