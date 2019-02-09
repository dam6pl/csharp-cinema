using GalaSoft.MvvmLight.Messaging;
using Kino.Helpers;
using Kino.Models;
using Kino.Models.BusinessLogic;
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
    class RoomsAllViewModel : AllViewModel<Sale>
    {
        #region Constructor
        public RoomsAllViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie sale";
            base.ViewType = "Rooms";
        }
        #endregion Constructor

        #region Properties
        private Sale _SelectedRoom;
        public Sale SelectedRoom
        {
            get
            {
                return _SelectedRoom;
            }
            set
            {
                if (_SelectedRoom != value)
                    _SelectedRoom = value;
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new RoomsB(kinoEntities).getAllRooms();
        }

        public override void remove()
        {
            if (SelectedRoom != null)
            {
                if (!new RoomsB(kinoEntities).removeRoom(SelectedRoom.IdSali))
                    ShowMessageBox("Rekord nie może zostać usunięty! " +
                        "\nIstnieją seanse powiązane z tym rekordem.");
                load();
            }
        }

        public override void modify()
        {
            if (SelectedRoom != null && this.removeAlert() == MessageBoxResult.Yes)
            {
                ModifyCommand command = new ModifyCommand
                {
                    Name = ViewType + "Modify",
                    Id = SelectedRoom.IdSali
                };
                Messenger.Default.Send(command);
            }
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort(bool order)
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<Sale>(
                    order
                    ? List.OrderBy(item => item.Nazwa)
                    : List.OrderByDescending(item => item.Nazwa)
                    );
            else if (SortField == "Liczba miejsc")
                List = new ObservableCollection<Sale>(
                    order
                    ? List.OrderBy(item => item.LiczbaMiejsc)
                    : List.OrderByDescending(item => item.LiczbaMiejsc)
                    );
        }

        public override List<String> getComboboxSortList()
        {
            return new List<string>
            {
                "Nazwa",
                "Liczba miejsc"
            };
        }

        public override void Find()
        {
            load();

            if (FindField == "Nazwa")
                List = new ObservableCollection<Sale>(List.Where(item => item.Nazwa != null
                && item.Nazwa.StartsWith(FindTextBox)));

        }

        public override List<String> getComboboxFindList()
        {
            return new List<string>
            {
                "Nazwa"
            };
        }
        #endregion
    }
}
