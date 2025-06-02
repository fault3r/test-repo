using BookApi_Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class BookV2Controller : BookController
    {
        public BookV2Controller(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public new async Task<IEnumerable<BookDto>> GetBooks()
        {
            return await base.GetBooks();
        }
    }
}
