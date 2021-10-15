using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming005.Library.Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IBranchRepository BranchRepository { get; }
        IBookRepository BookRepository { get; }
    }
}
