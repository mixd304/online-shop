using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Data;
using Microsoft.AspNetCore.Identity;
using it_shop_app.Areas.Identity.Data;
using NToastNotify;


namespace it_shop_app.Controllers {
    public class ArtikelController : Controller {
        private readonly ShopContext _context;
        private readonly UserManager<IdentityNutzer> _UserManager;
        private readonly SignInManager<IdentityNutzer> _SignInManager;
        private readonly IToastNotification _toastNotification;

        /**
         * <summary>
         * Konstruktor
         * </summary>
         * 
         * <param name="context"> Datenbankcontext mit dem Operationen auf der Datenbank ausgeführt werden </param>
         * <param name="SignInManager"> Service mit dem Überprüft werden kann ob ein User angemeldet ist </param>
         * <param name="toastNotification"> Service mit dem ToastNotifications auf der Oberfläche ausgegeben werden können </param>
         * <param name="UserManager"> 
         * Service mit dem man an die Daten eines Nutzers kommt 
         * (auch über den ShopContext möglich || wenn es nur um den eingeloggten Nutzer geht ist der UserManager jedoch einfacher)
         * </param>
         */
        public ArtikelController(
            ShopContext context, 
            UserManager<IdentityNutzer> UserManager, 
            SignInManager<IdentityNutzer> SignInManager, 
            IToastNotification toastNotification)
        {
            _context = context;
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _toastNotification = toastNotification;
        }

        /**
         * <summary>
         * Gibt die Liste aller verfügbaren Artikel zurück und übergibt eine Liste von Artikeln.
         * </summary>
         * 
         * <returns>
         * Das Index View 
         * </returns>
         * 
         * <param name="selectedKategorie"> Die Ausgewählte Kategorie nach der Gefilltert wird </param>
         * <param name="searchString"> Der String der in das Suchfeld eingegeben wurde </param>              
         */
        public async Task<IActionResult> Index(string selectedKategorie, string searchString)
        {
            await _context.Kategorien.ToListAsync();
            await _context.Merkmale.ToListAsync();
            await _context.Farben.ToListAsync();
            await _context.ArtikelFarben.ToListAsync();

            IQueryable<string> kategorienQuery = from m in _context.Artikel
                                                 orderby m.Kategorie.Bezeichnung
                                                 select m.Kategorie.Bezeichnung;

            var artikel = from m in _context.Artikel
                          select m;

            if (!String.IsNullOrEmpty(searchString)) {
                artikel = artikel.Where(s => s.Bezeichnung.Contains(searchString));
            }

            Console.WriteLine("=======================TEST===================");
            Console.WriteLine("Kategorie: " + selectedKategorie);
            Console.WriteLine("Suche:     " + searchString);

            if (!String.IsNullOrEmpty(selectedKategorie) && !selectedKategorie.Equals("Alle"))
            {
                artikel = artikel.Where(x => x.Kategorie.Bezeichnung == selectedKategorie);
            }

            var ArtInViewModel = new ArtikelIndexViewModel()
            {
                artikel = await artikel.ToListAsync(),
                kategorien = new SelectList(await kategorienQuery.Distinct().ToListAsync())
            };

            return View(ArtInViewModel);
        }

        /**
         * <summary>
         * Gibt die Detail Seite eines bestimmten Artikels aus für die übergebene ID und übergibt dem View ein Artikel Model.
         * </summary>
         * 
         * <returns>
         * Das Detail View 
         * </returns>
         * 
         * <param name="id"> Die ID des ausgewählten Artikels</param>
         */
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

            await _context.Kategorien.ToListAsync();
            await _context.Nutzer.ToListAsync();
            await _context.Kommentare.ToListAsync();
            return View(artikel);
        }

        /**
         * <summary>
         * Gibt die kommentarHinzufügen View aus und übergibt ein KommentarViewModel mit der SelectList für die Bewertung.
         * </summary>
         * 
         * <returns>
         * Das kommentarHinzufügen View 
         * </returns>
         * 
         * <param name="id"> Die ID eines Artikels das Kommentiert werden soll </param>
         */
        public async Task<IActionResult> kommentarHinzufügen(int? id)
        {
            List<int> bewertung = new List<int> {1, 2, 3, 4, 5};

            if(id == null) {
                _toastNotification.AddWarningToastMessage("Diesen Artikel gibt es nicht");
                return RedirectToAction("Index");
            }

            IdentityNutzer user = await _UserManager.GetUserAsync(User);

            if(!_SignInManager.IsSignedIn(User)) {
                _toastNotification.AddWarningToastMessage("Du musst angemeldet sein um einen Kommentar zu Schreiben!");
                return RedirectToAction("Index");
            }

            KommentarViewModel komModel = new KommentarViewModel() 
            {
                kommentar = new Kommentar(){
                    Artikel_ID = (int) id,
                    Nutzer_ID = user.Id
                },

                bewertung = new SelectList(bewertung)
            };

            return View(komModel);
        }

