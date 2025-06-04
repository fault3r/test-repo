using BookApi_Api.Controllers.BaseControllers;
using BookApi_Application.Commands;
using BookApi_Application.DTOs;
using BookApi_Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookApi_Api.Controllers
{
    [ApiController]
    [Route("books")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class BookController : BookBaseController
    {
        public BookController(IMediator mediator) : base(mediator){}

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            var books = await _mediator.Send(new GetBooksQuery(0));
            return books;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<BookDto> GetBook([FromRoute]string id)
        {
            var book = await _mediator.Send(new GetBookQuery(id));
            return book;
        }

        [HttpPost]
        public async Task<BookDto> AddBook([FromBody]AddBookDto book)
        {
            var command = new AddBookCommand(book.Title, book.Author, book.Year);
            var aBook = await _mediator.Send(command);
            return aBook;
        }

        [HttpDelete("{id}")]
        public async Task<string> DelBook([FromRoute]string id)
        {
            var result = await _mediator.Send(new DelBookCommand(id));
            return result;
        }
    }
}
