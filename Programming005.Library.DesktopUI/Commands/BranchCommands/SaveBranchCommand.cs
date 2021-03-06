using System;
using System.Windows.Input;
using Programming005.Library.Core;
using Programming005.Library.Core.Domain.Entities;
using Programming005.Library.DesktopUI.Models.BranchModels;
using Programming005.Library.DesktopUI.ViewModel;

namespace Programming005.Library.DesktopUI.Commands.BranchCommands
{
    public class SaveBranchCommand : ICommand
    {
        private readonly AddBranchViewModel _viewModel;

        public SaveBranchCommand(AddBranchViewModel viewModel)
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
            //add to database
            Branch branch = new Branch
            {
                Name = _viewModel.AddBranchModel.Name,
                Address = _viewModel.AddBranchModel.Address
            };

            Kernel.DB.BranchRepository.Add(branch);

            //add to view
            var branches = _viewModel.BranchViewModel.Branches;

            var model = new BranchModel
            {
                Name = branch.Name,
                Address = branch.Address,
                Id = branch.Id,
            };

            model.No = branches.Count+1;

            branches.Add(model);
            _viewModel.Window.Close();
        }
    }
}
