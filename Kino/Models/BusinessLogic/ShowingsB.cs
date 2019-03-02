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
                where seans.CzyAktywny == true
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

        public bool removeShowing(int seansId)
        {
            try
            {
                Seanse seanse = kinoEntities.Seanse.Find(seansId);
                seanse.CzyAktywny = false;
                kinoEntities.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
