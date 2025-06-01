using System;
using BookApi_Application.Commands;
using BookApi_Application.Interfaces;
using MediatR;

namespace BookApi_Application.Handlers.Commands
{
    public class DelBookCommandHandler : IRequestHandler<DelBookCommand, bool>
    {
        private readonly IBookService _bookService;

        public DelBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<bool> Handle(DelBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookService.DelBook(request.Id);
            return result;
        }
    }
}