using docknetd;
using Microsoft.AspNetCore.Mvc;

namespace docknet.Controllers
{
    [Route("hello")]
    [ApiController]
    public class HelloController : ControllerBase
    {

        [HttpGet]
        public IActionResult hello()
        {
            return Ok(Hello.SayHi());
        }
    }
}
