using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class Orders : DatabaseClass
    {
        #region Constructor
        public Orders(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        public ObservableCollection<OrdersForAllView> getAllOrders()
        {
            return new ObservableCollection<OrdersForAllView>
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
    }
}
