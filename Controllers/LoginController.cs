using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using it_shop_app.Models;
using it_shop_app.Data;

namespace it_shop_app.Controllers {
    public class LoginController : Controller {
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
