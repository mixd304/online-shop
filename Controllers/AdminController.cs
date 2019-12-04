using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Data;

namespace it_shop_app.Controllers {
    public class AdminController : Controller {
        private readonly ShopContext _context;
        
        /**
         * <summary>
         * Konstruktor
         * </summary>
         * 
         * <param name="context"> Datenbankcontext mit dem operationen auf der Datenbank durchgeführt werden </param>
         */
        public AdminController(ShopContext context)
        {
            _context = context;
        }

        /**
         * <summary>
         * Gibt eine Liste von Registrierten Nutzern aus
         * </summary>
         * 
         * <returns>
         * Nutzer View
         * </returns>
         */
        public IActionResult Nutzer()
        {
            return View();
        }

        /**
         * <summary>
         * Gibt das Artikel_Index View mit einer Liste von Artikeln wieder 
         * </summary>
         * 
         * <returns>
         * Artikel_Index View
         * </returns>
         */
        public async Task<IActionResult> Artikel_Index()
        {
            await _context.Merkmale.ToListAsync();
            return View("Views/Admin/Artikel/Index.cshtml", await _context.Artikel.ToListAsync());
        }

        /**
         * <summary>
         * Gibt das Artikel_Edit View aus und übergibt den Ausgewählten Artikel zum bearbeiten
         * </summary>
         * 
         * <returns>
         * Artikel_Edit View
         * </returns>
         * 
         * <param name="id"> ID des gewählten Artikels zum Bearbeiten </param>
         */
        public async Task<IActionResult> Artikel_Edit(int? id)
        {                      
            return View("Views/Admin/Artikel/Edit.cshtml", await _context.Artikel.FirstOrDefaultAsync(m => m.ID == id));
        }

        /**
         */
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

        /**
         */
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

        /**
         */
        public IActionResult Artikel_Create()
        {        
            return View("Views/Admin/Artikel/Create.cshtml");
        }

        /**
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateArtikelViewModel model)
        {
            if (ModelState.IsValid)
            {           
                _context.Add(model.kategorie);
                await _context.SaveChangesAsync();

                Console.WriteLine("=====================Kategorie======================");
                Console.WriteLine("Kategorie:             " + model.kategorie.Bezeichnung);
                Console.WriteLine("KategorieID:           " + model.kategorie.ID);

                model.artikel.Kategorie_ID = model.kategorie.ID;
                _context.Add(model.artikel);
                await _context.SaveChangesAsync();

                Console.WriteLine("=====================Artikel=======================");
                Console.WriteLine("Artikel Bezeichnung:    " + model.artikel.Bezeichnung);
                Console.WriteLine("Artikel Beschreibung:   " + model.artikel.Beschreibung);
                Console.WriteLine("Kategorie ID:           " + model.artikel.Kategorie_ID);

                model.merkmal.Artikel_ID = model.artikel.ID;
                _context.Add(model.merkmal);
                await _context.SaveChangesAsync();

                Console.WriteLine("=====================Merkmal=======================");
                Console.WriteLine("Merkmal Bezeichnung:    " + model.merkmal.Bezeichnung);
                Console.WriteLine("Merkmal Wert:           " + model.merkmal.Wert);
                Console.WriteLine("Artikel ID:             " + model.merkmal.Artikel_ID);

                return View("Views/Admin/Artikel/Details.cshtml", model.artikel);
            }
            return View(model);
        }

        /**
         */
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

        /**
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Artikel.FindAsync(id);
            _context.Artikel.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Artikel_Index");
        }

        /**
         */
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
