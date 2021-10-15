using Programming005.Library.Core.Domain.Abstract;
using Programming005.Library.Core.Domain.Entities;
using Programming005.Library.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Programming005.Library.Core.DataAccess.Sql
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public SqlBookRepository(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public void Add(Book book)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string query = "insert into books output inserted.id values(Id, Name, Genre, Language, IsTranslation)";
                var command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("name", book.Name);
                command.Parameters.AddWithValue("genre", book.Genre);
                command.Parameters.AddWithValue("language", book.Language);
                command.Parameters.AddWithValue("istranslation", book.IsTranslation);

                book.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string query = "delete from books where id=@id";
                var command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("Id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Book> Get()
        {
            using(var con = new SqlConnection(_connectionString))
            {
                con.Open();

                string query = "select * from books";
                var command = new SqlCommand(query, con);

                var reader = command.ExecuteReader();
                var list = new List<Book>();

                while(reader.Read())
                {
                    var book = ReadFromReader(reader);

                    list.Add(book);
                }

                return list;
            }
        }

        public Book Get(int id)
        {
            using(var con = new SqlConnection(_connectionString))
            {
                string query = "Select * from books where id = @id";
                var command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("Id", id);

                var reader = command.ExecuteReader();

                if(reader.Read())
                {
                    var book = ReadFromReader(reader);
                    return book;
                }
                else
                {
                    return null;
                }
            }
        }

        public void Update(Book book)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string query = @"Update books set Name=@name, Genre= @genre,
                                  Language=@language,IsTranslation=@istranslation 
                                  where id = @id";

                var command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("name", book.Name);
                command.Parameters.AddWithValue("Genre", book.Genre);
                command.Parameters.AddWithValue("Language", book.Language);
                command.Parameters.AddWithValue("IsTranslation", book.IsTranslation);

                command.ExecuteNonQuery();
            }
        }

        private Book ReadFromReader(SqlDataReader reader)
        {
            return new Book
            {
                Id = reader.Get<int>("Id"),
                Genre = reader.Get<string>("Genre"),
                Name = reader.Get<string>("Name"),
                Language = reader.Get<string>("Language"),
                IsTranslation = reader.Get<bool>("IsTranslation")
            };
        }
    }
}
