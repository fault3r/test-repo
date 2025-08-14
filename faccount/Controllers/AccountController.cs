using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace faccount.Controllers
{
    [Route("accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("list of accounts..");   
        }
    }
}
