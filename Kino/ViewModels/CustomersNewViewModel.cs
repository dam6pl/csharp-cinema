using Kino.Models;
using Kino.Models.EntitiesForView;
using Kino.Models.Validators;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    
    public class CustomersNewViewModel : SingleViewModel<Klienci>, IDataErrorInfo
    { 
        #region Construktor
        public CustomersNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy klient";
            base.ViewType = "Customers";

            this.item = new Klienci();
        }
        #endregion Constructor

        #region Properties
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    OnPropertyChanged(() => Imie);
                }
            }
        }

        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    OnPropertyChanged(() => Nazwisko);
                }
            }
        }

        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                if (item.Email != value)
                {
                    item.Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
       
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    OnPropertyChanged(() => Telefon);
                }
            }
        }

        public DateTime? DataUrodzenia
        {
            get
            {
                return item.DataUrodzenia;
            }
            set
            {
                if (item.DataUrodzenia != value)
                {
                    item.DataUrodzenia = value;
                    OnPropertyChanged(() => DataUrodzenia);
                }
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Klienci.Add(item);
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
                if (name == "Imie")
                    komunikat = StringValidator.IsNotEmpty(this.Imie) ?? StringValidator.IsStartFromUpper(this.Imie);
                if (name == "Nazwisko")
                    komunikat = StringValidator.IsNotEmpty(this.Nazwisko) ?? StringValidator.IsStartFromUpper(this.Nazwisko);
                if (name == "Email")
                    komunikat = StringValidator.IsNotEmpty(this.Email) ?? BussinesValidator.IsValidEmail(this.Email);
                if (name == "Telefon")
                    komunikat = StringValidator.IsNotEmpty(this.Telefon) ?? BussinesValidator.IsValidPhoneNumber(this.Telefon);
                if (name == "DataUrodzenia")
                    komunikat = DateValidator.IsNotEmpty(this.DataUrodzenia) ?? DateValidator.IsInPast(this.DataUrodzenia);

                return komunikat;
            }
        }

        public override bool IsValid()
        {
            return this["Imie"] == null
                && this["Nazwisko"] == null
                && this["Email"] == null
                && this["Telefon"] == null
                && this["DataUrodzenia"] == null;
        }
        #endregion
    }
}
