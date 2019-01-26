using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BussinesLogic
{
    public class UtargB : DatabaseClass
    {
        #region Constructor
        public UtargB(FakturyEntities fakturyEntities)
            : base(fakturyEntities)
        {
        }
        #endregion

        #region BussinesFunction
        public decimal? utargOkresTowar(DateTime odDaty, DateTime doDaty, int idDowaru)
        {
            return
                (
                    from pozycjaFaktury in fakturyEntities.PozycjeFakturies
                    where pozycjaFaktury.CzyAktywny == true
                        && pozycjaFaktury.Faktury.DataWystawienia >= odDaty
                        && pozycjaFaktury.Faktury.DataWystawienia <= doDaty
                        && pozycjaFaktury.Towary.IdTowaru == idDowaru
                    select (pozycjaFaktury.Cena * pozycjaFaktury.Ilosc) 
                        - (pozycjaFaktury.Cena * pozycjaFaktury.Ilosc * pozycjaFaktury.Rabat / 100)
                ).Sum();
        }
        #endregion
    }
}
