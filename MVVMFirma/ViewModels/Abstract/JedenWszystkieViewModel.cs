using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirma.ViewModels.Abstract
{
    public abstract class JedenWszystkieViewModel<J,W> : JedenViewModel<J>
    {
        #region Fields
        private BaseCommand _LoadListCommand;
        private BaseCommand _ShowAddViewCommand;
        private ObservableCollection<W> _List;
        protected string DisplayListName;
        #endregion Fields

        #region Properties
        public ICommand ShowAddViewCommand
        {
            get
            {
                if (_ShowAddViewCommand == null)
                {
                    _ShowAddViewCommand = new BaseCommand(() => showAddView());
                }
                return _ShowAddViewCommand;
            }
        }
        public ObservableCollection<W> List
        {
            get
            {
                if (_List == null)
                    loadList();

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
        public JedenWszystkieViewModel()
            : base()
        {
        }
        #endregion Constructor

        #region Helpers
        public abstract void loadList();
       
        private void showAddView()
        {
            Messenger.Default.Send(DisplayListName + "Add");
        }
        #endregion Helpers
    }
}
