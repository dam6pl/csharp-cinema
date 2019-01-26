using GalaSoft.MvvmLight.Messaging;
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

namespace Kino.ViewModels
{
    class FilmsAllViewModel : AllViewModel<FilmsForAllView>
    {
        #region Constructor
        public FilmsAllViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie filmy";
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
                    onRequestClose();
                }
            }
        }
        #endregion

        #region Helpers
        public override void load()
        {
            List = new Films(kinoEntities).getAllFilms();
        }
        #endregion Helpers

        #region Sort and Find
        public override void Sort()
        {
            if (SortField == "Tytuł")
                List = new ObservableCollection<FilmsForAllView>(List.OrderBy(item => item.Tytul));
            else if (SortField == "Opis")
                List = new ObservableCollection<FilmsForAllView>(List.OrderBy(item => item.Opis));
            else if (SortField == "Reżyser")
                List = new ObservableCollection<FilmsForAllView>(List.OrderBy(item => item.Rezyser));
            else if (SortField == "Rok produkcji")
                List = new ObservableCollection<FilmsForAllView>(List.OrderBy(item => item.RokProdukcji));
            else if (SortField == "Czas trwania")
                List = new ObservableCollection<FilmsForAllView>(List.OrderBy(item => item.CzasTrwania));
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
