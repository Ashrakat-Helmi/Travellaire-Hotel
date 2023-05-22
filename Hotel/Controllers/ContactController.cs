using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDBcontext db;
        public ContactController(ApplicationDBcontext db) { this.db = db; }

        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(name)) { return RedirectToAction("login", "login"); }
            ViewData["session"] = HttpContext.Session.GetString("Name");
            ViewBag.userId = HttpContext.Session.GetString("UserID");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {

            if (ModelState.IsValid)
            {
                db.contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("index", "profile");
            }
            return View(contact);
        }
    }


}
