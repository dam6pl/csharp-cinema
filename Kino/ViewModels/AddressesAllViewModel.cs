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
    class AddressesAllViewModel : AllViewModel<Adresy>
    {
        #region Constructor
        public AddressesAllViewModel(bool modal = false)
            : base(modal)
        {
            base.DisplayName = "Wszystkie adresy";
            base.ViewType = "Addresses";
        }
        #endregion Constructor

        #region Properties
        private Adresy _SelectedAddress;
        public Adresy SelectedAddress
        {
            get
            {
                return _SelectedAddress;
            }
            set
            {
                if (_SelectedAddress != value)
                {
                    _SelectedAddress = value;
                    Messenger.Default.Send(_SelectedAddress);
                    if (modal) onRequestClose();
                }
            }
        }

        public MessageBoxResult DialogResult { get; private set; }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new AddressesB(kinoEntities).getAllAddresses();
        }

        public override void remove()
        {
            if (SelectedAddress != null && this.removeAlert() == MessageBoxResult.Yes)
            {
                if (!new AddressesB(kinoEntities).removeAddress(SelectedAddress.IdAdresu))
                    ShowMessageBox("Rekord nie może zostać usunięty!");
                load();
            }
        }

        public override void modify()
        {
            if (SelectedAddress != null)
            {
                ModifyCommand command = new ModifyCommand
                {
                    Name = ViewType + "Modify",
                    Id = SelectedAddress.IdAdresu
                };
                Messenger.Default.Send(command);
            }
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort(bool order)
        {
            if (SortField == "Ulica")
                List = new ObservableCollection<Adresy>(
                    order 
                    ? List.OrderBy(item => item.Ulica) 
                    : List.OrderByDescending(item => item.Ulica)
                    );
            else if (SortField == "Miejscowość")
                List = new ObservableCollection<Adresy>(
                    order 
                    ? List.OrderBy(item => item.Miejscowosc) 
                    : List.OrderByDescending(item => item.Miejscowosc)
                    );
            else if (SortField == "Kod pocztowy")
                List = new ObservableCollection<Adresy>(
                    order
                    ? List.OrderBy(item => item.KodPocztowy)
                    : List.OrderByDescending(item => item.KodPocztowy)
                    );
        }

        public override List<String> getComboboxSortList()
        {
            return new List<string>
            {
                "Ulica",
                "Miejscowość",
                "Kod pocztowy"
            };
        }

        public override void Find()
        {
            load();

            if (FindField == "Ulica")
                List = new ObservableCollection<Adresy>(List.Where(item => item.Ulica != null && item.Ulica.Contains(FindTextBox)));
            else if (FindField == "Miejscowość")
                List = new ObservableCollection<Adresy>(List.Where(item => item.Miejscowosc != null && item.Miejscowosc.Contains(FindTextBox)));

        }

        public override List<String> getComboboxFindList()
        {
            return new List<string>
            {
                "Ulica",
                "Miejscowość"
            };
        }
        #endregion
    }
}
