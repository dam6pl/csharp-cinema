using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{   
    // NowyTowarViewModel jest zakladka, a zatem dziedziczy po
    // WorkspaceViewModel
    public class NowyTowarViewModel : JedenViewModel<Towary> //pod typ generyczny T podstawiono typ Towary
    {
        #region Construktor
        public NowyTowarViewModel()
            : base()
        {
            // to jest nazwa ktora wyswietli sie na zakladce
            base.DisplayName = "Towar";
            //tworzymy nowy pusty obiekt biznesowy
            this.item = new Towary();
        }
        #endregion Constructor

        #region Properties
        //dla kazdego pola na interfejsie edytowalnego tworzymy propertisa z standardowym kodem
        public String Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (item.Kod != value)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod); //to jest funkcja ktora odpowiada za odswiezenie okna po zmienieniu pola Kod
                }
            }
        }
        public String Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public int? StawkaVatSprzedazy
        {
            get
            {
                return item.StawkaVatSprzedazy;
            }
            set
            {
                if (item.StawkaVatSprzedazy != value)
                {
                    item.StawkaVatSprzedazy = value;
                    OnPropertyChanged(() => StawkaVatSprzedazy);
                }
            }
        }
        public int? StawkaVatZakupu
        {
            get
            {
                return item.StawkaVatZakupu;
            }
            set
            {
                if (item.StawkaVatZakupu != value)
                {
                    item.StawkaVatZakupu = value;
                    OnPropertyChanged(() => StawkaVatZakupu);
                }
            }
        }
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    OnPropertyChanged(() => Cena);
                }
            }
        }
        public decimal? Marza
        {
            get
            {
                return item.Marza;
            }
            set
            {
                if (item.Marza != value)
                {
                    item.Marza = value;
                    OnPropertyChanged(() => Marza);
                }
            }
        }
        #endregion Properties

        #region Helpers
        //to jest metoda ktora zapisuje rekod
        public override void Save()
        {
            //najpierw dodajemy nowy rekord do lokalnej kolekcji
            fakturyEntities.Towaries.Add(item);
            //nastepnie zapisujemy zmiany w bazie danych
            fakturyEntities.SaveChanges();
        }
        #endregion Helpers
    }
}