        /**
         * <summary>
         * Post Methode für das kommentarHinzufügen View es bekommt das Model der View und speichert daraus den Kommentar.
         * </summary>
         * 
         * <returns>
         * Eine Weiterleitung zur Detailansicht des Artikels
         * </returns>
         * 
         * <param name="model"> Model aus der View beinhaltet den Kommentar und die Bewertung</param>
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> kommentarHinzufügen(KommentarViewModel model) {
            Console.WriteLine("====================Test==================");
            Console.WriteLine("Inhalt:    " + model.kommentar.Inhalt);
            Console.WriteLine("Bewertung: " + model.kommentar.Bewertung);
            Console.WriteLine("Nutzer:    " + model.kommentar.Nutzer_ID);
            Console.WriteLine("Artikel:   " + model.kommentar.Artikel_ID);
            
            Kommentar kom = model.kommentar;

            _context.Add(kom);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = model.kommentar.Artikel_ID});
        }

        /**
         * <summary>
         * Zeigt den Warenkorb des momentan eingeloggten Nutzers an. Übergibt dafür ein WarenkorbViewmodel mit der 
         * SelectListe für die Anzahl und die Warenkoerbe.
         * (Warenkoerbe sind bei uns eine zuordung von Artikel_ID und Nutzer_ID)
         * </summary>
         * 
         * <returns>
         * Warenkorb View
         * </returns>
         */
        public async Task<IActionResult> Warenkorb()
        {
            List<int> anz = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            IdentityNutzer user = await _UserManager.GetUserAsync(User);

            if(_SignInManager.IsSignedIn(User)) {
                var warenkoerbeQuery = from w in _context.Warenkoerbe
                                select w;          

                warenkoerbeQuery = warenkoerbeQuery.Where(w => w.Nutzer_ID.Equals(user.Id));

                await _context.Artikel.ToListAsync();
                await _context.Farben.ToListAsync();
                var warenkorbListe = await warenkoerbeQuery.ToListAsync();

                WarenkorbViewmodel model = new WarenkorbViewmodel()
                {
                    Anzahl = new SelectList(anz),
                    Warenkoerbe = warenkorbListe
                };

                return View(model);
            }

            _toastNotification.AddWarningToastMessage("Du musst angemeldet sein um deinen Warenkorb anzuzeigen!");
            return RedirectToAction("Index");
        }

