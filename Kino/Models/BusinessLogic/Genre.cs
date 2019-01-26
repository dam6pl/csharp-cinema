using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class Genre : DatabaseClass
    {
        #region Constructor
        public Genre(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public IQueryable<ComboboxKeyAndValue> getGenreComboboxItems()
        {
             return
                (
                    from gatunek in kinoEntities.Gatunki
                    select new ComboboxKeyAndValue
                    {
                        Key = gatunek.IdGatunku,
                        Value = gatunek.Nazwa
                    }
                ).ToList().AsQueryable();
        }
    }
}
