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
    
    public class OrdersNewViewModel : SingleViewModel<Zamowienia>
    { 
        #region Construktor
        public OrdersNewViewModel()
            : base()
        {
            base.DisplayName = "Nowe zamowienie";

            this.item = new Zamowienia();
        }
        #endregion Constructor

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
        public IQueryable<ComboboxKeyAndValue> SeanseComboboxItems
        {
            get
            {
                return
                    (
                        from seans in kinoEntities.Seanse
                        select new ComboboxKeyAndValue
                        {
                            Key = seans.IdSeansu,
                            Value = seans.Sale.Nazwa + " - " + seans.Filmy.Tytuł + " - " + seans.Data
                        }
                    ).ToList().AsQueryable();
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
        public IQueryable<ComboboxKeyAndValue> KlienciComboboxItems
        {
            get
            {
                return
                    (
                        from klient in kinoEntities.Klienci
                        select new ComboboxKeyAndValue
                        {
                            Key = klient.IdKlienta,
                            Value = klient.Imie + " " + klient.Nazwisko
                        }
                    ).ToList().AsQueryable();
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
                return
                    (
                        from typBiletu in kinoEntities.TypyBiletow
                        select new ComboboxKeyAndValue
                        {
                            Key = typBiletu.IdTypuBiletu,
                            Value = typBiletu.Nazwa + " (Cena: " + typBiletu.Cena + ")"
                        }
                    ).ToList().AsQueryable();
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
                return
                    (
                        from pracownik in kinoEntities.Pracownicy
                        select new ComboboxKeyAndValue
                        {
                            Key = pracownik.IdPracownika,
                            Value = pracownik.Imie + " " + pracownik.Nazwisko 
                                + " (Stanowisko: " + pracownik.Stanowisko + ")"
                        }
                    ).ToList().AsQueryable();
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

        #endregion Properties

        #region Helpers
        public override void Save()
        {
            kinoEntities.Zamowienia.Add(item);
            kinoEntities.SaveChanges();
        }
        #endregion Helpers
    }
}
