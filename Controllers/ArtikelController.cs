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
    public class ArtikelController : Controller
    {
        private readonly ILogger<ArtikelController> _logger;

        public ArtikelController(ILogger<ArtikelController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
