using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class FilmsB : DatabaseClass
    {
        #region Constructor
        public FilmsB(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<FilmsForAllView> getAllFilms()
        {
            return new ObservableCollection<FilmsForAllView>
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

        public IQueryable<ComboboxKeyAndValue> getFilmsComboboxItems()
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
}
