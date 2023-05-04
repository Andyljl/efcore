using Microsoft.AspNetCore.Mvc;

namespace EFMysql.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("Home/Index")]
        public IActionResult Index()
        {
            if (true)
            {

            }
            return Ok("这是一个测试用的文档显示");
        }
    }
}
