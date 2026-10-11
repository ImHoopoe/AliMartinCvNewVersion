using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
