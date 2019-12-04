using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using it_shop_app.Models;
using it_shop_app.Data;
using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Controllers {
    public class HomeController : Controller {
        private readonly ShopContext _context;

        public HomeController(ShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Impressum()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string HeadUserInfo(IdentityNutzer user) {
            return user.Name;
        }
    }
}
