using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fitem.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("list of items..");
        }
    }
}
