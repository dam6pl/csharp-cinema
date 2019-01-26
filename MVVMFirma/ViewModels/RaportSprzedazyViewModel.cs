using MVVMFirma.Helpers;
using MVVMFirma.Models.BussinesLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class RaportSprzedazyViewModel : WorkspaceViewModel
    {
        #region Fields
        private FakturyEntities fakturyEntities;
        #endregion

        #region Constructor
        public RaportSprzedazyViewModel()
            : base()
        {
            base.DisplayName = "Raport sprzedazy";
            this.fakturyEntities = new FakturyEntities();
            this.OdDaty = DateTime.Now;
            this.DoDaty = DateTime.Now;
            this.Utarg = 0;
        }
        #endregion Constructor

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

        private int _IdTowaru;
        public int IdTowaru
        {
            get
            {
                return _IdTowaru;
            }
            set
            {
                if (_IdTowaru != value)
                {
                    _IdTowaru = value;
                    OnPropertyChanged(() => _IdTowaru);
                }
            }
        }
        public IQueryable<ComboboxKeyAndValue> TowaryComboboxItems
        {
            get
            {
                return new TowarB(fakturyEntities).getTowaryComboboxItems();
            }
        }
        private decimal? _Utarg;
        public decimal? Utarg
        {
            get
            {
                return _Utarg;
            }
            set
            {
                if (_Utarg != value)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => _Utarg);
                }
            }
        }
        #endregion

        #region Commands
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => ObliczUtargClick());

                return _ObliczCommand;
            }
        }
        #endregion

        #region Helpers
        private void ObliczUtargClick()
        {
            Utarg = new UtargB(fakturyEntities).utargOkresTowar(OdDaty, DoDaty, IdTowaru);
        }
        #endregion
    }
}
