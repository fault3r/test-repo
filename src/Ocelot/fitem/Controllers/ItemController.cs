using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fitem.Controllers
{
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly HttpClient httpClient;

        public ItemController(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient("ItemHttpClient");
        }

        [Route("/get")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("list of items..");
        }
    }
}
