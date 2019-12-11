using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Data;
using NToastNotify;
using System.Linq;
using StatiEnum = it_shop_app.Models.Stati;

namespace it_shop_app.Controllers {
    /**
     * <summary>
     * Controller der Für alle Aktionen mit dem Admin bereich verantwortlich ist
     * </summary>
     */
    public class AdminController : Controller {
        private readonly ShopContext _context;
        private readonly IToastNotification _toastNotification;
        
        /**
         * <summary>
         * Konstruktor
         * </summary>
         * 
         * <param name="context"> Datenbankcontext mit dem operationen auf der Datenbank durchgeführt werden </param>
         */
        public AdminController(ShopContext context, IToastNotification toast)
        {
            _context = context;
            _toastNotification = toast;
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

            await _context.Kategorien.ToListAsync();
            await _context.Farben.ToListAsync();
            await _context.Merkmale.ToListAsync();
            await _context.ArtikelFarben.ToListAsync();
            await _context.MerkmalBezeichnungen.ToListAsync();

            Artikel art = await _context.Artikel.FirstOrDefaultAsync(m => m.ID == id);

            EditViewModel model = new EditViewModel()
            {
                artikel = art,
            };
            
            if(art.ArtikelFarben != null) { model.farben = art.ArtikelFarben.ToList(); }
            if(art.Merkmale != null)      { model.merkmale = art.Merkmale.ToList(); }

            return View("Views/Admin/Artikel/Edit.cshtml", model);
        }      

        [HttpPost]
        public async Task<IActionResult> Artikel_Edit(EditViewModel model)
        {            
            _context.Update(model.artikel);
            await _context.SaveChangesAsync();

            if(model.merkmale != null)
            {            
                foreach(Merkmal a in model.merkmale)
                {
                    a.Artikel_ID = model.artikel.ID;
                    _context.Update(a);
                }                
            }

            if (model.farben != null)
            {
                foreach (ArtikelFarben b in model.farben)
                {
                    b.Artikel_ID = model.artikel.ID;
                    _context.Update(b.Farbe);
                }
            }
           
            await _context.SaveChangesAsync();

            return RedirectToAction("Artikel_Edit", model.artikel.ID);
        }

        public async Task<IActionResult> NeuFarbe(int id)
        {
            var query = from af in _context.Artikel
                        select af;
            query = query.Where(af => af.ID == id);
            Artikel qArtikel = await query.FirstOrDefaultAsync();

            return View("Views/Admin/Artikel/NeuFarbe.cshtml", new ArtikelFarben() { Artikel_ID = id, Artikel = qArtikel });
        }

        [HttpPost]
        public async Task<IActionResult> NeuFarbe(ArtikelFarben model)
        {
            Farbe newFarbe = new Farbe();
            ArtikelFarben newAF = new ArtikelFarben();

            var query = from f in _context.Farben
                        select f;

            query = query.Where(f => f.Bezeichnung.Equals(model.Farbe.Bezeichnung));
            Farbe qFarbe = query.FirstOrDefault();            

            newAF.Artikel_ID = model.Artikel_ID;
            if (qFarbe != null)
            {
                newAF.Farbe_ID = qFarbe.ID;
                var afQuery = from af in _context.ArtikelFarben
                              select af;

                afQuery = afQuery.Where(af => af.Artikel_ID == model.Artikel_ID);
                afQuery = afQuery.Where(af => af.Farbe_ID == qFarbe.ID);

                ArtikelFarben dieAF = await afQuery.FirstOrDefaultAsync();
                if ( dieAF != null)
                {                    
                    _toastNotification.AddWarningToastMessage("Diese Farbe wurde bereits hinzugefügt!");
                    return RedirectToAction("Artikel_Edit", "Admin", new { id = model.Artikel_ID });
                }

            } 
            else if (qFarbe == null)
            {
                newFarbe.Bezeichnung = model.Farbe.Bezeichnung;
                _context.Add(newFarbe);
                await _context.SaveChangesAsync();

                newAF.Farbe_ID = newFarbe.ID;
            }
                        
            _context.Add(newAF);
            await _context.SaveChangesAsync();

            return RedirectToAction("Artikel_Edit", "Admin", new { id = model.Artikel_ID });
        }

        public async Task<IActionResult> NeuMerkmal(int? id)
        {
            var query = from af in _context.Artikel
                        select af;
            query = query.Where(af => af.ID == id);
            Artikel qArtikel = await query.FirstOrDefaultAsync();

            return View("Views/Admin/Artikel/NeuMerkmal.cshtml", new Merkmal() { Artikel = qArtikel});
        }

        [HttpPost]
        public async Task<IActionResult> NeuMerkmal(Merkmal model)
        {
            MerkmalBezeichnung merkmalBez = new MerkmalBezeichnung();
            Merkmal newMerkmal = new Merkmal();

            var mbQuery = from mb in _context.MerkmalBezeichnungen
                          select mb;

            mbQuery = mbQuery.Where(mb => mb.Bezeichnung.Equals(model.Bezeichnung.Bezeichnung));

            MerkmalBezeichnung qMerkmal = await mbQuery.FirstOrDefaultAsync();

            newMerkmal.Artikel_ID = model.Artikel_ID;
            newMerkmal.Wert = model.Wert;

            if(qMerkmal != null)
            {
                newMerkmal.Bezeichnung_ID = qMerkmal.ID;

                var mQuery = from m in _context.Merkmale
                             select m;

                mQuery = mQuery.Where(m => m.Bezeichnung_ID == qMerkmal.ID);
                mQuery = mQuery.Where(m => m.Artikel_ID == model.Artikel_ID);

                Merkmal dasEineMerkmal = await mQuery.FirstOrDefaultAsync();

                if (dasEineMerkmal != null)
                {                    
                    _toastNotification.AddWarningToastMessage("Dieses Merkmal wurde bereits hinzugefügt!");
                    return RedirectToAction("Artikel_Edit", "Admin", new { id = model.Artikel_ID });
                }
            }
            else if(qMerkmal == null)
            {
                merkmalBez.Bezeichnung = model.Bezeichnung.Bezeichnung;
                _context.Add(merkmalBez);
                await _context.SaveChangesAsync();

                newMerkmal.Bezeichnung_ID = merkmalBez.ID;
            }

            _context.Add(newMerkmal);
            await _context.SaveChangesAsync();

            return RedirectToAction("Artikel_Edit", new { id = model.Artikel_ID });
        }

