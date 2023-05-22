using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly IWebHostEnvironment _environment;

        public BookController(ApplicationDBcontext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index(int? id)
        {
            var name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(name)) { return RedirectToAction("login", "login"); }
            ViewData["session"] = HttpContext.Session.GetString("Name");
            ViewBag.userId = HttpContext.Session.GetString("UserID");
            ViewBag.roomId = id;
            var room = await _context.rooms.FindAsync(id);
            ViewBag.price = room.priceParNight;
            return View();
        }
        [HttpPost]
        public IActionResult book(Booking book)
        {

            if (ModelState.IsValid)
            {
                _context.bookings.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }

            return View("Index", book);

        }


    }
}
