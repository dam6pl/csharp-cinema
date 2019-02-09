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
    
    public class OrdersNewViewModel : SingleViewModel<Zamowienia>, IDataErrorInfo
    {
        #region Fields
        private BaseCommand _ShowShowingsCommand;
        private BaseCommand _ShowCustomersCommand;
        private BaseCommand _AddTicketTypeCommand;
        #endregion

        #region Construktor
        public OrdersNewViewModel(int? id = null)
            : base()
        {
            base.DisplayName = "Nowe zamowienie";
            base.ViewType = "Orders";



            if (id == null)
            {
                this.item = new Zamowienia();
                this.Status = true;
                this.Data = DateTime.Now;
            }
            else
            {
                this.item = kinoEntities.Zamowienia.Find(id);
                this.IdSeansu = this.item.Seanse.IdSeansu;
                this.SeansSala = this.item.Seanse.Sale.Nazwa;
                this.SeansFilm = this.item.Seanse.Filmy.Tytuł;
                this.SeansData = this.item.Seanse.Data;
                this.IdKlienta = this.item.Klienci.IdKlienta;
                this.KlientImieNazwisko = this.item.Klienci.Imie + " " + this.item.Klienci.Nazwisko;
                this.KlientEmail = this.item.Klienci.Email;
                this.KlientTelefon = this.item.Klienci.Telefon;
            }

            Messenger.Default.Register<Klienci>(this, getSelectedCustomer);
            Messenger.Default.Register<ShowingsForAllView>(this, getSelectedShowing);
        }
        #endregion Constructor

        #region Command
        public ICommand ShowShowingsCommand
        {
            get
            {
                if (_ShowShowingsCommand == null)
                    _ShowShowingsCommand = new BaseCommand(() => Messenger.Default.Send("ShowingsAll"));

                return _ShowShowingsCommand;
            }
        }

        public ICommand ShowCustomersCommand
        {
            get
            {
                if (_ShowCustomersCommand == null)
                    _ShowCustomersCommand = new BaseCommand(() => Messenger.Default.Send("CustomersAll"));

                return _ShowCustomersCommand;
            }
        }

        public ICommand AddTicketTypeCommand
        {
            get
            {
                if (_AddTicketTypeCommand == null)
                    _AddTicketTypeCommand = new BaseCommand(() => Messenger.Default.Send("TicketTypesNew"));

                return _AddTicketTypeCommand;
            }
        }
        #endregion

        #region Properties
        public int? IdSeansu
        {
            get
            {
                return item.IdSeansu;
            }
            set
            {
                if (item.IdSeansu != value)
                {
                    item.IdSeansu = value;
                    OnPropertyChanged(() => IdSeansu);
                }
            }
        }

        public int? IdKlienta
        {
            get
            {
                return item.IdKlienta;
            }
            set
            {
                if (item.IdKlienta != value)
                {
                    item.IdKlienta = value;
                    OnPropertyChanged(() => IdKlienta);
                }
            }
        }

        public int? IdTypuBiletu
        {
            get
            {
                return item.IdTypuBiletu;
            }
            set
            {
                if (item.IdTypuBiletu != value)
                {
                    item.IdTypuBiletu = value;
                    OnPropertyChanged(() => IdTypuBiletu);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> TypyBiletowComboboxItems
        {
            get
            {
                return new TicketTypesB(kinoEntities).getTicketTypesComboboxItems();
            }
        }

        public int? IdPracownika
        {
            get
            {
                return item.IdPracownika;
            }
            set
            {
                if (item.IdPracownika != value)
                {
                    item.IdPracownika = value;
                    OnPropertyChanged(() => IdPracownika);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> PracownicyComboboxItems
        {
            get
            {
                return new EmployeesB(kinoEntities).getEmployeeComboboxItems();
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

        public bool? Status
        {
            get
            {
                return item.Status;
            }
            set
            {
                if (item.Status != value)
                {
                    item.Status = value;
                    OnPropertyChanged(() => Status);
                }
            }
        }

        private string _SeansSala;
        public string SeansSala
        {
            get
            {
                return _SeansSala;
            }
            set
            {
                if (_SeansSala != value)
                {
                    _SeansSala = value;
                    OnPropertyChanged(() => _SeansSala);
                }
            }
        }

        private string _SeansFilm;
        public string SeansFilm
        {
            get
            {
                return _SeansFilm;
            }
            set
            {
                if (_SeansFilm != value)
                {
                    _SeansFilm = value;
                    OnPropertyChanged(() => _SeansFilm);
                }
            }
        }

        private DateTime? _SeansData;
        public DateTime? SeansData
        {
            get
            {
                return _SeansData;
            }
            set
            {
                if (_SeansData != value)
                {
                    _SeansData = value;
                    OnPropertyChanged(() => _SeansData);
                }
            }
        }

        private string _KlientImieNazwisko;
        public string KlientImieNazwisko
        {
            get
            {
                return _KlientImieNazwisko;
            }
            set
            {
                if (_KlientImieNazwisko != value)
                {
                    _KlientImieNazwisko = value;
                    OnPropertyChanged(() => _KlientImieNazwisko);
                }
            }
        }

        private string _KlientEmail;
        public string KlientEmail
        {
            get
            {
                return _KlientEmail;
            }
            set
            {
                if (_KlientEmail != value)
                {
                    _KlientEmail = value;
                    OnPropertyChanged(() => _KlientEmail);
                }
            }
        }

        private string _KlientTelefon;
        public string KlientTelefon
        {
            get
            {
                return _KlientTelefon;
            }
            set
            {
                if (_KlientTelefon != value)
                {
                    _KlientTelefon = value;
                    OnPropertyChanged(() => _KlientTelefon);
                }
            }
        }
        #endregion Properties

        #region Helpers
        public override void Save()
        {
            if (this.item.IdZamowienia == 0)
                kinoEntities.Zamowienia.Add(item);
            else
            {
                Zamowienia zamowienia = kinoEntities.Zamowienia.Find(this.item.IdZamowienia);
                zamowienia = item;
            }

            kinoEntities.SaveChanges();
        }

        private void getSelectedShowing(ShowingsForAllView seans)
        {
            IdSeansu = seans.IdSeansu;
            SeansSala = seans.NazwaSali;
            SeansFilm = seans.NazwaFilmu;
            SeansData = seans.Data;
        }

        private void getSelectedCustomer(Klienci klient)
        {
            IdKlienta = klient.IdKlienta;
            KlientImieNazwisko = klient.Imie + " " + klient.Nazwisko;
            KlientEmail = klient.Email;
            KlientTelefon = klient.Telefon;
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
                if (name == "SeansSala" || name == "SeansFilm" || name == "SeansData")
                    komunikat = StringValidator.IsNotEmpty(this.SeansSala);
                if (name == "KlientImieNazwisko" || name == "KlientEmail" || name == "KlientTelefon")
                    komunikat = StringValidator.IsNotEmpty(this.KlientImieNazwisko);
                else if (name == "IdTypuBiletu")
                    komunikat = ComboboxValidator.IsNotEmpty(this.IdTypuBiletu);
                else if (name == "IdPracownika")
                    komunikat = ComboboxValidator.IsNotEmpty(this.IdPracownika);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["SeansSala"] == null
                && this["SeansFilm"] == null
                && this["SeansData"] == null
                && this["KlientImieNazwisko"] == null
                && this["KlientEmail"] == null
                && this["KlientTelefon"] == null
                && this["IdTypuBiletu"] == null
                && this["IdPracownika"] == null;
        }
        #endregion
    }
}
