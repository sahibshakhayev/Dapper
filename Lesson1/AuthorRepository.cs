using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class AuthorRepository : IAuthorRepository
    {
        private IDbConnection _db;

        public AuthorRepository()
        {
            _db = new SqlConnection();
            _db.ConnectionString = @"Server=SAHIB-LAPTOP;Database=Library;Trusted_Connection=True;";
        }
        public Author Add(Author author)
        {
            var sql = "INSERT INTO Authors(FirstName, LastName) VALUES (@FirstName, @LastName)" +
                "SELECT CAST(SCOPE_IDENTITY() AS int)";
            var id = _db.Query<int>(sql, new
            {
                @FirstName = author.FirstName,
                @LastName = author.LastName

            }).FirstOrDefault();
            author.Id = id;
            return author;
        }

        public void AddAuthors(object[] authors)
        {
            var sql = "INSERT INTO Authors(FirstName, LastName) VALUES (@FirstName, @LastName)" +
                "SELECT CAST(SCOPE_IDENTITY() AS int)";
            _db.Execute(sql, authors);
        }

        public IEnumerable<Author> GetAll()
        {
            var sql = "SELECT * FROM Authors";
            return _db.Query<Author> (sql);
        }

        public Author GetById(int id)
        {
            var sql = "SELECT * FROM Authors WHERE Id=@Id";
            return _db.Query<Author>(sql, new { @Id = id }).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Authors WHERE Id = @Id";
            _db.Execute(sql, new { @Id = id });
        }

        public void RemoveAuthors(int[] authorsIds)
        {
            for (int i = 0; i < authorsIds.Length; i++)
            {
                Remove(authorsIds[i]);
            }
        }


        public void UpdateAuthors(object[] authors)
        {
            for (int i = 0; i < authors.Length; i++)
            {
                try
                {
                    Update((Author)authors[i]);

                }
                catch
                {
                    Console.WriteLine("Error!");
                }
            }
        }

        public Author Update(Author author)
        {
            var sql = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName WHERE Id=@Id";
            _db.Execute(sql, author);
            return author;
        }
    }
}
