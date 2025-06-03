using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi_Api.Controllers.BaseControllers
{
    [ApiController]
    public class BookBaseController : ControllerBase
    {
        public readonly IMediator _mediator;

        public BookBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