        /**
         * <summary>
         * Fügt ein Artikel dem Warenkorb des momentan eingeloggten Nutzers ein.
         * </summary>
         * 
         * <returns>
         * Weiterleitung zur Index View 
         * </returns>
         * 
         * <param name="id"> ID des Ausgewählten Artikels</param>
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addToCart(string selectedFarbe, int selectedArtikel_ID) {
            if (!_SignInManager.IsSignedIn(User)){
                _toastNotification.AddWarningToastMessage("Du musst angemeldet sein um ein Produkt deinem Warenkorb hinzuzufügen!");
                return RedirectToAction("Index");
            }

            IdentityNutzer user = await _UserManager.GetUserAsync(User);
            var artikel = await _context.Artikel.FirstOrDefaultAsync(a => a.ID == selectedArtikel_ID);
            var farbe = await _context.Farben.FirstOrDefaultAsync(f => f.Bezeichnung == selectedFarbe);

            var warenkoerbe = from w in _context.Warenkoerbe select w;
            warenkoerbe = warenkoerbe.Where(w => w.Nutzer_ID.Equals(user.Id));
            warenkoerbe = warenkoerbe.Where(w => w.Artikel_ID == selectedArtikel_ID);
            List<Warenkorb> erg = await warenkoerbe.ToListAsync();

            if(erg.Any())
            {
                if(farbe == null)
                {
                    Warenkorb warenkorb = erg.First();
                    warenkorb.Anzahl++;
                    _context.Update(warenkorb);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddInfoToastMessage("Gibt keine Farbe - Anzahl um 1 erhöht!");
                    return RedirectToAction("Index");
                }

                foreach (Warenkorb warenkorb in erg)
                {
                    if (warenkorb.Farbe_ID == farbe.ID)
                    {
                        warenkorb.Anzahl++;
                        _context.Update(warenkorb);
                        await _context.SaveChangesAsync();
                        _toastNotification.AddInfoToastMessage("Farbe vorhanden - Anzahl um 1 erhöht!");
                        return RedirectToAction("Index");
                    }
                }
            }            

            if (artikel == null) {
                return NotFound();
            }

            try {
                Warenkorb wkModel = new Warenkorb();
                wkModel.Artikel_ID = artikel.ID;
                wkModel.Nutzer_ID = user.Id;
                wkModel.Anzahl = 1;
                if(farbe != null)
                {
                    wkModel.Farbe_ID = farbe.ID;
                }

                _context.Add(wkModel);
                await _context.SaveChangesAsync();

                _toastNotification.AddSuccessToastMessage("Artikel erfolgreich Hinzugefügt!");
                return RedirectToAction("Index");
            } catch {
                _toastNotification.AddInfoToastMessage("Artikel bereits hinzugefügt!");
                return RedirectToAction("Index");        
            }
        }

        /**
         * <summary>
         * Entfernt einen Artikels aus dem Warenkorb des momentan eingeloggten Nutzers.
         * </summary>
         * 
         * <returns>
         * Warenkorb View
         * </returns>
         * 
         * <param name="warenkorb"> Die Warenkorb zeile die entfernt werden soll</param>
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(Warenkorb warenkorb)
        {           
            var warenkoerbe = from w in _context.Warenkoerbe
                                select w;

            warenkoerbe = warenkoerbe.Where(w => w.Nutzer_ID.Equals(warenkorb.Nutzer_ID));
            warenkoerbe = warenkoerbe.Where(w => w.Artikel_ID.Equals(warenkorb.Artikel_ID));

            List<Warenkorb> erg = await warenkoerbe.ToListAsync();

            _context.Warenkoerbe.Remove(erg.First());
            _toastNotification.AddSuccessToastMessage("Artikel erfolgreich entfernt!");

            await _context.SaveChangesAsync();
            return RedirectToAction("Warenkorb");
        }

        /**
         * <summary>
         * Legt eine neue Bestellung mit Zeitstempel in der Datenbank an und überträgt den 
         * Warenkorb in "die ArtikelBestellung" Zuordnungstabelle. Der Warenkorb wird dabei gelöscht.
         * </summary>
         * 
         * <returns>
         * Weiterleitung zur Index View
         * </returns>
         * 
         * <param name="model"> Model in dem lediglich der Gesamtpreis der Bestellung steht </param>
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> bestellen(WarenkorbViewmodel model)
        {            
            IdentityNutzer user = await _UserManager.GetUserAsync(User);

            Bestellung bestellung = new Bestellung()
            {
                Bestelldatum = DateTime.Now,
                Gesamtpreis = model.gesamtpreis,
                Nutzer_ID = user.Id
            };

            var warenkoerbeQuery = from w in _context.Warenkoerbe
                                   select w;

            warenkoerbeQuery = warenkoerbeQuery.Where(w => w.Nutzer_ID.Equals(user.Id));

            await _context.Artikel.ToListAsync();
            var warenkorbListe = await warenkoerbeQuery.ToListAsync();

            if (warenkorbListe == null || !warenkorbListe.Any())
            {
                _toastNotification.AddWarningToastMessage("Keine Artikel hinzugefügt die bestellt werden können!");
                return RedirectToAction("Warenkorb");
            }

            _context.Add<Bestellung>(bestellung);
            await _context.SaveChangesAsync();

            foreach (Warenkorb w in warenkorbListe)
            {
                _context.Add(new ArtikelBestellung() { Artikel_ID = w.Artikel_ID, Bestellung_ID = bestellung.ID, Anzahl = w.Anzahl, Farbe_ID = w.Farbe_ID });
                _context.Remove(w);
            }

            await _context.SaveChangesAsync();

            Console.WriteLine("=============================================");
            Console.WriteLine("Preis:     " + model.gesamtpreis);

            _toastNotification.AddSuccessToastMessage("Artikel erfolgreich bestellt");
            return RedirectToAction("Index");                
        }

        /**
         * <summary>
         * Updated die Anzahl der Artikel im Warenkorb wenn die Dropdownliste eines Artikels im Warenkorb verändert wird
         * </summary>
         * 
         * <returns>
         * Weiterleitung zurück zur Warenkorb View
         * </returns>
         * 
         * <param name="warenkorb"> Die Warenkorbzeile in der die Anzahl geändert wurde </param>
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAnzahl(Warenkorb warenkorb) {
            try
            {
                _context.Update(warenkorb);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
                throw;
            }

            return RedirectToAction("Warenkorb");
        }
    }
}
