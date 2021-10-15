using Programming005.Library.Core.Domain.Entities;
using System.Collections.Generic;

namespace Programming005.Library.Core.Domain.Abstract
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(Book book);

        List<Book> Get();
        Book Get(int id);

        void Delete(int id);
    }
}
