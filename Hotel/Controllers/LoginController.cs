using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBcontext db;
        public LoginController(ApplicationDBcontext db) { this.db = db; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = db.registerModels.FirstOrDefault(u => u.userEmail == userLogin.userEmail);
                if (user != null)
                {
                    HttpContext.Session.SetString("Name", user.userName);
                    HttpContext.Session.SetString("UserID", user.ID.ToString());

                    return RedirectToAction("index", "Home");
                }
                else
                {

                    ModelState.AddModelError("", "Invaild Email or Password");
                }
            }

            return View(userLogin);
        }

    }
}
