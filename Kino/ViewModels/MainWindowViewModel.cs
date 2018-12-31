using GalaSoft.MvvmLight.Messaging;
using Kino.ViewModels.Abstract;
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

namespace Kino.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion Fields

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.createCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }

        private List<CommandViewModel> createCommands()
        {
            Messenger.Default.Register<String>(this, open);

            return new List<CommandViewModel>
            {
                new CommandViewModel("Nowy seans", new BaseCommand(()=>this.createWorkspace(new ShowingsNewViewModel()))),
                new CommandViewModel("Wszystkie seanse", new BaseCommand(()=>this.showShowingsAll())),

                new CommandViewModel("Nowa sala", new BaseCommand(()=>this.createWorkspace(new RoomsNewViewModel()))),
                new CommandViewModel("Wszystkie sale", new BaseCommand(()=>this.showRoomsAll())),

                new CommandViewModel("Nowy film", new BaseCommand(()=>this.createWorkspace(new FilmsNewViewModel()))),
                new CommandViewModel("Wszystkie filmy", new BaseCommand(()=>this.showFilmsAll())),

                new CommandViewModel("Nowy gatunek", new BaseCommand(()=>this.createWorkspace(new GenreNewView()))),

                new CommandViewModel("Nowy typ seansu", new BaseCommand(()=>this.createWorkspace(new ShowingTypesNewViewModel()))),

                new CommandViewModel("Nowe zamowienie", new BaseCommand(()=>this.createWorkspace(new OrdersNewViewModel()))),
                new CommandViewModel("Wszystkie zamowienia", new BaseCommand(()=>this.showOrdersAll())),

                new CommandViewModel("Nowy klient", new BaseCommand(()=>this.createWorkspace(new CustomersNewViewModel()))),
                new CommandViewModel("Wszyscy klienci", new BaseCommand(()=>this.showCustomersAll())),

                new CommandViewModel("Nowy pracownik", new BaseCommand(()=>this.createWorkspace(new EmployeesNewViewModel()))),
                new CommandViewModel("Wszyscy pracownicy", new BaseCommand(()=>this.showEmployeesAll())),

                new CommandViewModel("Nowy adres", new BaseCommand(()=>this.createWorkspace(new AdressesNewViewModel())))
            };
        }
        #endregion Commands

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspaceChanged;
                }
                return _Workspaces;
            }
        }

        private void onWorkspaceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspacesRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspacesRequestClose;
        }

        private void onWorkspacesRequestClose(Object sender, EventArgs e)
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

        private void showShowingsAll()
        {
            ShowingsAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is ShowingsAllViewModel)
                as ShowingsAllViewModel;
            if (workspace == null)
            {
                workspace = new ShowingsAllViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }

        private void showRoomsAll()
        {
            RoomsAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is RoomsAllViewModel)
                as RoomsAllViewModel;
            if (workspace == null)
            {
                workspace = new RoomsAllViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }

        private void showFilmsAll()
        {
            FilmsAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is FilmsAllViewModel)
                as FilmsAllViewModel;
            if (workspace == null)
            {
                workspace = new FilmsAllViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }
    
        private void showOrdersAll()
        {
            OrdersAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is OrdersAllViewModel)
                as OrdersAllViewModel;
            if (workspace == null)
            {
                workspace = new OrdersAllViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }

        private void showCustomersAll()
        {
            CustomersAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is CustomersAllViewModel)
                as CustomersAllViewModel;
            if (workspace == null)
            {
                workspace = new CustomersAllViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }

        private void showEmployeesAll()
        {
            EmployeesAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is EmployeesAllViewModel)
                as EmployeesAllViewModel;
            if (workspace == null)
            {
                workspace = new EmployeesAllViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }

        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(workspace);
            }
        }

        private void open(String name)
        {
            createWorkspace(new ShowingsNewViewModel());
        }
        #endregion Helpers

        #region Menu commands
        private BaseCommand _showShowingsAllCommand;
        public ICommand ShowShowingsAllCommand
        {
            get
            {

                if (_showShowingsAllCommand == null)
                {
                    _showShowingsAllCommand = new BaseCommand(() => showShowingsAll());
                }

                return _showShowingsAllCommand;
            }
        }

        private BaseCommand _showRoomsAllCommand;
        public ICommand ShowRoomsAllCommand
        {
            get
            {

                if (_showRoomsAllCommand == null)
                {
                    _showRoomsAllCommand = new BaseCommand(() => showRoomsAll());
                }

                return _showRoomsAllCommand;
            }
        }

        private BaseCommand _showFilmsAllCommand;
        public ICommand ShowFilmsAllCommand
        {
            get
            {

                if (_showFilmsAllCommand == null)
                {
                    _showFilmsAllCommand = new BaseCommand(() => showFilmsAll());
                }

                return _showFilmsAllCommand;
            }
        }

        private BaseCommand _showOrdersAllCommand;
        public ICommand ShowOrdersAllCommand
        {
            get
            {

                if (_showOrdersAllCommand == null)
                {
                    _showOrdersAllCommand = new BaseCommand(() => showOrdersAll());
                }

                return _showOrdersAllCommand;
            }
        }

        private BaseCommand _showCustomersAllCommand;
        public ICommand ShowCustomersAllCommand
        {
            get
            {

                if (_showCustomersAllCommand == null)
                {
                    _showCustomersAllCommand = new BaseCommand(() => showCustomersAll());
                }

                return _showCustomersAllCommand;
            }
        }

        private BaseCommand _showEmployeesAllCommand;
        public ICommand ShowEmployeesAllCommand
        {
            get
            {

                if (_showEmployeesAllCommand == null)
                {
                    _showEmployeesAllCommand = new BaseCommand(() => showEmployeesAll());
                }

                return _showEmployeesAllCommand;
            }
        }

        //Temporary command
        private BaseCommand _showRoomsNewCommand;
        public ICommand ShowRoomsNewCommand
        {
            get
            {

                if (_showRoomsNewCommand == null)
                {
                    _showRoomsNewCommand = new BaseCommand(() => createWorkspace(new AdressesNewViewModel()));
                }

                return _showRoomsNewCommand;
            }
        }
        # endregion Menu commands
    }
}
