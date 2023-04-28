using Microsoft.AspNetCore.Mvc;

namespace EFMysql.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("Home/Index")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
