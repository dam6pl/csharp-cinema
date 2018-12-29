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
    class FilmsAllViewModel : AllViewModel<FilmsForAllView>
    {
        #region Constructor
        public FilmsAllViewModel()
            : base()
        {
            base.DisplayName = "Filmy";
        }
        #endregion Constructor

        #region Properties
        public IQueryable<ComboboxKeyAndValue> GenreComboboxItems
        {
            get
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
        #endregion

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<FilmsForAllView>
                (
                from film in kinoEntities.Filmy
                select new FilmsForAllView
                    {
                        IdFilmu = film.IdFilmu,
                        Tytul = film.Tytuł,
                        Opis = film.Opis,
                        NazwaGatunku = film.Gatunki.Nazwa,
                        Rezyser = film.Rezyser,
                        RokProdukcji = film.RokProdukcji,
                        CzasTrwania = film.CzasTrwania,
                        LimitWiekowy = film.LimitWiekowy,
                    }
                );
        }
        #endregion Helpers
    }
}
