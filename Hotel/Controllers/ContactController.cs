using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
