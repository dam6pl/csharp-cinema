using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
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
            // set wywołuje się wtedy, gdy klikniemy na kontrahenta w oknie wyświetlającym wszystkich kontrahentów
            // dzięki właściwości SelectedItem która jest w <Data Grid>
            set
            {
                if(_WybranyKontrahent != value)
                {
                    _WybranyKontrahent = value;
                    // Po kliknięciu na kontrahenta wysyłany jest on Messengerem do okna z Nową fakturą
                    Messenger.Default.Send(_WybranyKontrahent);
                    // Następnie okno ze wszystkimi kontrahentami jest zamykane
                    onRequestClose();
                }
            }
        }
        #endregion Properties

        #region Helpers

        public override void load()
        {
            List = new ObservableCollection<KontrahenciForAllView>
                (
                    from kontrahent in fakturyEntities.Kontrahenci
                    select new KontrahenciForAllView
                    {
                        IdKontrahenta = kontrahent.IdKontrahenta,
                        Kod = kontrahent.Kod,
                        Nazwa = kontrahent.Nazwa,
                        NIP = kontrahent.NIP,
                        Adres = kontrahent.Adresy.Miasto + " " + kontrahent.Adresy.Ulica + " " 
                                + kontrahent.Adresy.NrDomu + " " + kontrahent.Adresy.NrLokalu,
                        Rodzaj = kontrahent.Rodzaje.Nazwa
                    }
                );
        }
        #endregion Helpers

        #region SortAndFind
        // W tej funkcji decydujemy jak sortować
        public override void Sort()
        {
        }
        // W tej funkcji decydujemy po czym możemy sortować
        public override List<string> GetComboBoxSortList()
        {
            return null;
        }
        // W tej funkcji decydujemy jak wyszukiwać
        public override void Find()
        {
        }
        // W tej funkcji decydujemy po jakich kolumnach możemy wyszukiwać
        public override List<string> GetComboBoxFindList()
        {
            return null;
        }
        #endregion SortAndFind

    }
}
