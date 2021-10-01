using System.Collections.Generic;
using Programming005.Library.Core.Domain.Entities;

namespace Programming005.Library.Core.Domain.Abstract
{
    public interface IBranchRepository
    {
        void Add(Branch branch);
        void Update(Branch branch);

        List<Programming005.Library.Core.Domain.Entities.Branch> Get();

        void Delete(int id);
    }
}
