using System.Windows;
using System.Windows.Input;
using Programming005.Library.DesktopUI.Commands.BranchCommands;
using Programming005.Library.DesktopUI.Models.BranchModels;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class EditBranchViewModel : BaseWindowViewModel
    {
        public EditBranchViewModel(Window window) : base(window)
        {
            Model = new BranchModel();
            EditBranch = new EditBranchCommand(this);
        }

        public BranchModel Model { get; set; }

        public ICommand EditBranch { get; set; }
    }
}
