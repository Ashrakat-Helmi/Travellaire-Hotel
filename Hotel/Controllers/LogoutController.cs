using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("Name");
            return RedirectToAction("index", "Home");
        }
    }
}
