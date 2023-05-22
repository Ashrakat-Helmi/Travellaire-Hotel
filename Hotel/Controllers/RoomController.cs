using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.Models;
using Microsoft.Extensions.Hosting;

namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly IWebHostEnvironment _environment;
        public RoomController(ApplicationDBcontext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            ViewData["session"] = HttpContext.Session.GetString("Name");
            var name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(name)) { return RedirectToAction("login", "login"); }

            return _context.rooms != null ?
                          View(await _context.rooms.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBcontext.rooms'  is null.");
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.rooms == null)
            {
                return NotFound();
            }

            var room = await _context.rooms
                .FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,roomName,roomType,priceParNight,availiablilty,numberOfBookingTimes")] Room room, IFormFile room_Pic)
        {
            string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (room_Pic != null)
            {
                path = Path.Combine(path, room_Pic.FileName); // for exmple : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await room_Pic.CopyToAsync(stream);
                    ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", room_Pic.FileName.ToString());
                }
                room.room_Pic = room_Pic.FileName;
            }
            else
            {
                room.room_Pic = "Rectangle 1138.png"; // to save the default image path in database.
            }
            try
            {
                _context.Add(room);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) { ViewBag.exc = ex.Message; }

            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.rooms == null)
            {
                return NotFound();
            }

            var room = await _context.rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,roomName,roomType,priceParNight,availiablilty,numberOfBookingTimes,room_Pic")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.rooms == null)
            {
                return NotFound();
            }

            var room = await _context.rooms
                .FirstOrDefaultAsync(m => m.ID == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.rooms == null)
            {
                return Problem("Entity set 'ApplicationDBcontext.rooms'  is null.");
            }
            var room = await _context.rooms.FindAsync(id);
            if (room != null)
            {
                _context.rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return (_context.rooms?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
