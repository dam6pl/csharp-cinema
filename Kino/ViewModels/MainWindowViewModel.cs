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
            Console.WriteLine("Elo");
            Messenger.Default.Register<String>(this, open);

            return new List<CommandViewModel>
            {
                new CommandViewModel("Nowy seans", new BaseCommand(()=>this.createWorkspace(new ShowingsNewViewModel()))),
                new CommandViewModel("Wszystkie seanse", new BaseCommand(()=>this.showShowingsAll())),

                new CommandViewModel("Nowa sala", new BaseCommand(()=>this.createWorkspace(new RoomsNewViewModel()))),
                new CommandViewModel("Wszystkie sale", new BaseCommand(()=>this.showRoomsAll())),

                //new CommandViewModel("Nowy pracownik", new BaseCommand(()=>this.createWorkspace(new NowyPracownikViewModel()))),
                new CommandViewModel("Wszystkie filmy", new BaseCommand(()=>this.showFilmsAll()))
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

        private BaseCommand _showRoomsNewCommand;
        public ICommand ShowRoomsNewCommand
        {
            get
            {

                if (_showRoomsNewCommand == null)
                {
                    _showRoomsNewCommand = new BaseCommand(() => createWorkspace(new ShowingsNewViewModel()));
                }

                return _showRoomsNewCommand;
            }
        }
        # endregion Menu commands
    }
}
