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
    class AddressesAllViewModel : AllViewModel<Adresy>
    {
        #region Constructor
        public AddressesAllViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie adresy";
        }
        #endregion Constructor

        #region Properties
        public IQueryable<ComboboxKeyAndValue> GenreComboboxItems
        {
            get
            {
                return
                    (
                        from gatunek in kinoEntities.Gatunki
                        select new ComboboxKeyAndValue
                        {
                            Key = gatunek.IdGatunku,
                            Value = gatunek.Nazwa
                        }
                    ).ToList().AsQueryable();

            }
        }

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
                    onRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new Addresses(kinoEntities).getAllAddresses();
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Ulica")
                List = new ObservableCollection<Adresy>(List.OrderBy(item => item.Ulica));
            else if (SortField == "Miejscowość")
                List = new ObservableCollection<Adresy>(List.OrderBy(item => item.Miejscowosc));
            else if (SortField == "Kod pocztowy")
                List = new ObservableCollection<Adresy>(List.OrderBy(item => item.KodPocztowy));
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
                List = new ObservableCollection<Adresy>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            else if (FindField == "Miejscowość")
                List = new ObservableCollection<Adresy>(List.Where(item => item.Miejscowosc != null && item.Miejscowosc.StartsWith(FindTextBox)));

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
