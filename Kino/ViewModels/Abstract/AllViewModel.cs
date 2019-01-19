using GalaSoft.MvvmLight.Messaging;
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
        private BaseCommand _AddCommand;
        private ObservableCollection<T> _List;
        #endregion Fields

        #region Constructor
        public AllViewModel()
        {
            this.kinoEntities = new KinoEntities();
        }
        #endregion Constructor

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

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                    _AddCommand = new BaseCommand(() => add());
                return _AddCommand;
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

        #region Helpers
        public abstract void load();

        public void add()
        {
            Messenger.Default.Send(this.DisplayName);
        }
        #endregion Helpers
    }
}
