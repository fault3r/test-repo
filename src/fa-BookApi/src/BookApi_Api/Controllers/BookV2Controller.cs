using System.Collections;
using BookApi_Api.Controllers.BaseControllers;
using BookApi_Application.DTOs;
using BookApi_Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi_Api.Controllers
{
    //v{version:apiversion}
    [ApiController]
    [Route("books")]
    [ApiVersion("2.0")]
    public class BookV2Controller : BookBaseController
    {
        public BookV2Controller(IMediator mediator) : base(mediator){}

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooks([FromQuery]int p = 1)
        {
            var books = await _mediator.Send(new GetBooksQuery(p));
            return books;
        }

        [MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public async Task<BookDto> GetBook([FromRoute]string id)
        {
            var book = await _mediator.Send(new GetBookQuery(id));
            book.Title += " *v2*";
            return book;
        }
    }
}
