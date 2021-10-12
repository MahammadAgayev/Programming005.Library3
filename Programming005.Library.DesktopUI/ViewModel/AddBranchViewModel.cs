using System.Windows;
using System.Windows.Input;
using Programming005.Library.DesktopUI.Commands.BranchCommands;
using Programming005.Library.DesktopUI.Models.BranchModels;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class AddBranchViewModel : BaseWindowViewModel
    {
        public AddBranchViewModel(Window window, BranchViewModel branchViewModel) : base(window)
        {
            SaveBranch = new SaveBranchCommand(this);
            AddBranchModel = new BranchModel();
            BranchViewModel = branchViewModel;
        }

        public ICommand SaveBranch { get; set; }

        public BranchModel AddBranchModel { get; set; } 

        public BranchViewModel BranchViewModel { get; set; }
    }
}
