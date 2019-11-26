using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using it_shop_app.Models;

namespace it_shop_app.Controllers {
    public class LoginController : Controllers {
        private readonly ShopContext _context;

        public LoginController(ShopContext context)
        {
            _context = context;
        }

        public IActionResult Anmelden()
        {
            return View();
        }

        public IActionResult Registrieren()
        {
            return View();
        }
    }
}