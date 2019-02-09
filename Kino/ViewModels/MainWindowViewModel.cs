using GalaSoft.MvvmLight.Messaging;
using Kino.Helpers;
using Kino.Models;
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
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion Fields

        #region Constructor
        public MainWindowViewModel()
        {
            Messenger.Default.Register<String>(this, open);
            Messenger.Default.Register<ModifyCommand>(this, openModify);
        }
        #endregion

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

        private void showShowingsAll(bool modal = false)
        {
            ShowingsAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is ShowingsAllViewModel)
                as ShowingsAllViewModel;
            if (workspace == null)
            {
                workspace = new ShowingsAllViewModel(modal);
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

        private void showFilmsAll(bool modal = false)
        {
            FilmsAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is FilmsAllViewModel)
                as FilmsAllViewModel;
            if (workspace == null)
            {
                workspace = new FilmsAllViewModel(modal);
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

        private void showCustomersAll(bool modal = false)
        {
            CustomersAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is CustomersAllViewModel)
                as CustomersAllViewModel;
            if (workspace == null)
            {
                workspace = new CustomersAllViewModel(modal);
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

        private void showAddressesAll(bool modal = false)
        {
            AddressesAllViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is AddressesAllViewModel)
                as AddressesAllViewModel;
            if (workspace == null)
            {
                workspace = new AddressesAllViewModel(modal);
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }

        private void showSalesReport()
        {
            SalesReportViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is SalesReportViewModel)
                as SalesReportViewModel;
            if (workspace == null)
            {
                workspace = new SalesReportViewModel();
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
            if (name == "CustomersNew")
                createWorkspace(new CustomersNewViewModel());
            else if (name == "EmployeesNew")
                createWorkspace(new EmployeesNewViewModel());
            else if (name == "FilmsNew")
                createWorkspace(new FilmsNewViewModel());
            else if (name == "OrdersNew")
                createWorkspace(new OrdersNewViewModel());
            else if (name == "RoomsNew")
                createWorkspace(new RoomsNewViewModel());
            else if (name == "ShowingsNew")
                createWorkspace(new ShowingsNewViewModel());
            else if (name == "AddressesNew")
                createWorkspace(new AddressesNewViewModel());
            else if (name == "ShowingTypesNew")
                createWorkspace(new ShowingTypesNewViewModel());
            else if (name == "TicketTypesNew")
                createWorkspace(new TicketTypesNewViewModel());
            else if (name == "GenreNew")
                createWorkspace(new GenreNewViewModel());
            else if (name == "FilmsAll")
                showFilmsAll(true);
            else if (name == "ShowingsAll")
                showShowingsAll(true);
            else if (name == "CustomersAll")
                showCustomersAll(true);
            else if (name == "AddressesAll")
                showAddressesAll(true);
        }

        private void openModify(ModifyCommand command)
        {
            if (command.Name == "AddressesModify")
                createWorkspace(new AddressesNewViewModel(command.Id));
            if (command.Name == "CustomersModify")
                createWorkspace(new CustomersNewViewModel(command.Id));
            if (command.Name == "EmployeesModify")
                createWorkspace(new EmployeesNewViewModel(command.Id));
            if (command.Name == "FilmsModify")
                createWorkspace(new FilmsNewViewModel(command.Id));
            if (command.Name == "OrdersModify")
                createWorkspace(new OrdersNewViewModel(command.Id));
            if (command.Name == "RoomsModify")
                createWorkspace(new RoomsNewViewModel(command.Id));
            if (command.Name == "ShowingsModify")
                createWorkspace(new ShowingsNewViewModel(command.Id));
        }
        #endregion Helpers

        #region Menu commands
        private BaseCommand _showShowingsAllCommand;
        public ICommand ShowShowingsAllCommand
        {
            get
            {
                if (_showShowingsAllCommand == null)
                    _showShowingsAllCommand = new BaseCommand(() => showShowingsAll());

                return _showShowingsAllCommand;
            }
        }

        private BaseCommand _showRoomsAllCommand;
        public ICommand ShowRoomsAllCommand
        {
            get
            {
                if (_showRoomsAllCommand == null)
                    _showRoomsAllCommand = new BaseCommand(() => showRoomsAll());

                return _showRoomsAllCommand;
            }
        }

        private BaseCommand _showFilmsAllCommand;
        public ICommand ShowFilmsAllCommand
        {
            get
            {
                if (_showFilmsAllCommand == null)
                    _showFilmsAllCommand = new BaseCommand(() => showFilmsAll());

                return _showFilmsAllCommand;
            }
        }

        private BaseCommand _showOrdersAllCommand;
        public ICommand ShowOrdersAllCommand
        {
            get
            {
                if (_showOrdersAllCommand == null)
                    _showOrdersAllCommand = new BaseCommand(() => showOrdersAll());

                return _showOrdersAllCommand;
            }
        }

        private BaseCommand _showCustomersAllCommand;
        public ICommand ShowCustomersAllCommand
        {
            get
            {
                if (_showCustomersAllCommand == null)
                    _showCustomersAllCommand = new BaseCommand(() => showCustomersAll());

                return _showCustomersAllCommand;
            }
        }

        private BaseCommand _showEmployeesAllCommand;
        public ICommand ShowEmployeesAllCommand
        {
            get
            {
                if (_showEmployeesAllCommand == null)
                    _showEmployeesAllCommand = new BaseCommand(() => showEmployeesAll());

                return _showEmployeesAllCommand;
            }
        }

        private BaseCommand _showAddressesAllCommand;
        public ICommand ShowAddressesAllCommand
        {
            get
            {
                if (_showAddressesAllCommand == null)
                    _showAddressesAllCommand = new BaseCommand(() => showAddressesAll());

                return _showAddressesAllCommand;
            }
        }

        private BaseCommand _showSalesReportCommand;
        public ICommand ShowSalesReportCommand
        {
            get
            {
                if (_showSalesReportCommand == null)
                    _showSalesReportCommand = new BaseCommand(() => showSalesReport());

                return _showSalesReportCommand;
            }
        }
        # endregion Menu commands
    }
}
