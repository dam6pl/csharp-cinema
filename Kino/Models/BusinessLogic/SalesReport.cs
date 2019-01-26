using Kino.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Models.BusinessLogic
{
    class SalesReport : DatabaseClass
    {
        #region Constructor
        public SalesReport(KinoEntities kinoEntities)
            : base(kinoEntities)
        {
        }
        #endregion

        #region Properties
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
        public int? getShowingsCount()
        {
            var zapytanie =
                (
                   from zamowienie in kinoEntities.Zamowienia
                   where
                       zamowienie.Status == true &&
                       zamowienie.Data >= OdDaty &&
                       zamowienie.Data <= DoDaty
                   select zamowienie
               );

            if (IdPracownika != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.IdPracownika == IdPracownika
                        select zamowienie
                    );
            }

            if (IdSali != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.Seanse.IdSali == IdSali
                        select zamowienie
                    );
            }

            if (IdFilmu != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.Seanse.IdFilmu == IdFilmu
                        select zamowienie
                    );
            }

            return 
                (
                    from zamowienie in zapytanie
                    select zamowienie.IdSeansu
                ).Distinct().Count();
        }

        public int? getTicketsCount()
        {
            var zapytanie =
                (
                   from zamowienie in kinoEntities.Zamowienia
                   where
                       zamowienie.Status == true &&
                       zamowienie.Data >= OdDaty &&
                       zamowienie.Data <= DoDaty
                   select zamowienie
               );

            if (IdPracownika != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.IdPracownika == IdPracownika
                        select zamowienie
                    );
            }

            if (IdSali != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.Seanse.IdSali == IdSali
                        select zamowienie
                    );
            }

            if (IdFilmu != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.Seanse.IdFilmu == IdFilmu
                        select zamowienie
                    );
            }

            return zapytanie.Count();
        }

        public decimal? getIncomeCount()
        {
            var zapytanie =
                (
                   from zamowienie in kinoEntities.Zamowienia
                   where
                       zamowienie.Status == true &&
                       zamowienie.Data >= OdDaty &&
                       zamowienie.Data <= DoDaty
                   select zamowienie
               );

            if (IdPracownika != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.IdPracownika == IdPracownika
                        select zamowienie
                    );
            }

            if (IdSali != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.Seanse.IdSali == IdSali
                        select zamowienie
                    );
            }

            if (IdFilmu != null)
            {
                zapytanie =
                    (
                        from zamowienie in zapytanie
                        where
                            zamowienie.Seanse.IdFilmu == IdFilmu
                        select zamowienie
                    );
            }

            return 
                (
                    from zamowienie in zapytanie
                    select zamowienie.TypyBiletow.Cena
                ).Sum();
        }
        #endregion
    }
}
