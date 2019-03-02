using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class SalesReportB : DatabaseClass
    {
        #region Fields
        private IQueryable<Zamowienia> _Orders;
        #endregion

        #region Constructor
        public SalesReportB(KinoEntities kinoEntities)
            : base(kinoEntities)
        {

        }
        #endregion

        #region Properties
        public IQueryable<Zamowienia> Orders
        {
            get
            {
                if (_Orders == null)
                    _Orders = getOrders();

                return _Orders;
            }
        }

        private DateTime _OdDaty;
        public DateTime OdDaty
        {
            get
            {
                return _OdDaty;
            }
            set
            {
                if (_OdDaty != value)
                {
                    _OdDaty = value;
                }
            }
        }

        private DateTime _DoDaty;
        public DateTime DoDaty
        {
            get
            {
                return _DoDaty;
            }
            set
            {
                if (_DoDaty != value)
                {
                    _DoDaty = value;
                }
            }
        }

        private int? _IdPracownika;
        public int? IdPracownika
        {
            get
            {
                return _IdPracownika;
            }
            set
            {
                if (_IdPracownika != value)
                {
                    _IdPracownika = value;
                }
            }
        }

        private int? _IdSali;
        public int? IdSali
        {
            get
            {
                return _IdSali;
            }
            set
            {
                if (_IdSali != value)
                {
                    _IdSali = value;
                }
            }
        }

        private int? _IdFilmu;
        public int? IdFilmu
        {
            get
            {
                return _IdFilmu;
            }
            set
            {
                if (_IdFilmu != value)
                {
                    _IdFilmu = value;
                }
            }
        }
        #endregion

        #region Helpers
        private IQueryable<Zamowienia> getOrders()
        {
            var databaseRequest =
                (
                   from zamowienie in kinoEntities.Zamowienia
                   where
                       zamowienie.CzyAktywny == true &&
                       zamowienie.Status == true &&
                       zamowienie.Data >= OdDaty &&
                       zamowienie.Data <= DoDaty
                   select zamowienie
               );

            if (IdPracownika != null)
            {
                databaseRequest =
                    (
                        from zamowienie in databaseRequest
                        where zamowienie.IdPracownika == IdPracownika
                        select zamowienie
                    );
            }

            if (IdSali != null)
            {
                databaseRequest =
                    (
                        from zamowienie in databaseRequest
                        where zamowienie.Seanse.IdSali == IdSali
                        select zamowienie
                    );
            }

            if (IdFilmu != null)
            {
                databaseRequest =
                    (
                        from zamowienie in databaseRequest
                        where zamowienie.Seanse.IdFilmu == IdFilmu
                        select zamowienie
                    );
            }

            return databaseRequest;
        }

        public int? getShowingsCount()
        {
            return 
                (
                    from zamowienie in this.Orders
                    select zamowienie.IdSeansu
                ).Distinct().Count();
        }

        public int? getTicketsCount()
        {
            return this.Orders.Count();
        }

        public decimal? getIncomeCount()
        {
            return 
                (
                    from zamowienie in this.Orders
                    select zamowienie.TypyBiletow.Cena
                ).Sum();
        }
        #endregion
    }
}
