using fa_mongodb.Models;
using fa_mongodb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fa_mongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(Book book)
        {
            await _bookRepository.InsertBook(new Book { Title = book.Title, Author = book.Author });
            return Ok();
        }
    }
}
