using Kino.Models;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class ShowingsAllViewModel : AllViewModel<ShowingsForAllView>
    {
        #region Constructor
        public ShowingsAllViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie seanse";
        }
        #endregion Constructor

        #region properties
        public IQueryable<ComboboxKeyAndValue> SaleComboboxItems
        {
            get
            {
                return
                    (
                        from sala in kinoEntities.Sale
                        select new ComboboxKeyAndValue
                        {
                            Key = sala.IdSali,
                            Value = sala.Nazwa + " (ID: " + sala.IdSali + ")"
                        }
                    ).ToList().AsQueryable();

            }
        }

        public IQueryable<ComboboxKeyAndValue> FilmyComboboxItems
        {
            get
            {
                return
                    (
                        from film in kinoEntities.Filmy
                        select new ComboboxKeyAndValue
                        {
                            Key = film.IdFilmu,
                            Value = film.Tytuł
                        }
                    ).ToList().AsQueryable();

            }
        }

        public IQueryable<ComboboxKeyAndValue> TypySeansowComboboxItems
        {
            get
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
        #endregion

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<ShowingsForAllView>
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
       
        #endregion Helpers
    }
}
