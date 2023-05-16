using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDBcontext db;
        public RegisterController(ApplicationDBcontext db) { this.db = db;  }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public IActionResult register(RegisterModel user)
        {

            if (ModelState.IsValid)
            {
                db.registerModels.Add(user);
                db.SaveChanges();
                return RedirectToAction("login", "login"); 
            }
            return View(user);
        }

      

       

    }
}
