using System;
using BookApi_Application.DTOs;
using BookApi_Application.Interfaces;
using BookApi_Application.Queries;
using MediatR;

namespace BookApi_Application.Handlers.Queries
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookService _bookService;
        
        public GetBooksQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookService.GetBooks(request.p);
            return books;
        }
    }
}