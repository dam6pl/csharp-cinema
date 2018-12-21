using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{   
    // to jest klasa ktora reprezentuje pojedynczy link ktory
    // bedzie sie wyswietlal z lewej strony okna glownego
    // kazdy link sklada sie:
    // - z nazwy ktora jest zapisana we wlaciwosci "DisplayName"
    // odziedziczonej z klasy BaseViewModel
    public class CommandViewModel : BaseViewModel
    {
        #region Properties
        // to jest akcja ktora zostanie podpieta pod link 
        // np: wywolaj zakladke Faktura
        public ICommand Command { get; private set; }
        #endregion

        #region Constructor
        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            this.DisplayName = displayName;
            this.Command = command;
        }
        #endregion

    }
}
