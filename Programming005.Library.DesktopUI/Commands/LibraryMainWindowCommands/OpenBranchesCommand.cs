using System;
using System.Windows.Input;
using Programming005.Library.DesktopUI.ViewModel;
using Programming005.Library.DesktopUI.Views;

namespace Programming005.Library.DesktopUI.Commands.LibraryMainWindowCommands
{
    //ctrl r + g -> remove all unused dependencies
    public class OpenBranchesCommand : ICommand
    {
        private readonly LibraryMainViewModel _viewModel;

        public OpenBranchesCommand(LibraryMainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.Grid.Children.Clear();

            var branches = new BranchesUserControl();
            branches.DataContext = new BranchViewModel(branches);
            _viewModel.Grid.Children.Add(branches);
        }
    }
}


//ctrl k+d --> correct lines