using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Data;

namespace it_shop_app.Controllers {
    public class AdminController : Controller {
        private readonly ShopContext _context;

        public AdminController(ShopContext context)
        {
            _context = context;
        }

        public IActionResult Nutzer()
        {
            return View();
        }

        public async Task<IActionResult> Artikel_Index()
        {
            await _context.Merkmale.ToListAsync();
            return View("Views/Admin/Artikel/Index.cshtml", await _context.Artikel.ToListAsync());
        }

        public async Task<IActionResult> Artikel_Edit(int? id)
        {                      
            return View("Views/Admin/Artikel/Edit.cshtml", await _context.Artikel.FirstOrDefaultAsync(m => m.ID == id));
        }

        public IActionResult Artikel_Create()
        {
            return View("Views/Admin/Artikel/Create.cshtml");
        }

        public async Task<IActionResult> Artikel_Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _context.Merkmale.ToListAsync();
            var artikel = await _context.Artikel.FirstOrDefaultAsync(m => m.ID == id);

            if (artikel == null)
            {
                return NotFound();
            }

            return View("Views/Admin/Artikel/Delete.cshtml", artikel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Artikel.FindAsync(id);
            _context.Artikel.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Artikel_Index");
        }

        public async Task<IActionResult> Artikel_Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            await _context.Merkmale.ToListAsync();

            var artikel = await _context.Artikel
                .FirstOrDefaultAsync(m => m.ID == id);

            if (artikel == null)
            {
                return NotFound();
            }

            return View("Views/Admin/Artikel/Details.cshtml", artikel);
        }
    }
}
