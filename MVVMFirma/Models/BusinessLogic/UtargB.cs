using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.Models.BusinessLogic
{
    public class UtargB : DataBaseClass
    {
        #region Constructor
        public UtargB(FakturyEntities fakturyEntities) 
            : base(fakturyEntities)
        {
        }
        #endregion Constructor

        #region BusinessFunction
        // To jest funkcja która będzie liczyła utarg w podanym jako parametr w okresie, dla podanego jako parametr towaru
        // Ta funkcja zostanie wywołana w RaportSprzedazyViewModel
        public decimal? UtargOkresTowar(DateTime odDaty, DateTime doDaty, int idTowaru)
        {
            return
                (
                    from pozycja in fakturyEntities.PozycjeFaktury
                    where 
                        pozycja.CzyAktywny == true &&
                        pozycja.Faktury.DataWystawienia >= odDaty &&
                        pozycja.Faktury.DataWystawienia <= doDaty &&
                        pozycja.Towary.IdTowaru == idTowaru
                    select (pozycja.Cena * pozycja.Ilosc) - (pozycja.Cena * pozycja.Ilosc * (pozycja.Rabat/100))
                ).Sum();
        }
        #endregion BusinessFunction
    }
}
