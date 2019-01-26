using Kino.Models;
using Kino.Models.BusinessLogic;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #region Helpers
        public override void load()
        {
            List = new Rooms(kinoEntities).getAllRooms();
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
