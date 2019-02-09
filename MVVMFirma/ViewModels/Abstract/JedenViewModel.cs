using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{
    // Jeżeli klasa działa na jakimś typie, który przybiera konkretną instancję w klasie dziedziczącej, to tę klasę powinniśmy oprzeć
    // na mechanizmie typów generycznych, w tym przypadku <T>
    // Typ T to dowolny typ obiektu które zostanie dodany do klasy
    // O typie tym zdecydujemy w klasie dziedziczącej
    // Np w klasie NowyTowar, T będzie typem Towary
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        // tworzymy obiekt do połączenia z bazą danych
        protected FakturyEntities fakturyEntities;
        // obiekt item klasy generycznej T
        protected T item;
        // to jest komenda która zostanie podpięta pod przycisk zapisz
        private BaseCommand _SaveCommand;
        #endregion Fields

        #region Constructor
        public JedenViewModel()
        {
            // to jest utworzenie połączenia z bazą danych
            this.fakturyEntities = new FakturyEntities();
        }
        #endregion Constructor

        #region Command
        // To jest komenda która zostanie podpięta pod przycisk zapisu
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                { // ta komenda wywoła metodę saveAndClose() która zapisze rekord i zamknie zakładkę
                    _SaveCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveCommand;
            }
        }
        #endregion Command

        #region Helpers
        // To jest abstrakcyjna Save metoda która zapisuje rekord
        public abstract void Save();

        // to jest metoda która zapisuje rekord i zamyka zakładkę
        private void saveAndClose()
        {
            if (IsValid())
            {
                // Najpierw zapisujemy rekord
                this.Save();
                // A następnie zamykamy zakładkę
                onRequestClose();
            }
            else
                ShowMessageBox("Przed zapisem popraw wszystkie błędy");
        }
        #endregion Helpers

        #region Validations
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion
    }
}
