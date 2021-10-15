using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Programming005.Library.Core;
using Programming005.Library.DesktopUI.Commands.BranchCommands;
using Programming005.Library.DesktopUI.Models.BranchModels;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class BranchViewModel : BaseUserControlViewModel
    {
        public BranchViewModel(UserControl control) : base(control)
        {
            var branches = Kernel.DB.BranchRepository.Get();

            Branches = new ObservableCollection<BranchModel>();

            int count = 1;

            foreach (var branch in branches)
            {
                Branches.Add(new BranchModel
                {
                    Id = branch.Id,
                    No = count++,
                    Name = branch.Name,
                    Address = branch.Address
                });
            }

            OpenAddBranchWindow = new OpenAddBranchViewCommand(this);
            DeleteBranch = new DeleteBranchCommand(this);
            OpenEditBranchWindow = new OpenEditBranchWindowCommand(this);
        }

        public ICommand OpenAddBranchWindow { get; set; }
        public ICommand DeleteBranch { get; set; }
        public ICommand OpenEditBranchWindow { get; set; }

        public ObservableCollection<BranchModel> Branches { get; set; }

        public BranchModel SelectedModel { get; set; }
    }
}
