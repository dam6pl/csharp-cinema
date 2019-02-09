using GalaSoft.MvvmLight.Messaging;
using Kino.Models;
using Kino.Models.BusinessLogic;
using Kino.Models.EntitiesForView;
using Kino.Models.Validators;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kino.ViewModels
{
    
    public class FilmsNewViewModel : SingleViewModel<Filmy>, IDataErrorInfo
    {
        #region Fields
        private BaseCommand _AddGenreCommand;
        #endregion

        #region Construktor
        public FilmsNewViewModel(int? id = null)
            : base()
        {
            base.DisplayName = "Nowy film";
            base.ViewType = "Films";

            if (id == null)
                this.item = new Filmy();
            else
                this.item = kinoEntities.Filmy.Find(id);
        }
        #endregion Constructor

        #region Command
        public ICommand AddGenreCommand
        {
            get
            {
                if (_AddGenreCommand == null)
                    _AddGenreCommand = new BaseCommand(() => Messenger.Default.Send("GenreNew"));

                return _AddGenreCommand;
            }
        }
        #endregion

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
                return new GenreB(kinoEntities).getGenreComboboxItems();

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
            if (this.item.IdFilmu == 0)
                kinoEntities.Filmy.Add(item);
            else
            {
                Filmy filmy = kinoEntities.Filmy.Find(this.item.IdFilmu);
                filmy = item;
            }

            kinoEntities.SaveChanges();
        }
        #endregion Helpers

        #region Validations
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Tytuł")
                    komunikat = StringValidator.IsNotEmpty(this.Tytuł) ?? StringValidator.IsStartFromUpper(this.Tytuł);
                else if (name == "IdGatunku")
                    komunikat = ComboboxValidator.IsNotEmpty(this.IdGatunku);
                else if (name == "Rezyser")
                    komunikat = StringValidator.IsNotEmpty(this.Rezyser);
                else if (name == "RokProdukcji")
                    komunikat = IntegerValidation.IsNotEmpty(this.RokProdukcji) ?? IntegerValidation.IsYearInPast(this.RokProdukcji);
                else if (name == "CzasTrwania")
                    komunikat = DecimalValidation.IsNotEmpty(this.CzasTrwania) ?? DecimalValidation.IsPositive(this.CzasTrwania);
                else if (name == "LimitWiekowy")
                    komunikat = IntegerValidation.IsNotEmpty(this.LimitWiekowy) ?? IntegerValidation.IsPositive(this.LimitWiekowy);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Tytuł"] == null
                && this["IdGatunku"] == null
                && this["Rezyser"] == null
                && this["RokProdukcji"] == null
                && this["CzasTrwania"] == null
                && this["LimitWiekowy"] == null;
        }
        #endregion
    }
}
