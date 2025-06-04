using System;
using BookApi_Domain.Entities;

namespace BookApi_Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync(int page = 1, int pageSize = 3);

        Task<Book> GetBookAsync(string id);

        Task<Book> AddBookAsync(Book book);

        Task<string> DelBookAsync(string id);
    }
}