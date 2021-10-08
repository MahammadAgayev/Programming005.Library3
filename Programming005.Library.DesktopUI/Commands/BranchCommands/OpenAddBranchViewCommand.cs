using System;
using System.Windows.Input;
using Programming005.Library.DesktopUI.ViewModel;
using Programming005.Library.DesktopUI.Views;

namespace Programming005.Library.DesktopUI.Commands.BranchCommands
{
    public class OpenAddBranchViewCommand : ICommand
    {
        private readonly BranchViewModel _branchViewModel;

        public OpenAddBranchViewCommand(BranchViewModel viewModel)
        {
            _branchViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            AddBranchWindow window = new AddBranchWindow();
            window.DataContext = new AddBranchViewModel(window, _branchViewModel);

            window.Show();
        }
    }
}
