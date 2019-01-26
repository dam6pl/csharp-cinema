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
    //to jest klasa, z ktorej beda dziedziczyly wszystkie view modele zgodne ze scenariuszem "wszystkie" np. wszystkie towary, wszystkie faktury
    //to jest klasa abstrakcyjna bo zawiera co najmniej jedna funkcje abstrakcyjna (zawiera funkcje load() abstrakcyjna
    public abstract class WszystkieViewModel<T>: WorkspaceViewModel
    {
        #region Fields
        // to jest obiekt odpowiedzialny za polaczenie z baza danych
        protected FakturyEntities fakturyEntities;
        //to jest komenda odpowiadajaca za zaladowanie wszystkich obiektow
        private BaseCommand _LoadCommand;
        //To jest komenda odpowiadajaca za nacisniecie przycisku do dodawania rekordow
        private BaseCommand _AddCommand;
        //to jest lista obiektow, ktora zostanie zaladowana z bazy danych
        private ObservableCollection<T> _List;
        private BaseCommand _SortCommand;
        private BaseCommand _FindCommand;
        #endregion Fields

        #region Properties
        // to jest properties do komendy ladujacej obiekty - standardowy kod
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => load());   //komenda ta wywola metode load
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
        //to jest standardowy kod propertiesa do listy _List
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
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());

                return _SortCommand;
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

        #region Constructor
        public WszystkieViewModel()
        {
            //zainicjujemy obiekt laczacy sie z baza danych
            this.fakturyEntities = new FakturyEntities();
        }
        #endregion Constructor

        #region Helpers
        //to jest metoda ktora zaladuje towary z bazy danych
        //ta funkcja jest abstrakcyjna, bo nie ma bloku i bedzie napisana w klasa dziedziczacych po tej klasie
        public abstract void load();
        //to jest metoda ktora zostanie wywolana przez komende podpieta pod przycisk + dodajacy rekordy
        public void add()
        {
            //skorzystamy z biblioteki MVVMLight
            Messenger.Default.Send(DisplayName + "Add");
        }
        public abstract void Sort();
        public abstract List<String> getComboboxSortList();
        public abstract void Find();
        public abstract List<String> getComboboxFindList();
        #endregion Helpers
    }
}
