using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Data;

namespace it_shop_app.Controllers {
    public class ArtikelController : Controller {
        private readonly ShopContext _context;

        public ArtikelController(ShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await _context.Merkmale.ToListAsync();
            return View(await _context.Artikel.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _context.Merkmale.ToListAsync();
            var artikel = await _context.Artikel
                .FirstOrDefaultAsync(a => a.ID == id);
            if(artikel == null) {
                return NotFound();
            }

            return View(artikel);
        }

    }
}
