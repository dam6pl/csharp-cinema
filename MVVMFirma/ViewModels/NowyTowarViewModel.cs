using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validators;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{   
    // NowyTowarViewModel jest zakladka, a zatem dziedziczy po
    // WorkspaceViewModel
    public class NowyTowarViewModel : JedenViewModel<Towary>, IDataErrorInfo    // pod typ generyczny T podstawiono typ Towary
    {
        #region Constructor
        public NowyTowarViewModel()
            :base()
        {
            // to jest nazwa ktora wyswietli sie na zakladce
            base.DisplayName = "Nowy Towar";
            // tworzymy nowy pusty obiekt
            this.item = new Towary();
        }
        #endregion Constructor

        #region Properties
        // Dla każdego pola na interfejsie edytowalnego, tworzymy propertiesa standardowym kodem
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if(item.Kod != value)
                {
                    item.Kod = value;
                    OnPropertyChanged(() => Kod); // to jest funkcja która odpowiada za odświeżenie okna po zmianie pola Kod
                }
            }
        }
        public string Nazwa
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
                    OnPropertyChanged(() => Nazwa); // to jest funkcja która odpowiada za odświeżenie okna po zmianie pola Nazwa
                }
            }
        }
        public int? StawkaVatTowaruZakup
        {
            get
            {
                return item.StawkaVatTowaruZakup;
            }
            set
            {
                if (item.StawkaVatTowaruZakup != value)
                {
                    item.StawkaVatTowaruZakup = value;
                    OnPropertyChanged(() => StawkaVatTowaruZakup); 
                }
            }
        }
        public int? StawkaVatTowaruSprzedaz
        {
            get
            {
                return item.StawkaVatTowaruSprzedaz;
            }
            set
            {
                if (item.StawkaVatTowaruSprzedaz != value)
                {
                    item.StawkaVatTowaruSprzedaz = value;
                    OnPropertyChanged(() => StawkaVatTowaruSprzedaz);
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
        // To jest metoda która zapisuje rekord
        public override void Save()
        {
            // Najpierw dodajemy nowy rekord do lokalnej kolekcji
            fakturyEntities.Towary.Add(item);
            // Następnie zapisujemy zmiany w bazie danych 
            fakturyEntities.SaveChanges();
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
                if (name == "Nazwa")
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwa);
                else if (name == "StawkaVatTowaruSprzedaz")
                    komunikat = BusinessValidator.SprawdzVat(this.StawkaVatTowaruSprzedaz);
                else if (name == "StawkaVatTowaruZakup")
                    komunikat = BusinessValidator.SprawdzVat(this.StawkaVatTowaruZakup);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Nazwa"] == null
                && this["StawkaVatTowaruSprzedaz"] == null 
                && this["StawkaVatTowaruZakup"] == null;
        }
        #endregion
    }
}
