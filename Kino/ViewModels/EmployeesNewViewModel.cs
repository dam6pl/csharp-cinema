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
    
    public class EmployeesNewViewModel : SingleViewModel<Pracownicy>
    { 
        #region Construktor
        public EmployeesNewViewModel()
            : base()
        {
            base.DisplayName = "Nowy pracownik";

            this.item = new Pracownicy();
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

        public string Stanowisko
        {
            get
            {
                return item.Stanowisko;
            }
            set
            {
                if (item.Stanowisko != value)
                {
                    item.Stanowisko = value;
                    OnPropertyChanged(() => Stanowisko);
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

        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                if (item.IdAdresu != value)
                {
                    item.IdAdresu = value;
                    OnPropertyChanged(() => IdAdresu);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> AdresyComboboxItems
        {
            get
            {
                return
                    (
                        from adres in kinoEntities.Adresy
                        select new ComboboxKeyAndValue
                        {
                            Key = adres.IdAdresu,
                            Value = adres.Ulica + " " + adres.NrDomu + ", "
                            + adres.Miejscowosc + " " + adres.KodPocztowy
                        }
                    ).ToList().AsQueryable();
            }
        }

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Pracownicy.Add(item);
            kinoEntities.SaveChanges();
        }
        #endregion Helpers
    }
}
