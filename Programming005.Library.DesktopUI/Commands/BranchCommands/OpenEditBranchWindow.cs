using System;
using System.Windows.Input;
using Programming005.Library.DesktopUI.ViewModel;
using Programming005.Library.DesktopUI.Views;

namespace Programming005.Library.DesktopUI.Commands.BranchCommands
{
    public class OpenEditBranchWindowCommand : ICommand
    {
        private readonly BranchViewModel _viewModel;

        public OpenEditBranchWindowCommand(BranchViewModel viewModel)
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
            var window = new EditBranchWindow();
            var viewModel = new EditBranchViewModel(window);

            viewModel.Model = _viewModel.SelectedModel;

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
