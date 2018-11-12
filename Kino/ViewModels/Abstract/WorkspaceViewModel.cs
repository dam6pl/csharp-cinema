using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kino.ViewModels.Abstract
{
    public abstract class WorkspaceViewModel : BaseViewModel
    {
        #region Fields
        private BaseCommand _CloseCommand;
        #endregion Fields

        #region Constructor
        public WorkspaceViewModel()
        {

        }
        #endregion Construktor

        #region Command
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => onRequestClose());
                return _CloseCommand;
            }
        }
        #endregion Command

        #region RequestClose
        public event EventHandler RequestClose;
        protected void onRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        #endregion RequestClose
    }
}
