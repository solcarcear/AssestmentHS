using Microsoft.AspNetCore.Mvc;

namespace CaaoBakery.Api.Controllers
{
    [Route("[controller]")]
    public class ProductsController : ApiController
    {
        [HttpGet]
        public IActionResult ListProducts()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
