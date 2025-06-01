using System;
using BookApi_Domain.Entities;

namespace BookApi_Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(string id);

        Task<Book> AddBookAsync(Book book);

        Task<bool> DelBookAsync(string id);
    }
}