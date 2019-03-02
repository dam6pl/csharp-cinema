﻿using GalaSoft.MvvmLight.Messaging;
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
    class ShowingsAllViewModel : AllViewModel<ShowingsForAllView>
    {
        #region Constructor
        public ShowingsAllViewModel(bool modal = false)
            : base(modal)
        {
            base.DisplayName = "Wszystkie seanse";
            base.ViewType = "Showings";
        }
        #endregion Constructor

        #region properties
        private ShowingsForAllView _SelectedShowing;
        public ShowingsForAllView SelectedShowing
        {
            get
            {
                return _SelectedShowing;
            }
            set
            {
                if (_SelectedShowing != value)
                {
                    _SelectedShowing = value;
                    Messenger.Default.Send(_SelectedShowing);
                    if (modal) onRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new ShowingsB(kinoEntities).getAllShowings();
        }

        public override void remove()
        {
            if (SelectedShowing != null && this.removeAlert() == MessageBoxResult.Yes)
            {
                if (!new ShowingsB(kinoEntities).removeShowing(SelectedShowing.IdSeansu))
                    ShowMessageBox("Rekord nie może zostać usunięty!");
                load();
            }
        }

        public override void modify()
        {
            if (SelectedShowing != null)
            {
                ModifyCommand command = new ModifyCommand
                {
                    Name = ViewType + "Modify",
                    Id = SelectedShowing.IdSeansu
                };
                Messenger.Default.Send(command);
            }
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort(bool order)
        {
            if (SortField == "Film")
                List = new ObservableCollection<ShowingsForAllView>(
                    order
                    ? List.OrderBy(item => item.NazwaFilmu)
                    : List.OrderByDescending(item => item.NazwaFilmu)
                    );
            else if (SortField == "Sala")
                List = new ObservableCollection<ShowingsForAllView>(
                    order
                    ? List.OrderBy(item => item.NazwaSali)
                    : List.OrderByDescending(item => item.NazwaSali)
                    );
            else if (SortField == "Data")
                List = new ObservableCollection<ShowingsForAllView>(
                    order
                    ? List.OrderBy(item => item.Data)
                    : List.OrderByDescending(item => item.Data)
                    );
        }

        public override List<String> getComboboxSortList()
        {
            return new List<string>
            {
                "Film",
                "Sala",
                "Data"
            };
        }

        public override void Find()
        {
            load();

            if (FindField == "Film")
                List = new ObservableCollection<ShowingsForAllView>(List.Where(item => item.NazwaFilmu != null 
                && item.NazwaFilmu.Contains(FindTextBox)));
            else if (FindField == "Sala")
                List = new ObservableCollection<ShowingsForAllView>(List.Where(item => item.NazwaSali != null
                && item.NazwaSali.Contains(FindTextBox)));

        }

        public override List<String> getComboboxFindList()
        {
            return new List<string>
            {
                "Film",
                "Sala"
            };
        }
        #endregion
    }
}
