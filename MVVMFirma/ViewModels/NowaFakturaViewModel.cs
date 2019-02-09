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
using System.Collections.ObjectModel;

namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel : JedenWszystkieViewModel<Faktury, PozycjeFakturyForAllView> 
    {
        #region Fields
        private BaseCommand _ShowKontrahenciCommand;
        #endregion Fields

        #region Constructor
        public NowaFakturaViewModel()
            : base()
        {
            base.DisplayName = "Nowa Faktura";
            base.DisplayListName = "Pozycje faktury";
            this.item = new Faktury();
            Messenger.Default.Register<KontrahenciForAllView>(this, GetWybranyKontrahent);
            Messenger.Default.Register<PozycjeFaktury>(this, addPozycjeFaktury);
        }
        #endregion Constructor

        #region Command
        public ICommand ShowKontrahenciCommand
        {
            get
            {
                if (_ShowKontrahenciCommand == null)
                {
                    // Komenda która wywołuje okno z kontrahentami
                    // Ten komunikat zostanie wysłany do MainWindowViewModel które wywoła zakładkę z Kontrahentami
                    _ShowKontrahenciCommand = new BaseCommand(() => Messenger.Default.Send("showAllKontrahenci"));
                }
                return _ShowKontrahenciCommand;
            }
        }
        #endregion Command

        #region Properties
        // Dla każdego pola na interfejsie edytowalnego, tworzymy propertiesa ze standardowym kodem
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
                    OnPropertyChanged(() => Numer); // to jest funkcja która odpowiada za odświeżenie okna po zmianie pola Kod
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
                    OnPropertyChanged(() => DataWystawienia); // to jest funkcja która odpowiada za odświeżenie okna po zmianie pola Kod
                }
            }
        }
        // Dla każdego klucza obcego trzeba stworzyć properties z Id oraz properties do ComboBoxa
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
                    OnPropertyChanged(() => IdKontrahenta); // to jest funkcja która odpowiada za odświeżenie okna po zmianie pola Kod
                }
            }
        }

        // To są pola i propertiesy do pól dotyczących kontrahenta które przyjdą z okna do wyboru kontrahenta
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
                    OnPropertyChanged(() => Nazwa);
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
                    OnPropertyChanged(() => NIP);
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
                    OnPropertyChanged(() => Adres);
                }
            }
        }

        // Nowy Kod standardowy - > KONTRAHENTA BĘDZIEMY WYPEŁNIAĆ PRZEZ WYBÓR W COMBOBOXIE
        // Tworzymy zatem standardowy kod ComboBoxa
        public IQueryable<ComboBoxKeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return
                    (
                        from Kontrahent in fakturyEntities.Kontrahenci  // dla każdego kontrahenta z bazy danych Kontrahentów
                        select new ComboBoxKeyAndValue  // tworzymy ComboBoxKeyAndValue
                        {
                            Key = Kontrahent.IdKontrahenta,
                            Value = Kontrahent.Nazwa + " | "+ Kontrahent.NIP + " | " + Kontrahent.Adresy.Miasto
                        }
                    ).ToList().AsQueryable();
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

        public int? IdFormyPlatnosci
        {
            get
            {
                return item.IdFormyPlatnosci;
            }
            set
            {
                if (item.IdFormyPlatnosci != value)
                {
                    item.IdFormyPlatnosci = value;
                    OnPropertyChanged(() => IdFormyPlatnosci);
                }
            }
        }
        // i ComboBox do Formy płatności (będziemy wyświetlać konkretne kole bez sklejania
        public IQueryable<SposobyPlatnosci> SposobyPlatnosciComboBoxItems
        {
            get
            {
                return
                    (
                        from sposobPlatnosci in fakturyEntities.SposobyPlatnosci  // dla każdego sposobu platnosci z bazy danych SposobyPlatnosci
                        select sposobPlatnosci
                    ).ToList().AsQueryable();
            }
        }

        #endregion Properties

        #region Helpers
        // To jest metoda która się wywoła jak Messenger z construcora złapie Kontrahent wybranego w zakładce wyświetlającej kontrahentów
        private void GetWybranyKontrahent(KontrahenciForAllView kontrahent)
        {
            Nazwa = kontrahent.Nazwa;
            NIP = kontrahent.NIP;
            Adres = kontrahent.Adres;
            IdKontrahenta = kontrahent.IdKontrahenta;
        }

        // To jest metoda która zapisuje rekord
        public override void Save()
        {
            // Najpierw dodajemy nowy rekord do lokalnej kolekcji
            fakturyEntities.Faktury.Add(item);
            // Następnie zapisujemy zmiany w bazie danych 
            fakturyEntities.SaveChanges();
        }

        public override void loadList()
        {
            List = new ObservableCollection<PozycjeFakturyForAllView>
                (
                    from pozycja in item.PozycjeFaktury
                    select new PozycjeFakturyForAllView
                    {
                        TowarKod = pozycja.Towary.Kod,
                        TowarNazwa = pozycja.Towary.Nazwa,
                        Cena = pozycja.Cena,
                        Ilosc = pozycja.Ilosc,
                        Rabat = pozycja.Rabat,
                        Wartosc = (pozycja.Cena * pozycja.Ilosc) - pozycja.Rabat * (pozycja.Cena * pozycja.Ilosc) / 100
                    }
                );
        }

        private void addPozycjeFaktury(PozycjeFaktury pozycjeFaktury)
        {
            PozycjeFaktury nowa = new PozycjeFaktury();
            nowa.IdTowaru = pozycjeFaktury.IdTowaru;
            nowa.Towary = fakturyEntities.Towary.Find(nowa.IdTowaru);
            nowa.Ilosc = pozycjeFaktury.Ilosc;
            nowa.Rabat = pozycjeFaktury.Rabat;
            nowa.Cena = pozycjeFaktury.Cena;
            nowa.CzyAktywny = true;

            fakturyEntities.PozycjeFaktury.Add(nowa);
            item.PozycjeFaktury.Add(nowa);
            List.Add
                (
                    new PozycjeFakturyForAllView()
                    {
                        TowarKod = nowa.Towary.Kod,
                        TowarNazwa = nowa.Towary.Nazwa,
                        Cena = nowa.Cena,
                        Ilosc = nowa.Ilosc,
                        Rabat = nowa.Rabat,
                        Wartosc = (nowa.Cena * nowa.Ilosc) - nowa.Rabat * (nowa.Cena * nowa.Ilosc) / 100
                    }
                );
        }
        #endregion Helpers

    }
}
