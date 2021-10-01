using System.Collections.Generic;
using Programming005.Library.Core;
using Programming005.Library.DesktopUI.Models.BranchModels;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class BranchViewModel
    {
        public BranchViewModel()
        {
            var branches = Kernel.DB.BranchRepository.Get();

            Branches = new List<BranchModel>();

            foreach (var branch in branches)
            {
                Branches.Add(new BranchModel
                {
                    Id = branch.Id,
                    Name = branch.Name,
                    Address = branch.Address
                });
            }
        }

        public List<BranchModel> Branches { get; set; }
    }
}
