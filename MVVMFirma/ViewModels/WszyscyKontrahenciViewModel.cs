using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahenciForAllView>
    {
        #region Constructor
        public WszyscyKontrahenciViewModel()
            : base()
        {
            base.DisplayName = "Kontrahenci";
        }
        #endregion Constructor

        #region Properties
        private KontrahenciForAllView _WybranyKontrahent;
        public KontrahenciForAllView WybranyKontrahent
        {
            get
            {
                return _WybranyKontrahent;
            }
            set
            {
                if (_WybranyKontrahent != value)
                {
                    _WybranyKontrahent = value;
                    Messenger.Default.Send(_WybranyKontrahent);
                    onRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<KontrahenciForAllView>
                (
                from kontrahent in fakturyEntities.Kontrahencis
                select new KontrahenciForAllView
                {
                    IdKontrahenta = kontrahent.IdKontrahenta,
                    Kod = kontrahent.Kod,
                    NIP = kontrahent.NIP,
                    Nazwa = kontrahent.Nazwa,
                    Rodzaj = kontrahent.Rodzaje.Nazwa,
                    Adres = kontrahent.Adresy.Miasto + ",  " + kontrahent.Adresy.Ulica
                    + "  " + kontrahent.Adresy.NrDomu + "/" + kontrahent.Adresy.NrLokalu
                }
                );
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort()
        {

        }
        public override List<String> getComboboxSortList()
        {
            return null;
        }
        public override void Find()
        {

        }
        public override List<String> getComboboxFindList()
        {
            return null;
        }
        #endregion
    }
}
