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

        public async Task<IActionResult> Index(string selectedKategorie, string searchString)
        {
            await _context.Kategorien.ToListAsync();
            await _context.Merkmale.ToListAsync();

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
       
        public async Task<IActionResult> Warenkorb()
        {
            List<int> anz = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            IdentityNutzer user = await _UserManager.GetUserAsync(User);

            if(_SignInManager.IsSignedIn(User)) {
                var warenkoerbeQuery = from w in _context.Warenkoerbe
                                select w;          

                warenkoerbeQuery = warenkoerbeQuery.Where(w => w.Nutzer_ID.Equals(user.Id));

                await _context.Artikel.ToListAsync();
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

        public async Task<IActionResult> addToCart(int? id) {

            if(!_SignInManager.IsSignedIn(User)){
                _toastNotification.AddWarningToastMessage("Du musst angemeldet sein um ein Produkt deinem Warenkorb hinzuzufügen!");
                return RedirectToAction("Index");
            }

            Console.WriteLine("==============Ausgabe====================");
            Console.WriteLine("übergebene ID: " + id);

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
            
            Console.WriteLine("==============Ausgabe====================");
            Console.WriteLine("Ausgewählter Artikel: " + artikel.Bezeichnung);

            await _context.Warenkoerbe.ToListAsync();

            try {
                IdentityNutzer user = await _UserManager.GetUserAsync(User);

                Warenkorb wkModel = new Warenkorb();
                wkModel.Artikel_ID = artikel.ID;
                wkModel.Nutzer_ID = user.Id;
                wkModel.Anzahl = 1;

                Console.WriteLine("==============Ausgabe====================");
                Console.WriteLine("WK Eintrag: " + wkModel.Artikel_ID + " / " +  wkModel.Nutzer_ID);

                _context.Add(wkModel);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Artikel erfolgreich Hinzugefügt!");
                return RedirectToAction("Index");
            } catch {
                _toastNotification.AddInfoToastMessage("Artikel bereits hinzugefügt!");
                return RedirectToAction("Index");        
            }            
        }

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

        public IActionResult bestellen()
        {
            _toastNotification.AddErrorToastMessage("Noch nicht implementiert!");
            return RedirectToAction("Warenkorb");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAnzahl(Warenkorb warenkorb) {

            Console.WriteLine("=================TEST==================");
            Console.WriteLine("Artikel ID:    " + warenkorb.Artikel_ID);
            Console.WriteLine("Nutzer ID:     " + warenkorb.Nutzer_ID);

            Console.WriteLine("Anzahl (ID):   " + warenkorb.Anzahl);

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
