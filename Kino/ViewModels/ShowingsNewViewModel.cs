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
    
    public class ShowingsNewViewModel : SingleViewModel<Seanse>, IDataErrorInfo
    {
        #region Fields
        private BaseCommand _ShowFilmsCommand;
        private BaseCommand _AddRoomCommand;
        private BaseCommand _AddShowingTypeCommand;
        #endregion

        #region Construktor
        public ShowingsNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy seans";
            base.ViewType = "Showings";

            this.item = new Seanse();
            Messenger.Default.Register<FilmsForAllView>(this, getSelectedFilm);
        }
        #endregion Constructor

        #region Command
        public ICommand ShowFilmsCommand
        {
            get
            {
                if (_ShowFilmsCommand == null)
                    _ShowFilmsCommand = new BaseCommand(() => Messenger.Default.Send("FilmsAll"));

                return _ShowFilmsCommand;
            }
        }

        public ICommand AddRoomCommand
        {
            get
            {
                if (_AddRoomCommand == null)
                    _AddRoomCommand = new BaseCommand(() => Messenger.Default.Send("RoomsNew"));

                return _AddRoomCommand;
            }
        }

        public ICommand AddShowingTypeCommand
        {
            get
            {
                if (_AddShowingTypeCommand == null)
                    _AddShowingTypeCommand = new BaseCommand(() => Messenger.Default.Send("ShowingTypesNew"));

                return _AddShowingTypeCommand;
            }
        }
        #endregion

        #region Properties
        public int? IdSali
        {
            get
            {
                return item.IdSali;
            }
            set
            {
                if (item.IdSali != value)
                {
                    item.IdSali = value;
                    OnPropertyChanged(() => IdSali);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> SaleComboboxItems
        {
            get
            {
                return new RoomsB(kinoEntities).getRoomsComboboxItems();
            }
        }

        public int? IdFilmu
        {
            get
            {
                return item.IdFilmu;
            }
            set
            {
                if (item.IdFilmu != value)
                {
                    item.IdFilmu = value;
                    OnPropertyChanged(() => IdFilmu);
                }
            }
        }

        public DateTime? Data
        {
            get
            {
                return item.Data;
            }
            set
            {
                if (item.Data != value)
                {
                    item.Data = value;
                    OnPropertyChanged(() => Data);
                }
            }
        }

        public int? IdTypuSeansu
        {
            get
            {
                return item.IdTypuSeansu;
            }
            set
            {
                if (item.IdTypuSeansu != value)
                {
                    item.IdTypuSeansu = value;
                    OnPropertyChanged(() => IdTypuSeansu);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> TypySeansowComboboxItems
        {
            get
            {
                return new ShowingTypesB(kinoEntities).getShowingTypesComboboxItems();
            }
        }

        private string _FilmTytul;
        public string FilmTytul
        {
            get
            {
                return _FilmTytul;
            }
            set
            {
                if (_FilmTytul != value)
                {
                    _FilmTytul = value;
                    OnPropertyChanged(() => _FilmTytul);
                }
            }
        }

        private string _FilmOpis;
        public string FilmOpis
        {
            get
            {
                return _FilmOpis;
            }
            set
            {
                if (_FilmOpis != value)
                {
                    _FilmOpis = value;
                    OnPropertyChanged(() => _FilmOpis);
                }
            }
        }

        private int? _FilmRokProdukcji;
        public int? FilmRokProdukcji
        {
            get
            {
                return _FilmRokProdukcji;
            }
            set
            {
                if (_FilmRokProdukcji != value)
                {
                    _FilmRokProdukcji = value;
                    OnPropertyChanged(() => _FilmRokProdukcji);
                }
            }
        }
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Seanse.Add(item);
            kinoEntities.SaveChanges();
        }

        private void getSelectedFilm(FilmsForAllView film)
        {
            IdFilmu = film.IdFilmu;
            FilmTytul = film.Tytul;
            FilmOpis = film.Opis;
            FilmRokProdukcji = film.RokProdukcji;
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
                if (name == "IdSali")
                    komunikat = ComboboxValidator.IsNotEmpty(this.IdSali);
                else if (name == "FilmTytul" || name == "FilmOpis" || name == "FilmRokProdukcji")
                    komunikat = StringValidator.IsNotEmpty(this.FilmTytul);
                else if (name == "Data")
                    komunikat = DateValidator.IsNotEmpty(this.Data) ?? DateValidator.IsInPast(this.Data);
                else if (name == "IdTypuSeansu")
                    komunikat = ComboboxValidator.IsNotEmpty(this.IdTypuSeansu);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Sala"] == null
                && this["FilmTytul"] == null
                && this["FilmOpis"] == null
                && this["FilmRokProdukcji"] == null
                && this["Data"] == null
                && this["IdTypuSeansu"] == null;
        }
        #endregion
    }
}
