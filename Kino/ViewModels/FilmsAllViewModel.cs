using GalaSoft.MvvmLight.Messaging;
using Kino.Helpers;
using Kino.Models;
using Kino.Models.BusinessLogic;
using Kino.Models.EntitiesForView;
using Kino.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kino.ViewModels
{
    class FilmsAllViewModel : AllViewModel<FilmsForAllView>
    {
        #region Constructor
        public FilmsAllViewModel(bool modal = false)
            : base(modal)
        {
            base.DisplayName = "Wszystkie filmy";
            base.ViewType = "Films";
        }
        #endregion Constructor

        #region Properties
        private FilmsForAllView _SelectedFilm;
        public FilmsForAllView SelectedFilm
        {
            get
            {
                return _SelectedFilm;
            }
            set
            {
                if (_SelectedFilm != value)
                {
                    _SelectedFilm = value;
                    Messenger.Default.Send(_SelectedFilm);
                    if (modal) onRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new FilmsB(kinoEntities).getAllFilms();
        }

        public override void remove()
        {
            if (SelectedFilm != null && this.removeAlert() == MessageBoxResult.Yes)
            {
                if (!new FilmsB(kinoEntities).removeFilm(SelectedFilm.IdFilmu))
                    ShowMessageBox("Rekord nie może zostać usunięty! " +
                        "\nIstnieją seanse powiązane z tym rekordem.");
                load();
            }
        }

        public override void modify()
        {
            if (SelectedFilm != null)
            {
                ModifyCommand command = new ModifyCommand
                {
                    Name = ViewType + "Modify",
                    Id = SelectedFilm.IdFilmu
                };
                Messenger.Default.Send(command);
            }
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort(bool order)
        {
            if (SortField == "Tytuł")
                List = new ObservableCollection<FilmsForAllView>(
                    order
                    ? List.OrderBy(item => item.Tytul)
                    : List.OrderByDescending(item => item.Tytul)
                    );
            else if (SortField == "Opis")
                List = new ObservableCollection<FilmsForAllView>(
                    order
                    ? List.OrderBy(item => item.Opis)
                    : List.OrderByDescending(item => item.Opis)
                    );
            else if (SortField == "Reżyser")
                List = new ObservableCollection<FilmsForAllView>(
                    order
                    ? List.OrderBy(item => item.Rezyser)
                    : List.OrderByDescending(item => item.Rezyser)
                    );
            else if (SortField == "Rok produkcji")
                List = new ObservableCollection<FilmsForAllView>(
                    order
                    ? List.OrderBy(item => item.RokProdukcji)
                    : List.OrderByDescending(item => item.RokProdukcji)
                    );
            else if (SortField == "Czas trwania")
                List = new ObservableCollection<FilmsForAllView>(
                    order
                    ? List.OrderBy(item => item.CzasTrwania)
                    : List.OrderByDescending(item => item.CzasTrwania)
                    );
        }

        public override List<String> getComboboxSortList()
        {
            return new List<string>
            {
                "Tytuł",
                "Opis",
                "Reżyser",
                "Rok produkcji",
                "Czas trwania"
            };
        }

        public override void Find()
        {
            load();

            if (FindField == "Tytuł")
                List = new ObservableCollection<FilmsForAllView>(List.Where(item => item.Tytul != null
                && item.Tytul.StartsWith(FindTextBox)));
            else if (FindField == "Reżyser")
                List = new ObservableCollection<FilmsForAllView>(List.Where(item => item.Rezyser != null
                && item.Rezyser.StartsWith(FindTextBox)));
        }

        public override List<String> getComboboxFindList()
        {
            return new List<string>
            {
                "Tytuł",
                "Reżyser"
            };
        }
        #endregion
    }
}
