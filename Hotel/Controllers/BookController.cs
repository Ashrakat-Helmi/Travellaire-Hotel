﻿using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
