using System;
using BookApi_Application.DTOs;
using BookApi_Application.Interfaces;
using BookApi_Application.Queries;
using MediatR;

namespace BookApi_Application.Handlers.Queries
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IBookService _bookService;

        public GetBookQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBook(request.Id);
            return book;
        }
    }
}