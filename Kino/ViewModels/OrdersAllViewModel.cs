﻿using Kino.Models;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.ViewModels
{
    class OrdersAllViewModel : AllViewModel<OrdersForAllView>
    {
        #region Constructor
        public OrdersAllViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie zamowienia";
        }
        #endregion Constructor

        #region Properties
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
        #endregion

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<OrdersForAllView>
                (
                from zamowienie in kinoEntities.Zamowienia
                select new OrdersForAllView
                    {
                        IdZamowienia = zamowienie.IdZamowienia,
                        Seans = zamowienie.Seanse.Sale.Nazwa + " - " + zamowienie.Seanse.Filmy.Tytuł 
                            + " - " + zamowienie.Seanse.Data,
                        NazwaKlienta = zamowienie.Klienci.Imie + " " + zamowienie.Klienci.Nazwisko,
                        TypBiletu = zamowienie.TypyBiletow.Nazwa,
                        Pracownik = zamowienie.Pracownicy.Imie + " " + zamowienie.Pracownicy.Nazwisko,
                        Status = zamowienie.Status
                    }
                );
        }
        #endregion Helpers
    }
}