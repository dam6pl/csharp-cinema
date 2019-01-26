using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    class NowaFakturaViewModel : JedenViewModel<Faktury>
    {
        #region Fields
        public BaseCommand _ShowKontrahenciCommand;
        #endregion

        #region Construktor
        public NowaFakturaViewModel()
            : base()
        {
            // to jest nazwa ktora wyswietli sie na zakladce
            base.DisplayName = "Faktura";
            //tworzymy nowy pusty obiekt biznesowy
            this.item = new Faktury();
            Messenger.Default.Register<KontrahenciForAllView>(this, getWybranyKontrahent);
        }
        #endregion Constructor
        public ICommand ShowKontrahenciCommand
        {
            get
            {
                if (_ShowKontrahenciCommand == null)
                    _ShowKontrahenciCommand = new BaseCommand(() => Messenger.Default.Send("KontrahenciShow"));

                return _ShowKontrahenciCommand;
            }
        }
        #region Command
        
        #endregion

        #region Properties
        //dla kazdego pola na interfejsie edytowalnego tworzymy propertisa z standardowym kodem
        public string Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    OnPropertyChanged(() => Numer);
                }
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        public int? IdKontrahenta
        {
            get
            {
                return item.IdKontrahenta;
            }
            set
            {
                if (item.IdKontrahenta != value)
                {
                    item.IdKontrahenta = value;
                    OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> KontrahenciComboboxItems
        {
            get
            {
                return
                    (
                        from kontrahent in fakturyEntities.Kontrahencis
                        select new ComboboxKeyAndValue
                        {
                            Key = kontrahent.IdKontrahenta,
                            Value = kontrahent.Nazwa + " (NIP: " + kontrahent.NIP + ")"
                        }
                    ).ToList().AsQueryable();

            }
        }
        private string _Nazwa;
        public string Nazwa
        {
            get
            {
                return _Nazwa;
            }
            set
            {
                if (_Nazwa != value)
                {
                    _Nazwa = value;
                    OnPropertyChanged(() => _Nazwa);
                }
            }
        }
        private string _NIP;
        public string NIP
        {
            get
            {
                return _NIP;
            }
            set
            {
                if (_NIP != value)
                {
                    _NIP = value;
                    OnPropertyChanged(() => _NIP);
                }
            }
        }
        private string _Adres;
        public string Adres
        {
            get
            {
                return _Adres;
            }
            set
            {
                if (_Adres != value)
                {
                    _Adres = value;
                    OnPropertyChanged(() => _Adres);
                }
            }
        }
        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                if (item.TerminPlatnosci != value)
                {
                    item.TerminPlatnosci = value;
                    OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        public int? IdSposobuPlatnosci
        {
            get
            {
                return item.IdSposobuPlatnosci;
            }
            set
            {
                if (item.IdSposobuPlatnosci != value)
                {
                    item.IdSposobuPlatnosci = value;
                    OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }
        public IQueryable<SposobyPlatnosci> SposobPlatnosciComboboxItems
        {
            get
            {
                return
                    (
                        from sposobPlatnosci in fakturyEntities.SposobyPlatnoscis
                        select sposobPlatnosci
                    ).ToList().AsQueryable();

            }
        }
        #endregion Properties

        #region Helpers
        //to jest metoda ktora zapisuje rekod
        public override void Save()
        {
            //najpierw dodajemy nowy rekord do lokalnej kolekcji
            fakturyEntities.Fakturies.Add(item);
            //nastepnie zapisujemy zmiany w bazie danych
            fakturyEntities.SaveChanges();
        }
        private void getWybranyKontrahent(KontrahenciForAllView kontrahent)
        {
            Nazwa = kontrahent.Nazwa;
            NIP = kontrahent.NIP;
            Adres = kontrahent.Adres;
            IdKontrahenta = kontrahent.IdKontrahenta;
        }
        #endregion Helpers
    }
}
