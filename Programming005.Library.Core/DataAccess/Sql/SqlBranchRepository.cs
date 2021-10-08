using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Programming005.Library.Core.Domain.Abstract;
using Programming005.Library.Core.Domain.Entities;
using Programming005.Library.Core.Extensions;

namespace Programming005.Library.Core.DataAccess.Sql
{
    public class SqlBranchRepository : IBranchRepository
    {
        private readonly string _connectionString;

        public SqlBranchRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public void Add(Branch branch)
        {
            using(var con = new SqlConnection(_connectionString))
            {
                con.Open();

                string query = "insert into branches output inserted.id values(@name, @address)";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("name", branch.Name);
                cmd.Parameters.AddWithValue("address", branch.Address);

                branch.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            using(var con = new SqlConnection(_connectionString))
            {
                con.Open();

                string query = "delete from branches where id = @id";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Programming005.Library.Core.Domain.Entities.Branch> Get()
        {
            using (var con =  new SqlConnection(_connectionString))
            {
                con.Open();

                string query = "select * from branches";
                var cmd = new SqlCommand(query, con);

                var reader = cmd.ExecuteReader();

                var branches = new List<Programming005.Library.Core.Domain.Entities.Branch>();

                while(reader.Read())
                {
                    var branch = ReadFromReader(reader);

                    branches.Add(branch);
                }

                return branches;
            }
        }

        public void Update(Branch branch)
        {
            using(var con = new SqlConnection(_connectionString))
            {
                con.Open();

                string query = "update branches set name = @name, address = @address where id = @id";
                var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("id", branch.Id);
                cmd.Parameters.AddWithValue("name", branch.Name);
                cmd.Parameters.AddWithValue("address", branch.Address);

                cmd.ExecuteNonQuery();
            }
        }

        
        private Branch ReadFromReader(SqlDataReader reader)
        {
            return new Branch
            { 
                Id = reader.Get<int>("Id"),
                Address = reader.Get<string>("Address"),
                Name = reader.Get<string>("Name")
            };
        }
    }
}
