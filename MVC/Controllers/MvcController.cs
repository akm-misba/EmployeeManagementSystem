using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MvcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
