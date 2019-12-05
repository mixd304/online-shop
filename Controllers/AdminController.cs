using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Data;

namespace it_shop_app.Controllers {
    /**
     * <summary>
     * Controller der Für alle Aktionen mit dem Admin bereich verantwortlich ist
     * </summary>
     */
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
         * <summary>
         * Gibt die MerkmalCreate View aus und übergibt einen Artikel der der ID entspricht
         * </summary>
         * 
         * <returns>
         * CreateMerkmal View
         * </returns>
         * 
         * <param name="id"> id des Artikels für das neue Merkmale angelegt werden sollen </param>
         */
        public async Task<IActionResult> Merkmal_Create(int id) {

            await _context.MerkmalBezeichnungen.ToListAsync();
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
         * <summary>
         * Post Methode für das MerkmalCreate View. Bekommt das model mit dem Merkmal
         * Speichert nur ein Merkmal in die Datenbank und ruft die MerkmalCreate View nochmal auf
         * </summary>
         * 
         * <returns>
         * CreateMerkmal View
         * </returns>
         * 
         * <param name="id"> id des Artikels für das Merkmale angelegt werden </param>
         * <param name="model"> Model mit dem Merkmal </param>
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Merkmal_Create(int id, CreateArtikelViewModel model) {

            await _context.MerkmalBezeichnungen.ToListAsync();
            await _context.Merkmale.ToListAsync();
            var artikel = await _context.Artikel
                .FirstOrDefaultAsync(m => m.ID == id);

            if (artikel == null)
            {
                return NotFound();
            }

            model.artikel = artikel;

            MerkmalBezeichnung merkmalBezeichnung = await _context.MerkmalBezeichnungen.FirstOrDefaultAsync(mb => mb.Bezeichnung == model.merkmalBezeichnung.Bezeichnung);
            if (merkmalBezeichnung == null)
            {
                _context.Add(model.merkmalBezeichnung);
                await _context.SaveChangesAsync();
            }
            else
            {
                model.merkmalBezeichnung = merkmalBezeichnung;
            }

            model.merkmal.Bezeichnung_ID = model.merkmalBezeichnung.ID;
            model.merkmal.Artikel_ID = model.artikel.ID;

            _context.Add(model.merkmal);
            await _context.SaveChangesAsync();

            return View("Views/Admin/Artikel/CreateMerkmal.cshtml", model);
        }

        /**
         * <summary>
         * Gibt die Create View für einen Artikel aus
         * </summary>
         * 
         */
        public IActionResult Artikel_Create()
        {        
            return View("Views/Admin/Artikel/Create.cshtml");
        }

        /**
         * <summary>
         * Post Methode des Create Views
         * Bekommt ein Model mit Artikel Kategorie und Merkmal eines fertigen Arikel und speichert 
         * diese in die Datenbank.
         * </summary>
         * 
         * <returns>
         * Wenn der Artikel erfolgreich gespeichert wurde, wird die Details View mit dem neu 
         * angelegten Artikel angezeigt
         * </returns>
         * 
         * <param name="model"> Model das ein Artikel eine Kategorie und ein Merkmal beinhaltet mit den eingegebenen Daten des Nutzers </param>
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateArtikelViewModel model)
        {
            if (ModelState.IsValid)
            {
                Kategorie kategorie = await _context.Kategorien.FirstOrDefaultAsync(k => k.Bezeichnung == model.kategorie.Bezeichnung);
                if (kategorie == null)
                { 
                    _context.Add(model.kategorie);
                    await _context.SaveChangesAsync();
                } 
                else
                {
                    model.kategorie = kategorie;
                }

                model.artikel.Kategorie_ID = model.kategorie.ID;
                _context.Add(model.artikel);
                await _context.SaveChangesAsync();

                MerkmalBezeichnung merkmalBezeichnung = await _context.MerkmalBezeichnungen.FirstOrDefaultAsync(mb => mb.Bezeichnung == model.merkmalBezeichnung.Bezeichnung);
                if (merkmalBezeichnung == null)
                {
                    _context.Add(model.merkmalBezeichnung);
                    await _context.SaveChangesAsync();
                } 
                else
                {
                    model.merkmalBezeichnung = merkmalBezeichnung;
                }

                model.merkmal.Bezeichnung_ID = model.merkmalBezeichnung.ID;
                model.merkmal.Artikel_ID = model.artikel.ID;
                _context.Add(model.merkmal);
                await _context.SaveChangesAsync();

                return View("Views/Admin/Artikel/Details.cshtml", model.artikel);
            }
            return View(model);
        }

        /**
         * <summary>
         * Gibt die Sicherheitsabfrage aus ob der Artikel mit der Übergebenen ID wirklich gelöscht werden soll
         * </summary>
         * 
         * <returns>
         * Sicherheitsabfrage ob gelöscht werden soll
         * </returns>
         * 
         * <param name="id"> id des Artikels </param>
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
         * <summary>
         * Löscht den Artikel mit der angegebenen ID in der Datenbank
         * </summary>
         * 
         * <returns>
         * Index View des Admin Controllers
         * </returns>
         * 
         * <param name="id"> ID des Artikels</param>
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
         * <summary>
         * Gibt die Details Seite von dem Artikel mit der üebrgebenen ID aus
         * </summary>
         * 
         * <returns>
         * Details View
         * </returns>
         * 
         * <param name="id"> ID eines Artikels der angezeigt werden soll </param>
         */
        public async Task<IActionResult> Artikel_Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            await _context.MerkmalBezeichnungen.ToListAsync();
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
