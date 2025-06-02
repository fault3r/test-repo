using BookApi_Application.Commands;
using BookApi_Application.DTOs;
using BookApi_Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi_Api.Controllers
{
    [Route("books")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return books;
        }

        [HttpGet("{id}")]
        public async Task<BookDto> GetBook(string id)
        {
            var book = await _mediator.Send(new GetBookQuery(id));
            return book;
        }

        [HttpPost]
        public async Task<BookDto> AddBook(AddBookDto book)
        {
            var command = new AddBookCommand(book.Title, book.Author, book.Year);
            var aBook = await _mediator.Send(command);
            return aBook;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DelBook(string id)
        {
            var result = await _mediator.Send(new DelBookCommand(id));
            return result;
        }
    }
}
