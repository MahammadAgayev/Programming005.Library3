using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Programming005.Library.Core;
using Programming005.Library.DesktopUI.Commands.BranchCommands;
using Programming005.Library.DesktopUI.Models.BranchModels;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class BranchViewModel : BaseWindowViewModel
    {
        public BranchViewModel(Window window) : base(window)
        {
            var branches = Kernel.DB.BranchRepository.Get();

            Branches = new ObservableCollection<BranchModel>();

            foreach (var branch in branches)
            {
                Branches.Add(new BranchModel
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    Address = branch.Address
                });
            }

            AddBranch = new OpenAddBranchViewCommand(this);
            DeleteBranch = new DeleteBranchCommand(this);
        }

        public ICommand AddBranch { get; set; }
        public ICommand DeleteBranch { get; set; }

        public ObservableCollection<BranchModel> Branches { get; set; }

        public BranchModel SelectedModel { get; set; }
    }
}
