using GalaSoft.MvvmLight.Messaging;
using Kino.Helpers;
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
using System.Windows;

namespace Kino.ViewModels
{
    class CustomersAllViewModel : AllViewModel<Klienci>
    {
        #region Constructor
        public CustomersAllViewModel(bool modal = false)
            : base(modal)
        {
            base.DisplayName = "Wszyscy klienci";
            base.ViewType = "Customers";
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
                    if (modal) onRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new CustomersB(kinoEntities).getAllCustomers();
        }

        public override void remove()
        {
            if (SelectedCustomer != null && this.removeAlert() == MessageBoxResult.Yes)
            {
                if (!new CustomersB(kinoEntities).removeCustomer(SelectedCustomer.IdKlienta))
                    ShowMessageBox("Rekord nie może zostać usunięty! " +
                        "\nIstnieją zamówienia powiązane z tym rekordem.");
                load();
            }
        }

        public override void modify()
        {
            if (SelectedCustomer != null)
            {
                ModifyCommand command = new ModifyCommand
                {
                    Name = ViewType + "Modify",
                    Id = SelectedCustomer.IdKlienta
                };
                Messenger.Default.Send(command);
            }
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort(bool order)
        {
            if (SortField == "Imię")
                List = new ObservableCollection<Klienci>(
                    order
                    ? List.OrderBy(item => item.Imie)
                    : List.OrderByDescending(item => item.Imie)
                    );
            else if (SortField == "Nazwisko")
                List = new ObservableCollection<Klienci>(
                    order
                    ? List.OrderBy(item => item.Nazwisko)
                    : List.OrderByDescending(item => item.Nazwisko)
                    );
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
