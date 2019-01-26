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
            : base() //to jest lista inicjalizacyjna, wywoluje ona konstruktor z klasy WszystkieViewModel - bazowej
        {
            base.DisplayName = "Towary";
        }
        #endregion Constructor

        #region Helpers
        //to jest metoda ktora w klasie WszytskieViewModel byla abstrakcyjna
        //zatem w tej klasie musi byc nadpisana (override) i publiczna
        public override void load()
        {
            List = new ObservableCollection<Towary>
                (
                from towar in fakturyEntities.Towaries
                select towar
                );
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.Nazwa));
            else if (SortField == "Kod")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.Kod));
            else if (SortField == "Cena")
                List = new ObservableCollection<Towary>(List.OrderBy(item => item.Cena));
        }
        public override List<String> getComboboxSortList()
        {
            return new List<string>
            {
                "Nazwa",
                "Kod",
                "Cena"
            };
        }
        public override void Find()
        {
            load();

            if (FindField == "Nazwa")
                List = new ObservableCollection<Towary>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            else if (FindField == "Kod")
                List = new ObservableCollection<Towary>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));

        }
        public override List<String> getComboboxFindList()
        {
            return new List<string>
            {
                "Nazwa",
                "Kod"
            };
        }
        #endregion
    }
}
