using Kino.Models;
using Kino.Models.BusinessLogic;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    
    public class FilmsNewViewModel : SingleViewModel<Filmy>
    { 
        #region Construktor
        public FilmsNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy film";

            this.item = new Filmy();
        }
        #endregion Constructor

        #region Properties
        public string Tytuł
        {
            get
            {
                return item.Tytuł;
            }
            set
            {
                if (item.Tytuł != value)
                {
                    item.Tytuł = value;
                    OnPropertyChanged(() => Tytuł);
                }
            }
        }

        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    OnPropertyChanged(() => Opis);
                }
            }
        }

        public int? IdGatunku
        {
            get
            {
                return item.IdGatunku;
            }
            set
            {
                if (item.IdGatunku != value)
                {
                    item.IdGatunku = value;
                    OnPropertyChanged(() => IdGatunku);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> GatunkiComboboxItems
        {
            get
            {
                return new Genre(kinoEntities).getGenreComboboxItems();

            }
        }

        public string Rezyser
        {
            get
            {
                return item.Rezyser;
            }
            set
            {
                if (item.Rezyser != value)
                {
                    item.Rezyser = value;
                    OnPropertyChanged(() => Rezyser);
                }
            }
        }

        public int? RokProdukcji
        {
            get
            {
                return item.RokProdukcji;
            }
            set
            {
                if (item.RokProdukcji != value)
                {
                    item.RokProdukcji = value;
                    OnPropertyChanged(() => RokProdukcji);
                }
            }
        }

        public decimal? CzasTrwania
        {
            get
            {
                return item.CzasTrwania;
            }
            set
            {
                if (item.CzasTrwania != value)
                {
                    item.CzasTrwania = value;
                    OnPropertyChanged(() => CzasTrwania);
                }
            }
        }


        public int? LimitWiekowy
        {
            get
            {
                return item.LimitWiekowy;
            }
            set
            {
                if (item.LimitWiekowy != value)
                {
                    item.LimitWiekowy = value;
                    OnPropertyChanged(() => LimitWiekowy);
                }
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Filmy.Add(item);
            kinoEntities.SaveChanges();
        }
        #endregion Helpers
    }
}
