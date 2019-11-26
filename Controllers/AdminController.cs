using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using it_shop_app.Models;

namespace it_shop_app.Controllers {
    public class AdminController : Controller {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Nutzer()
        {
            return View();
        }

        public IActionResult Artikel()
        {
            return View();
        }
    }
}
