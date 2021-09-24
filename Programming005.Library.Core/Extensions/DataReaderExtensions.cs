using System;
using System.Data.SqlClient;

namespace Programming005.Library.Core.Extensions
{
    public static class DataReaderExtensions
    {
        public static T Get<T>(this SqlDataReader reader, string columnName)
        {
            var val = reader[columnName];

            T result = default;

            if(val != DBNull.Value && val != null)
            {
                result = (T)val; 
            }

            return result;
        }
    }
}
