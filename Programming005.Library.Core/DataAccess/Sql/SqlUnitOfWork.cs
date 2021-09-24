using Programming005.Library.Core.Domain.Abstract;

namespace Programming005.Library.Core.DataAccess.Sql
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;

        public SqlUnitOfWork(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public IBranchRepository BranchRepository => new SqlBranchRepository(_connectionString);
    }
}