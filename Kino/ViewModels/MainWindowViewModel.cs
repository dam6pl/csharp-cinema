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
            return new List<CommandViewModel>
            {
                new CommandViewModel("Nowy seans", new BaseCommand(()=>this.createWorkspace(new NewShowingViewModel()))),
                new CommandViewModel("Wszystkie seanse", new BaseCommand(()=>this.showAllShowings())),

                new CommandViewModel("Nowa sala", new BaseCommand(()=>this.createWorkspace(new NewRoomViewModel()))),
                new CommandViewModel("Wszystkie sale", new BaseCommand(()=>this.showAllRooms())),

                //new CommandViewModel("Nowy pracownik", new BaseCommand(()=>this.createWorkspace(new NowyPracownikViewModel()))),
                //new CommandViewModel("Pracownicy", new BaseCommand(()=>this.showAllPracownicy()))
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

        private void showAllShowings()
        {
            AllShowingsViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is AllShowingsViewModel)
                as AllShowingsViewModel;
            if (workspace == null)
            {
                workspace = new AllShowingsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }

        private void showAllRooms()
        {
            AllRoomsViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is AllRoomsViewModel)
                as AllRoomsViewModel;
            if (workspace == null)
            {
                workspace = new AllRoomsViewModel();
                this.Workspaces.Add(workspace);
            }

            this.setActiveWorkspace(workspace);
        }


        //private void showAllPracownicy()
        //{
        //    WszyscyPracownicyViewModel workspace = this._Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
        //        as WszyscyPracownicyViewModel;
        //    if (workspace == null)
        //    {
        //        workspace = new WszyscyPracownicyViewModel();
        //        this.Workspaces.Add(workspace);
        //    }

        //    this.setActiveWorkspace(workspace);
        //}

        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(workspace);
            }
        }
        #endregion Helpers

        #region Menu commands
        private BaseCommand _showAllShowingsCommand;
        public ICommand ShowAllShowingsCommand
        {
            get
            {

                if (_showAllShowingsCommand == null)
                {
                    _showAllShowingsCommand = new BaseCommand(() => showAllShowings());
                }

                return _showAllShowingsCommand;
            }
        }

        private BaseCommand _showNewShowingCommand;
        public ICommand ShowNewShowingCommand
        {
            get
            {

                if (_showNewShowingCommand == null)
                {
                    _showNewShowingCommand = new BaseCommand(() => createWorkspace(new NewShowingViewModel()));
                }

                return _showNewShowingCommand;
            }
        }

        private BaseCommand _showAllRoomsCommand;
        public ICommand ShowAllRoomsCommand
        {
            get
            {

                if (_showAllRoomsCommand == null)
                {
                    _showAllRoomsCommand = new BaseCommand(() => showAllRooms());
                }

                return _showAllRoomsCommand;
            }
        }

        private BaseCommand _showNewRoomCommand;
        public ICommand ShowNewRoomCommand
        {
            get
            {

                if (_showNewRoomCommand == null)
                {
                    _showNewRoomCommand = new BaseCommand(() => createWorkspace(new NewRoomViewModel()));
                }

                return _showNewRoomCommand;
            }
        }
        # endregion Menu commands
    }
}
