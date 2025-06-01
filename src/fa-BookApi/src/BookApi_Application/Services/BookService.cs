using System;
using BookApi_Application.DTOs;
using BookApi_Application.Interfaces;
using BookApi_Domain.Entities;
using BookApi_Domain.Interfaces;

namespace BookApi_Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            var books = await _bookRepository.GetBooksAsync();
            return books.Select(r => new BookDto
            {
                Id = r.Id,
                Title = r.Title,
                Author = r.Author,
                Year = r.Year,
            });
        }

        public async Task<BookDto> GetBook(string id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            };
        }

        public async Task<BookDto> AddBook(AddBookDto book)
        {
            var dBook = await _bookRepository.AddBookAsync(new Book
            {
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
            });
            return new BookDto
            {
                Id = dBook.Id,
                Title = dBook.Title,
                Author = dBook.Author,
                Year = dBook.Year,
            };
        }

        public async Task<bool> DelBook(string id)
        {
            var result = await _bookRepository.DelBookAsync(id);
            return result;
        }
    }
}