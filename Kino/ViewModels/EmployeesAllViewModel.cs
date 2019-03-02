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
    class EmployeesAllViewModel : AllViewModel<EmployeesForAllView>
    {
        #region Constructor
        public EmployeesAllViewModel()
            : base()
        {
            base.DisplayName = "Wszyscy pracownicy";
            base.ViewType = "Employees";
        }
        #endregion Constructor

        #region Properties
        private EmployeesForAllView _SelectedEmployee;
        public EmployeesForAllView SelectedEmployee
        {
            get
            {
                return _SelectedEmployee;
            }
            set
            {
                if (_SelectedEmployee != value)
                {
                    _SelectedEmployee = value;
                }
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new EmployeesB(kinoEntities).getAllEmployees();
        }

        public override void remove()
        {
            if (SelectedEmployee != null && this.removeAlert() == MessageBoxResult.Yes)
            {
                if (!new EmployeesB(kinoEntities).removeEmployee(SelectedEmployee.IdPracownika))
                    ShowMessageBox("Rekord nie może zostać usunięty!");
                load();
            }
        }

        public override void modify()
        {
            if (SelectedEmployee != null)
            {
                ModifyCommand command = new ModifyCommand
                {
                    Name = ViewType + "Modify",
                    Id = SelectedEmployee.IdPracownika
                };
                Messenger.Default.Send(command);
            }
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort(bool order)
        {
            if (SortField == "Imię")
                List = new ObservableCollection<EmployeesForAllView>(
                    order
                    ? List.OrderBy(item => item.Imie)
                    : List.OrderByDescending(item => item.Imie)
                    );
            else if (SortField == "Nazwisko")
                List = new ObservableCollection<EmployeesForAllView>(
                    order
                    ? List.OrderBy(item => item.Nazwisko)
                    : List.OrderByDescending(item => item.Nazwisko)
                    );
            else if (SortField == "Stanowisko")
                List = new ObservableCollection<EmployeesForAllView>(
                    order
                    ? List.OrderBy(item => item.Stanowisko)
                    : List.OrderByDescending(item => item.Stanowisko)
                    );
        }

        public override List<String> getComboboxSortList()
        {
            return new List<string>
            {
                "Imię",
                "Nazwisko",
                "Stanowisko"
            };
        }

        public override void Find()
        {
            load();

            if (FindField == "Imię")
                List = new ObservableCollection<EmployeesForAllView>(List.Where(item => item.Imie != null
                && item.Imie.Contains(FindTextBox)));
            else if (FindField == "Nazwisko")
                List = new ObservableCollection<EmployeesForAllView>(List.Where(item => item.Nazwisko != null
                && item.Nazwisko.Contains(FindTextBox)));
            else if (FindField == "Stanowisko")
                List = new ObservableCollection<EmployeesForAllView>(List.Where(item => item.Stanowisko != null
                && item.Stanowisko.Contains(FindTextBox)));
        }

        public override List<String> getComboboxFindList()
        {
            return new List<string>
            {
                "Imię",
                "Nazwisko",
                "Stanowisko"
            };
        }
        #endregion
    }
}
