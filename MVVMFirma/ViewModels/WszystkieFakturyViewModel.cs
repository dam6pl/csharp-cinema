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
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
            : base()
        // to jest lista inicjalizacyjna - wywoluje ona konstruktor z klasy WszystkieViewModel (bazowej)
        {
            base.DisplayName = "Faktury";
        }
        #endregion Constructor

        #region Helpers
        // To jest metoda która w klasie WszystkieViewModel była abstrakcyjna
        // zatem w tej klasie musi być nadpisana (override) oraz publiczna
        public override void load()
        {
            List = new ObservableCollection<FakturaForAllView>
                (   // Zapytanie LinQ (odpowiednik SQLa)
                    from faktura in fakturyEntities.Faktury // dla każdej faktury z bazdy danych
                    select new FakturaForAllView // tworzymy nową FakturaForAllView
                    {
                        IdFaktury = faktura.IdFaktury,
                        NumerFaktury = faktura.Numer,
                        DataWystawienia = faktura.DataWystawienia,
                        KontrahentKod = faktura.Kontrahenci.Kod,
                        KontrahentNazwa = faktura.Kontrahenci.Nazwa,
                        KontrahentNIP = faktura.Kontrahenci.NIP,
                        TerminPlatnosci = faktura.TerminPlatnosci,
                        SposobPlatnosciNazwa = faktura.SposobyPlatnosci.Nazwa
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
