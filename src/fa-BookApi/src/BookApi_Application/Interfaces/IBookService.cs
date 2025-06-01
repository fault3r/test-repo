using System;
using BookApi_Application.DTOs;

namespace BookApi_Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooks();

        Task<BookDto> GetBook(string id);

        Task<BookDto> AddBook(AddBookDto book);

        Task<bool> DelBook(string id);
    }
}