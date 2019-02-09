using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class WszystkieTowaryViewModel : WszystkieViewModel<Towary>
    {
        #region Constructor
        public WszystkieTowaryViewModel()
            : base()
            // to jest lista inicjalizacyjna - wywoluje ona konstruktor z klasy WszystkieViewModel (bazowej)
        {
            base.DisplayName = "Towary";
        }
        #endregion Constructor

        #region Helpers
        // To jest metoda która w klasie WszystkieViewModel była abstrakcyjna
        // zatem w tej klasie musi być nadpisana (override) oraz publiczna
        public override void load()
        {
            List = new ObservableCollection<Towary>
                (   // Zapytanie LinQ (odpowiednik SQLa)
                    from towar in fakturyEntities.Towary
                    select towar 
                );
        }
        #endregion Helpers

        #region SortAndFind
        // W tej funkcji decydujemy jak sortować
        public override void Sort()
        {
            if(SortField == "Nazwa")
            {
                List = new ObservableCollection<Towary>(List.OrderBy(Item => Item.Nazwa));
            }
            if (SortField == "Kod")
            {
                List = new ObservableCollection<Towary>(List.OrderBy(Item => Item.Kod));
            }
            if (SortField == "Cena")
            {
                List = new ObservableCollection<Towary>(List.OrderBy(Item => Item.Cena));
            }
        }
        // W tej funkcji decydujemy po czym możemy sortować
        public override List<string> GetComboBoxSortList()
        {

            return new List<string>
            {
                "Nazwa" , "Kod" , "Cena"
            };
        }
        // W tej funkcji decydujemy jak wyszukiwać
        public override void Find()
        {
            load();

            if(FindField == "Nazwa")
            {
                List = new ObservableCollection<Towary>
                    (List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Kod")
            {
                List = new ObservableCollection<Towary>
                    (List.Where(Item => Item.Kod != null && Item.Kod.StartsWith(FindTextBox)));
            }
        }
        // W tej funkcji decydujemy po jakich kolumnach możemy wyszukiwać
        public override List<string> GetComboBoxFindList()
        {
            return new List<string>
            {
                "Nazwa" , "Kod"
            };
        }
        #endregion SortAndFind
    }
}
