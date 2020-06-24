using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAsync.API.Services
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Entities.Book>> GetBooksAsync();

        Task<Entities.Book> GetBookAsync(Guid id);

        public Entities.Book GetBook(Guid id);

        IEnumerable<Entities.Book> GetBooks();

        void AddBook(Entities.Book bookToAdd);

        Task<bool> SaveChangesAsync();
    }
}
