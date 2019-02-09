using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class ShowingsB : DatabaseClass
    {
        #region Constructor
        public ShowingsB(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<ShowingsForAllView> getAllShowings()
        {
            return new ObservableCollection<ShowingsForAllView>
                (
                from seans in kinoEntities.Seanse
                select new ShowingsForAllView
                    {
                        IdSeansu = seans.IdSeansu,
                        NazwaSali = seans.Sale.Nazwa,
                        NazwaFilmu = seans.Filmy.Tytuł,
                        Data = seans.Data,
                        TypSeansu = seans.TypySeansow.Nazwa
                    }
                );
        }
    }
}
