using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Programming005.Library.Core;
using Programming005.Library.DesktopUI.ViewModel;

namespace Programming005.Library.DesktopUI.Commands.BranchCommands
{
    public class EditBranchCommand : ICommand
    {
        private readonly EditBranchViewModel _viewModel;

        public EditBranchCommand(EditBranchViewModel viewModel)
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
            var entity = Kernel.DB.BranchRepository.Get(_viewModel.Model.Id);

            entity.Name = _viewModel.Model.Name;
            entity.Address = _viewModel.Model.Address;

            Kernel.DB.BranchRepository.Update(entity);
            _viewModel.Window.Close();
        }
    }
}
