using GalaSoft.MvvmLight.Messaging;
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

namespace Kino.ViewModels
{
    class CustomersAllViewModel : AllViewModel<Klienci>
    {
        #region Constructor
        public CustomersAllViewModel()
            : base()
        {
            base.DisplayName = "Wszyscy klienci";
        }
        #endregion Constructor

        #region Properties
        private Klienci _SelectedCustomer;
        public Klienci SelectedCustomer
        {
            get
            {
                return _SelectedCustomer;
            }
            set
            {
                if (_SelectedCustomer != value)
                {
                    _SelectedCustomer = value;
                    Messenger.Default.Send(_SelectedCustomer);
                    onRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new Customers(kinoEntities).getAllCustomers();
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Imię")
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Imie));
            else if (SortField == "Nazwisko")
                List = new ObservableCollection<Klienci>(List.OrderBy(item => item.Nazwisko));
        }

        public override List<String> getComboboxSortList()
        {
            return new List<string>
            {
                "Imię",
                "Nazwisko"
            };
        }

        public override void Find()
        {
            load();

            if (FindField == "Imię")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Imie != null
                && item.Imie.StartsWith(FindTextBox)));
            else if (FindField == "Nazwisko")
                List = new ObservableCollection<Klienci>(List.Where(item => item.Nazwisko != null
                && item.Nazwisko.StartsWith(FindTextBox)));
        }

        public override List<String> getComboboxFindList()
        {
            return new List<string>
            {
                "Imię",
                "Nazwisko"
            };
        }
        #endregion
    }
}
