using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDBcontext db;
        private readonly IWebHostEnvironment _environment;
        public ProfileController(ApplicationDBcontext db, IWebHostEnvironment environment) {
            this.db = db;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(name)) { return RedirectToAction("login", "login"); }
            ViewData["userId"] = HttpContext.Session.GetString("UserID");
            ViewData["session"] = HttpContext.Session.GetString("Name");
            if(ViewBag.userId == null)
            {
                return NotFound();
            }
            var user = await db.registerModels.FirstOrDefaultAsync(predicate: u => u.ID == Convert.ToInt32(ViewData["userId"]));
            List<Booking> book = db.bookings.Where(u => u.UserId == Convert.ToInt32(ViewData["userId"])).ToList();
            List<Contact> contact = db.contacts.Where(u => u.userId == Convert.ToInt32(ViewData["userId"])).ToList();
           
            if (user == null)
            {
                return NotFound();
            }
            return View(user);



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] RegisterModel user, IFormFile userPic)
        {
            if (id != user.ID)
            {
                return NotFound();
            }
            string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (userPic != null)
            {
                path = Path.Combine(path, userPic.FileName); // for exmple : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await userPic.CopyToAsync(stream);
                    ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", userPic.FileName.ToString());
                }
                user.userPic= userPic.FileName;
            }
            else
            {
                user.userPic = "ava3.webp"; // to save the default image path in database.
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.registerModels.Update(user);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                      throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
