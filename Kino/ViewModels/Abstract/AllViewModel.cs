using Kino.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kino.ViewModels.Abstract
{
    public abstract class AllViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        protected KinoEntities kinoEntities;
        private BaseCommand _LoadCommand;
        private ObservableCollection<T> _List;
        #endregion Fields

        #region Properties
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => load());
                return _LoadCommand;
            }
        }
        
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    load();
                return _List;
            }
            set
            {
                if (_List != value)
                {
                    _List = value;
                    OnPropertyChanged(() => List);
                }
            }
        }
        #endregion Properties

        #region Constructor
        public AllViewModel()
        {
            this.kinoEntities = new KinoEntities();
        }
        #endregion Constructor

        #region Helpers
        public abstract void load();
        #endregion Helpers
    }
}
