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
    class OrdersAllViewModel : AllViewModel<OrdersForAllView>
    {
        #region Constructor
        public OrdersAllViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie zamowienia";
            base.ViewType = "Orders";
        }
        #endregion Constructor

        #region Properties
        private OrdersForAllView _SelectedOrder;
        public OrdersForAllView SelectedOrder
        {
            get
            {
                return _SelectedOrder;
            }
            set
            {
                if (_SelectedOrder != value)
                    _SelectedOrder = value;
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new OrdersB(kinoEntities).getAllOrders();
        }

        public override void remove()
        {
            if (SelectedOrder != null && this.removeAlert() == MessageBoxResult.Yes)
            {
                new OrdersB(kinoEntities).removeOrder(SelectedOrder.IdZamowienia);
                load();
            }
        }

        public override void modify()
        {
            if (SelectedOrder != null)
            {
                ModifyCommand command = new ModifyCommand
                {
                    Name = ViewType + "Modify",
                    Id = SelectedOrder.IdZamowienia
                };
                Messenger.Default.Send(command);
            }
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort(bool order)
        {
            if (SortField == "Seans")
                List = new ObservableCollection<OrdersForAllView>(
                    order
                    ? List.OrderBy(item => item.Seans)
                    : List.OrderByDescending(item => item.Seans)
                    );
            else if (SortField == "Klient")
                List = new ObservableCollection<OrdersForAllView>(
                    order
                    ? List.OrderBy(item => item.NazwaKlienta)
                    : List.OrderByDescending(item => item.NazwaKlienta)
                    );
            else if (SortField == "Typ biletu")
                List = new ObservableCollection<OrdersForAllView>(
                    order
                    ? List.OrderBy(item => item.TypBiletu)
                    : List.OrderByDescending(item => item.TypBiletu)
                    );
            else if (SortField == "Pracownik")
                List = new ObservableCollection<OrdersForAllView>(
                    order
                    ? List.OrderBy(item => item.Pracownik)
                    : List.OrderByDescending(item => item.Pracownik)
                    );
        }

        public override List<String> getComboboxSortList()
        {
            return new List<string>
            {
                "Seans",
                "Klient",
                "Typ biletu",
                "Pracownik"
            };
        }

        public override void Find()
        {
            load();

            if (FindField == "Senas")
                List = new ObservableCollection<OrdersForAllView>(List.Where(item => item.Seans != null
                && item.Seans.StartsWith(FindTextBox)));
            else if (FindField == "Klient")
                List = new ObservableCollection<OrdersForAllView>(List.Where(item => item.NazwaKlienta != null
                && item.NazwaKlienta.StartsWith(FindTextBox)));
            else if (FindField == "Typ biletu")
                List = new ObservableCollection<OrdersForAllView>(List.Where(item => item.TypBiletu != null
                && item.TypBiletu.StartsWith(FindTextBox)));
            else if (FindField == "Pracownik")
                List = new ObservableCollection<OrdersForAllView>(List.Where(item => item.Pracownik != null
                && item.Pracownik.StartsWith(FindTextBox)));

        }

        public override List<String> getComboboxFindList()
        {
            return new List<string>
            {
                "Seans",
                "Klient",
                "Typ biletu",
                "Pracownik"
            };
        }
        #endregion
    }
}