        public async Task<IActionResult> deleteFarbe(int artId, int farbId)
        {
            Console.WriteLine(artId);
            Console.WriteLine(farbId);

            ArtikelFarben farbe = new ArtikelFarben()
            {
                Artikel_ID = artId,
                Farbe_ID =farbId
            };

            _context.Remove(farbe);
            await _context.SaveChangesAsync();

            return RedirectToAction("Artikel_Edit", new { id = artId });
        }

        public async Task<IActionResult> deleteMerkmal(int id, int artId)
        {
            Console.WriteLine(id);

            Merkmal m = new Merkmal()
            {
                ID = id
            };

            _context.Remove(m);
            await _context.SaveChangesAsync();

            return RedirectToAction("Artikel_Edit", new { id = artId });
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
        public async Task<IActionResult> Artikel_CreateAsync()
        {
            return View("Views/Admin/Artikel/Create.cshtml", new CreateArtikelMultipleMerkmaleViewModel() { vorhandeFarben = await _context.Farben.ToListAsync() });
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
        public async Task<IActionResult> Create(CreateArtikelMultipleMerkmaleViewModel model)
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

                for(int i=0; i < model.merkmalBezeichnungen.Count; i++)
                {
                    MerkmalBezeichnung merkmalBezeichnung = await _context.MerkmalBezeichnungen.FirstOrDefaultAsync(mb => mb.Bezeichnung == model.merkmalBezeichnungen[i].Bezeichnung);
                    if (merkmalBezeichnung == null)
                    {
                        _context.Add(model.merkmalBezeichnungen[i]);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        model.merkmalBezeichnungen[i] = merkmalBezeichnung;
                    }
                }

                for (int i = 0; i < model.merkmale.Count; i++)
                {
                    model.merkmale[i].Bezeichnung_ID = model.merkmalBezeichnungen[i].ID;
                    model.merkmale[i].Artikel_ID = model.artikel.ID;
                    _context.Add(model.merkmale[i]);
                }
                await _context.SaveChangesAsync();

                for (int i = 0; i < model.farben.Count; i++)
                {

                    if (model.farben[i].Equals(""))
                    {
                        continue;
                    } 
                    else
                    {
                        Farbe farbe = await _context.Farben.FirstOrDefaultAsync(f => f.Bezeichnung == model.farben[i].Bezeichnung);
                        if (farbe == null)
                        {
                            _context.Add(model.farben[i]);
                            await _context.SaveChangesAsync();                            
                        }
                        else
                        {
                            model.farben[i] = farbe;
                        }
                    }

                    _context.Add(new ArtikelFarben() { Artikel_ID = model.artikel.ID, Farbe_ID = model.farben[i].ID });
                    await _context.SaveChangesAsync();
                }

                return View("Views/Admin/Artikel/Details.cshtml", model.artikel);
        }
            return View("Views/Admin/Artikel/Create.cshtml", model);
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

        /**
         * <summary>
         * Nicht verlinkte View in der alle Bestellungen aufgelistet werden 
         * und die Stati durchgeschaltet werden können
         * </summary>
         * 
         * <returns>
         * Stati View
         * </returns>
         */
        public async Task<IActionResult> Stati()
        {
            await _context.Nutzer.ToListAsync();           
            return View(await _context.Bestellungen.ToListAsync());
        }

        /**
         * <summary>
         * Setzt den Status einer Bestellung auf den Zustand je nach Button der gedrückt wurde
         * </summary>
         * 
         * <returns>
         * Redirect zu Stati View
         * </returns>
         * 
         * <param name="id"> ID der Bestellung dessen Status gesetzt werden soll </param>
         * <param name="status"> Status den die Bestellunge bekommen soll</param>
         */
        public async Task<IActionResult> changeStati(int id, string status)
        {
            var query = from w in _context.Bestellungen
                        select w;

            query = query.Where(w => w.ID == id);

            Bestellung bes = query.FirstOrDefault();            

            switch(status)
            {
                case "Eingegangen":
                    bes.Status = StatiEnum.Eingegangen;
                    break;
                case "InBearbeitung":
                    bes.Status = StatiEnum.InBearbeitung;
                    break;
                case "Storniert":
                    bes.Status = StatiEnum.Storniert;
                    break;
                case "Versandt":
                    bes.Status = StatiEnum.Versandt;
                    break;
                case "Abgeschlossen":
                    bes.Status = StatiEnum.Abgeschlossen;
                    break;
            }
            _context.Update(bes);
            _toastNotification.AddSuccessToastMessage("Status der Bestellung NR.: " + id + " auf " + status + " gesetzt!");
            await _context.SaveChangesAsync();
            return RedirectToAction("Stati");
        }
    }
}
