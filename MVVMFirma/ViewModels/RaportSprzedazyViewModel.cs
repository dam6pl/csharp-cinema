using MVVMFirma.Helpers;
using MVVMFirma.Models.BusinessLogic;
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
        #endregion Fields

        #region Properties
        // Dla każdego pola na widoku istotnego w obliczeniach, dodajemy pole i właściwość
        private DateTime _odDaty;
        public DateTime odDaty
        {
            get
            {
                return _odDaty;
            }
            set
            {
                if (_odDaty != value)
                {
                    _odDaty = value;
                    OnPropertyChanged(() => odDaty);
                }
            }
        }

        private DateTime _doDaty;
        public DateTime doDaty
        {
            get
            {
                return _doDaty;
            }
            set
            {
                if (_doDaty != value)
                {
                    _doDaty = value;
                    OnPropertyChanged(() => doDaty);
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
                    OnPropertyChanged(() => IdTowaru);
                }
            }
        }

        // Tworzymy teraz properties obsługującego ComboBoxa wyświetlającego towary
        public IQueryable<ComboBoxKeyAndValue> TowaryComboBoxItems
        {
            get
            {
                // To jest wywoładnie funkcji logiki biznesowej klasy TowaryB z warstwy Models
                return new TowarB(fakturyEntities).GetTowaryComboBoxItems();
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
                    OnPropertyChanged(() => Utarg);
                }
            }
        }

        #endregion Properties

        #region Command
        // To jest komenda która zostanie podpięta pod przycisk oblicz
        // i wywoła metodę ObliczUtargClick()
        private BaseCommand _obliczCommand;
        public ICommand obliczCommand
        {
            get
            {
                if(_obliczCommand == null)
                {
                    _obliczCommand = new BaseCommand(() => ObliczUtargClick());
                }
                return _obliczCommand;
            }
        }
        #endregion Command

        #region Constructor
        public RaportSprzedazyViewModel()
            : base()
        {
            fakturyEntities = new FakturyEntities();
            base.DisplayName = "Raport sprzedaży";
            // Dodatkowo konstruktor ustawi wartości domyślne pól
            odDaty = DateTime.Now; // Aktualna data
            doDaty = DateTime.Now;
            Utarg = 0;
        }
        #endregion Constructor

        #region Helpers
        private void ObliczUtargClick()
        {
            // Wykorzystamy teraz funkcję UtargOkresTowar z klasy logiki biznesowej UtargB z warstwy Models
           Utarg = new UtargB(fakturyEntities).UtargOkresTowar(odDaty, doDaty, IdTowaru);
        }
        #endregion Helpers
    }
}
