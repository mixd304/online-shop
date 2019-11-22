using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using it_shop_app.Models;

namespace it_shop_app.Controllers
{
    public class ProfilController : Controller
    {
        private readonly ILogger<ProfilController> _logger;

        public ProfilController(ILogger<ProfilController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
