using GalaSoft.MvvmLight.Messaging;
using Kino.Models;
using Kino.Models.BusinessLogic;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kino.ViewModels
{
    
    public class OrdersNewViewModel : SingleViewModel<Zamowienia>
    {
        #region Fields
        private BaseCommand _ShowShowingsCommand;
        private BaseCommand _ShowCustomersCommand;
        private BaseCommand _AddTicketTypeCommand;
        #endregion

        #region Construktor
        public OrdersNewViewModel()
            : base()
        {
            base.DisplayName = "Nowe zamowienie";

            this.item = new Zamowienia();
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
                    _ShowShowingsCommand = new BaseCommand(() => Messenger.Default.Send("ShowingsShow"));

                return _ShowShowingsCommand;
            }
        }

        public ICommand ShowCustomersCommand
        {
            get
            {
                if (_ShowCustomersCommand == null)
                    _ShowCustomersCommand = new BaseCommand(() => Messenger.Default.Send("CustomersShow"));

                return _ShowCustomersCommand;
            }
        }

        public ICommand AddTicketTypeCommand
        {
            get
            {
                if (_AddTicketTypeCommand == null)
                    _AddTicketTypeCommand = new BaseCommand(() => Messenger.Default.Send("Nowy typ biletow"));

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
                return new TicketTypes(kinoEntities).getTicketTypesComboboxItems();
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
                return new Employees(kinoEntities).getEmployeeComboboxItems();
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
            kinoEntities.Zamowienia.Add(item);
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
    }
}
