﻿using GalaSoft.MvvmLight.Messaging;
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
        private BaseCommand _SortDescCommand;
        private BaseCommand _SortAscCommand;
        private BaseCommand _FindCommand;
        #endregion Fields

        #region Constructor
        public AllViewModel()
        {
            this.kinoEntities = new KinoEntities();
            Messenger.Default.Register<String>(this, onSaveNewItem);
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

        #region Sort and Find
        public string SortField { get; set; }
        public List<String> SortComboboxItems
        {
            get
            {
                return getComboboxSortList();
            }
        }
        public ICommand SortDescCommand
        {
            get
            {
                if (_SortDescCommand == null)
                    _SortDescCommand = new BaseCommand(() => Sort(true));

                return _SortDescCommand;
            }
        }
        public ICommand SortAscCommand
        {
            get
            {
                if (_SortAscCommand == null)
                    _SortAscCommand = new BaseCommand(() => Sort(false));

                return _SortAscCommand;
            }
        }

        public string FindField { get; set; }
        public string FindTextBox { get; set; }
        public List<String> FindComboboxItems
        {
            get
            {
                return getComboboxFindList();
            }
        }
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());

                return _FindCommand;
            }
        }
        #endregion

        #region Helpers
        private void onSaveNewItem(string message)
        {
            if (message == this.ViewType + "Close")
                load();
        }

        public abstract void load();

        public void add()
        {
            Messenger.Default.Send(this.ViewType + "New");
        }

        public abstract void Sort(bool order);

        public abstract List<String> getComboboxSortList();

        public abstract void Find();

        public abstract List<String> getComboboxFindList();
        #endregion Helpers
    }
}
