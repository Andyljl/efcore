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
            return Ok("这是一个测试用的文档显示");
        }
    }
}
