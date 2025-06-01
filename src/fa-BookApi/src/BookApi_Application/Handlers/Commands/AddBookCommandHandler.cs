using System;
using BookApi_Application.Commands;
using BookApi_Application.DTOs;
using BookApi_Application.Interfaces;
using MediatR;

namespace BookApi_Application.Handlers.Commands
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDto>
    {
        private readonly IBookService _bookService;

        public AddBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookService.AddBook(new AddBookDto
            {
                Title = request.Title,
                Author = request.Author,
                Year = request.Year,
            });
            return book;
        }
    }
}