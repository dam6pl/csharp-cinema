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
    // To jest klasa z której będą dziedziczyły wszystkie ViewModele zgodne ze scenariuszem "Wszystkie"
    // Jest to klasa abstrakcyna bo zawiera conajmniej jedną funkcję abstrakcyjną (load())
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {

        #region Fields
        // To jest obiekt odpowiedzialny za polaczenie z Baza Danych
        protected FakturyEntities fakturyEntities;
        // To jest komenda odpowiadajaca za zaladowanie wszystkich obiektów
        private BaseCommand _LoadCommand;
        // To jest komenda odpowiadająca za naciśnięcie przycisku do dowawania rekordu
        private BaseCommand _AddCommand;
        // To jest lista obiektów ktora zostanie zaladowana z bazy danych
        private ObservableCollection<T> _List;
        // To jest komenda która zostanie podpięta pod przycisk sortuj
        private BaseCommand _SortCommand;
        // To jest komenda która zostanie podpięta pod przycisk szukaj
        private BaseCommand _FindCommand;
        #endregion Fields

        #region Properties
        // To jest properties do komendy ładującej obiekty - standardowy kod komendy
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load()); //komenda ta wywoła metodę load()
                }
                return _LoadCommand;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add()); //komenda ta wywoła metodę load()
                }
                return _AddCommand;
            }
        }
        // To jest standardowy kod propertiesa do _List
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                {
                    load();
                }
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

        #region SortAndFind
        // W tym polu zapisujemy po której kolumnie sortować (Wynik wyboru z listy ComboBox)
        public string SortField { get; set; }
        public List<string> SortComboBoxItems
        {
            get
            {   // To jest metoda która określi po jakich polach możemy sortować
                return GetComboBoxSortList();
            }
        }
        // To jest komenda która zostanie podpięta pod button Sortuj
        public ICommand SortCommand
        {
            get
            {   if(_SortCommand == null)
                {   // Komenda ta wywoła metodę Sort() która będzie sortować
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        // To jest wynik z ComboBoxa po czym będziemy wyszukiwać
        public string FindField { get; set; }
        // Tu zapisuje się początek frazy po której będziemy wyszukiwać
        public string FindTextBox { get; set; }
        // Tu znajdują się elementy ComboBoxa - po czym możemy wyszukiwać
        public List<string> FindComboBoxItems
        {
            get
            {   // Ta metoda określa po czym będziemy mogli wyszukiwać
                return GetComboBoxFindList();
            }
        }
        // To jest komenda która zostanie podpięta pod przycisk szukaj
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {   // Komenda ta wywołuje metodę Find, która wyszukuje rekordy
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        #endregion SortAndFind

        #endregion Properties

        #region Constructor
        public WszystkieViewModel()
        {
            // zainicjujemy obiekt łączący się z bazą danych
            this.fakturyEntities = new FakturyEntities();
        }
        #endregion Constructor

        #region Helpers
        // Ta funkcja jes abstrakcyjna bo nie ma bloku i będzie napisana w klasach dziedziczących po tej klasie
        public abstract void load();
        // To jest metoda która zostanie wywołana przez komendę podpiętą pod przycisk + dodający rekordy
        private void add()
        {
            // Skorzystamy z biblioteki MVVM Light
            // Po wciśnięciu + komenda AddCommand uruchomi metodę add która puści w świat komunikat który jest w nawiasie
            // Ten komunikat jest wysyłany głównie do MainWindowViewModel - po jego złapaniu to ta klasa wywoła nową zakładkę
            Messenger.Default.Send(DisplayName + "Add");
        }
        public abstract void Sort();
        public abstract List<string> GetComboBoxSortList();
        public abstract void Find();
        public abstract List<string> GetComboBoxFindList();

        #endregion Helpers
    }
}
