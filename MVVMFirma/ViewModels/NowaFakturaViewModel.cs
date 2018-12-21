using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    class NowaFakturaViewModel : JedenViewModel<Faktury>
    {
        #region Construktor
        public NowaFakturaViewModel()
            : base()
        {
            // to jest nazwa ktora wyswietli sie na zakladce
            base.DisplayName = "Faktura";
            //tworzymy nowy pusty obiekt biznesowy
            this.item = new Faktury();
        }
        #endregion Constructor

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
        #endregion Helpers
    }
}
