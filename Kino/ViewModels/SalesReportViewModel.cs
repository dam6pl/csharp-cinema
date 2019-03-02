using Kino.Models;
using Kino.Models.BusinessLogic;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kino.ViewModels
{
    class SalesReportViewModel : WorkspaceViewModel
    {
        #region Fields
        private KinoEntities kinoEntities;
        #endregion

        #region Constructor
        public SalesReportViewModel()
            : base()
        {
            base.DisplayName = "Raport sprzedazy";
            this.kinoEntities = new KinoEntities();

            this.OdDaty = DateTime.Now.AddMonths(-1); 
            this.DoDaty = DateTime.Now;
        }
        #endregion Constructor

        #region Commands
        private BaseCommand _obliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_obliczCommand == null)
                    _obliczCommand = new BaseCommand(() => GetReportClick());

                return _obliczCommand;
            }
        }

        private BaseCommand _ClearPracownikCommand;
        public ICommand ClearPracownikCommand
        {
            get
            {
                if (_ClearPracownikCommand == null)
                    _ClearPracownikCommand = new BaseCommand(() => ClearPracownik());

                return _ClearPracownikCommand;
            }
        }

        private BaseCommand _ClearSalaCommand;
        public ICommand ClearSalaCommand
        {
            get
            {
                if (_ClearSalaCommand == null)
                    _ClearSalaCommand = new BaseCommand(() => ClearSala());

                return _ClearSalaCommand;
            }
        }

        private BaseCommand _ClearFilmCommand;
        public ICommand ClearFilmCommand
        {
            get
            {
                if (_ClearFilmCommand == null)
                    _ClearFilmCommand = new BaseCommand(() => ClearFilm());

                return _ClearFilmCommand;
            }
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
                    OnPropertyChanged(() => _OdDaty);
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
                    OnPropertyChanged(() => _DoDaty);
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
                    OnPropertyChanged(() => IdPracownika);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> PracownikComboBox
        {
            get
            {
                return new EmployeesB(kinoEntities).getEmployeeComboboxItems();
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
                    OnPropertyChanged(() => IdSali);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> SalaComboBox
        {
            get
            {
                return new RoomsB(kinoEntities).getRoomsComboboxItems();
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
                    OnPropertyChanged(() => IdFilmu);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> FilmComboBox
        {
            get
            {
                return new FilmsB(kinoEntities).getFilmsComboboxItems();
            }
        }

        private int? _ShowingCount;
        public int? ShowingCount
        {
            get
            {
                return _ShowingCount;
            }
            set
            {
                if (_ShowingCount != value)
                {
                    _ShowingCount = value;
                    OnPropertyChanged(() => ShowingCount);
                }
            }
        }

        private int? _TicketsCount;
        public int? TicketsCount
        {
            get
            {
                return _TicketsCount;
            }
            set
            {
                if (_TicketsCount != value)
                {
                    _TicketsCount = value;
                    OnPropertyChanged(() => TicketsCount);
                }
            }
        }
        
        private decimal? _IncomeCount;
        public decimal? IncomeCount
        {
            get
            {
                return _IncomeCount;
            }
            set
            {
                if (_IncomeCount != value)
                {
                    _IncomeCount = value;
                    OnPropertyChanged(() => IncomeCount);
                }
            }
        }
        #endregion

        #region Helpers
        private void GetReportClick()
        {
            SalesReportB salesReport = new SalesReportB(kinoEntities)
            {
                OdDaty = OdDaty,
                DoDaty = DoDaty,
                IdPracownika = IdPracownika,
                IdSali = IdSali,
                IdFilmu = IdFilmu
            };

            ShowingCount = salesReport.getShowingsCount() ?? 0;
            TicketsCount = salesReport.getTicketsCount() ?? 0;
            IncomeCount = salesReport.getIncomeCount() ?? 0;
        }

        private void ClearPracownik()
        {
            this.IdPracownika = null;
        }

        private void ClearSala()
        {
            this.IdSali = null;
        }

        private void ClearFilm()
        {
            this.IdFilmu = null;
        }
        #endregion
    }
}
