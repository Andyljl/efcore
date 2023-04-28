using Microsoft.AspNetCore.Mvc;

namespace EFMysql.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
