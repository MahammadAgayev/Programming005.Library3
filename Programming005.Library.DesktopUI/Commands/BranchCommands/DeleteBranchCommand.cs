using System;
using System.Windows.Input;
using Programming005.Library.Core;
using Programming005.Library.DesktopUI.ViewModel;

namespace Programming005.Library.DesktopUI.Commands.BranchCommands
{
    public class DeleteBranchCommand : ICommand
    {
        private readonly BranchViewModel _branchViewModel;

        public DeleteBranchCommand(BranchViewModel branchViewModel)
        {
            _branchViewModel = branchViewModel;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Kernel.DB.BranchRepository.Delete(_branchViewModel.SelectedModel.Id);
            _branchViewModel.Branches.Remove(_branchViewModel.SelectedModel);
        }
    }
}
