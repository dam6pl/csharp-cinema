﻿using GalaSoft.MvvmLight.Messaging;
using Kino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kino.ViewModels.Abstract
{
    public abstract class SingleViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        protected KinoEntities kinoEntities;
        protected T item;
        private BaseCommand _SaveCommand;
        #endregion Fields

        #region Construktor
        public SingleViewModel()
        {
            this.kinoEntities = new KinoEntities();
        }
        #endregion Constructor

        #region Command
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => saveAndClose());
                return _SaveCommand;
            }
        }
        #endregion Command

        #region Helpers
        public abstract void Save();

        private void saveAndClose()
        {
            if (IsValid())
            {
                this.Save();
                Messenger.Default.Send(ViewType + "Close");
                onRequestClose();
            }
            else
                MessageBox.Show(
                    "Podczas zapisywania wystąpił błąd, popraw błędy is próbuj ponownie!", 
                    "Dodawanie rekordu",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
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
