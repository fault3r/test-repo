using fa_mongo.Entities;
using fa_mongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fa_mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBook(string title)
        {
            var res = await _bookService.GetBook(title);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            var res = await _bookService.AddBook(book);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DelBook(string title)
        {
            var res = await _bookService.DelBook(title);
            return Ok(res);
        }
    }
}
