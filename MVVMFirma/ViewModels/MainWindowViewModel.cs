using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helpers;
using MVVMFirma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{   
    // to jest ViewModel obslugujacy okno glowne aplikacji
    // w oknie glownym menu boczne z linkami oraz glowny obszar
    // roboczy z zakladkami 
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        // okno glowne ma w sobie kolekcje linkow tylko do odczytu
        // - mozna tez uzyc listy
        private ReadOnlyCollection<CommandViewModel> _Commands;
        // okno glowne zawiera tez kolekcje zakladek 
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion Fields

        #region Commands
        //tworzymy propertisa do _Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if(_Commands == null)
                {
                    //tworzymy liste poniewaz readonlycollection nie mozna modifikowac
                    //a zatem cmds jest po to żeby było wzorcem dla readonlycollection
                    List<CommandViewModel> cmds = this.createCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        //to jest funckja ktora tworzy komendy
        private List<CommandViewModel> createCommands()
        {
            //to jest messenger ktory nasluchuje czy wyslano komunikat z poleceniem 
            //uruchomienia nowej zakladki, jak taki komunikat dostanie wywola metode open
            Messenger.Default.Register<String>(this, open);
            //tworzymy nowa liste linkow
            return new List<CommandViewModel>
            {
                //kazdy element listy to nowy CommandViewModel o pierwszym parametrze
                //takim jak nazwa linku a drugim parametr mowi jaka funkcje wywolac
                //po kliknieciu
                new CommandViewModel("Towar",
                    new BaseCommand(()=>this.createWorkspace(
                                                new NowyTowarViewModel()))),
                new CommandViewModel("Towary",
                    new BaseCommand(()=>this.showAllTowary())),
                new CommandViewModel("Faktura",
                    new BaseCommand(()=>this.createWorkspace(
                                                new NowaFakturaViewModel()))),
                new CommandViewModel("Faktury",
                    new BaseCommand(()=>this.showAllFaktury())),

                new CommandViewModel("Raport Sprzedazy",
                    new BaseCommand(()=>this.showRaportSprzedazy()))
            };
        }
        #endregion Commands

        #region Workspaces
        //tworzymy propertisa do pola _Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if(_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;
            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }
        #endregion Workspaces

        #region Helpers
        private void createWorkspace(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        //powyzsza funkcja za kazdym razem tworzyla nowa zakladke
        //ponizsza funkcja najpierw sprawdzi czy wyswietlania wszystkich 
        //towarow juz nie ma 
        //jak jest to przywroci jej aktywnosc
        //jak nie ma to stworzy nowa
        //private void showAllWorkspace<T>()
        //{
        //    var workspace = this.Workspaces.FirstOrDefault(vm => vm is T);
        //    if (workspace == null)
            
        //        workspace = new T();
        //        this.Workspaces.Add(workspace);
        //    }
        //    this.setActiveWorkspace(workspace);
        //}

        private void showAllTowary()
        {
            //najpierw w kolekcji workspacow szukamy zakladki ktora jest
            // WszystkieTowaryViewModelem 
            WszystkieTowaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszystkieTowaryViewModel)as WszystkieTowaryViewModel;
            //jezeli takiej zakladki nie znajdziemy
            if (workspace == null)
            {
                //jezeli takiej zakladki nie ma to towrzymy ja i dodajemy 
                // do kolekcji
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }
            //ustawiamy aktywnosc nowej lub znalezionej zakladki
            this.setActiveWorkspace(workspace);
        }
        private void showAllFaktury()
        {
            WszystkieFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllKontrahenci()
        {
            WszyscyKontrahenciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                WszyscyKontrahenciViewModel) as WszyscyKontrahenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showRaportSprzedazy()
        {
            RaportSprzedazyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is
                RaportSprzedazyViewModel) as RaportSprzedazyViewModel;
            if (workspace == null)
            {
                workspace = new RaportSprzedazyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        //to jest funkcja ktora wlacza aktywnosc zakladki
        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView =
                CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void open(String name)
        {
            if (name == "FakturyAdd")
            {
                createWorkspace(new NowaFakturaViewModel());
            }
            else if (name == "TowaryAdd")
            {
                createWorkspace(new NowyTowarViewModel());
            }
            else if (name == "KontrahenciShow")
            {
                showAllKontrahenci();
            }
        }
        #endregion Helpers

        #region MenuCommands
        private BaseCommand _ShowNowyTowarCommand;
        // to jest komenda która zostanie podpięta pod menu i wywoła
        // funkcje createTowar
        public ICommand ShowNowyTowarCommand
        {
            get
            {
                if(_ShowNowyTowarCommand==null)
                {
                    _ShowNowyTowarCommand = new BaseCommand(() => createWorkspace(
                                                            new NowyTowarViewModel()));
                }
                return _ShowNowyTowarCommand;
            }
        }
        #endregion MenuCommands

    }
}
