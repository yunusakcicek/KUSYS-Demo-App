using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
