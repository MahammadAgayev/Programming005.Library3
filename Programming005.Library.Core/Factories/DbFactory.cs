using System;
using Programming005.Library.Core.DataAccess.Sql;
using Programming005.Library.Core.Domain.Abstract;

namespace Programming005.Library.Core.Factories
{
    public static class DbFactory
    {
        public static IUnitOfWork GetDb(DbSettings settings)
        {
            switch(settings.DbType)
            {
                case "sql":
                    return new SqlUnitOfWork(settings.ConnectionString);
                default:
                    throw new NotSupportedException($"dbtype '{settings.DbType}' not supported");
            }
        }
    }
}
