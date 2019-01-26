using Kino.Models;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    
    public class CustomersNewViewModel : SingleViewModel<Klienci>
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
    }
}
