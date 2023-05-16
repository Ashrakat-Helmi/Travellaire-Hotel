using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
