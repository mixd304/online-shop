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

        public async Task<IActionResult> Merkmal_Create(int id) {

            await _context.Merkmale.ToListAsync();

            var artikel = await _context.Artikel
                .FirstOrDefaultAsync(m => m.ID == id);

            if (artikel == null)
            {
                return NotFound();
            }

            var model = new CreateArtikelViewModel();
            model.artikel = artikel;

            return View("Views/Admin/Artikel/CreateMerkmal.cshtml", model);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Merkmal_Create(int id, CreateArtikelViewModel model) {

            await _context.Merkmale.ToListAsync();

            var artikel = await _context.Artikel
                .FirstOrDefaultAsync(m => m.ID == id);

            if (artikel == null)
            {
                return NotFound();
            }

            model.artikel = artikel;

            Console.WriteLine("=====================TEST=======================");
            Console.WriteLine("Artikel Bezeichnung:    " + model.artikel.Bezeichnung);
            Console.WriteLine("Artikel Beschreibung:   " + model.artikel.Beschreibung);
            Console.WriteLine("Merkmal Bezeichnung:    " + model.merkmal.Bezeichnung);
            Console.WriteLine("Merkmal Wert:           " + model.merkmal.Wert);            

            model.merkmal.Artikel_ID = model.artikel.ID;
            Console.WriteLine();

            Console.WriteLine("Artikel PK:             " + model.artikel.ID);
            Console.WriteLine("Merkmal Fremdschlüssel: " + model.merkmal.Artikel_ID);

            _context.Add(model.merkmal);
            await _context.SaveChangesAsync();

            return View("Views/Admin/Artikel/CreateMerkmal.cshtml", model);
        }

        public IActionResult Artikel_Create()
        {        
            return View("Views/Admin/Artikel/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateArtikelViewModel model)
        {
            if (ModelState.IsValid)
            {

                Console.WriteLine("=====================TEST=======================");
                Console.WriteLine("Artikel Bezeichnung:    " + model.artikel.Bezeichnung);
                Console.WriteLine("Artikel Beschreibung:   " + model.artikel.Beschreibung);
                Console.WriteLine("Merkmal Bezeichnung:    " + model.merkmal.Bezeichnung);
                Console.WriteLine("Merkmal Wert:           " + model.merkmal.Wert);                
                
                _context.Add(model.artikel);                
                await _context.SaveChangesAsync();

                model.merkmal.Artikel_ID = model.artikel.ID;
                Console.WriteLine();

                Console.WriteLine("Artikel PK:             " + model.artikel.ID);
                Console.WriteLine("Merkmal Fremdschlüssel: " + model.merkmal.Artikel_ID);

                _context.Add(model.merkmal);
                await _context.SaveChangesAsync();

                return View("Views/Admin/Artikel/Details.cshtml", model.artikel);
            }
            return View(model);
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
