using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class GenreB : DatabaseClass
    {
        #region Constructor
        public GenreB(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public IQueryable<ComboboxKeyAndValue> getGenreComboboxItems()
        {
             return
                (
                    from gatunek in kinoEntities.Gatunki
                    where gatunek.CzyAktywny == true
                    select new ComboboxKeyAndValue
                    {
                        Key = gatunek.IdGatunku,
                        Value = gatunek.Nazwa
                    }
                ).ToList().AsQueryable();
        }
    }
}
