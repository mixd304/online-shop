using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using it_shop_app.Models;
using it_shop_app.Data;
using it_shop_app.Areas.Identity.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace it_shop_app.Controllers {

    /**
     * Controller für die Startseite, Impressum und Privacy des Shops
     */
    public class HomeController : Controller {
        private readonly ShopContext _context;

        public HomeController(ShopContext context)
        {
            _context = context;
        }

        /**
         * <summary>
         * zeigt die 4 meistverkauften Produkte des IT-Shops und die neusten Kommentare 
         * </summary>
         * 
         * <returns>
         * Index View des Home Controllers
         * </returns>
         */
        public async Task<IActionResult> Index()
        {
            List<ArtikelAnzahlMapping> mapping = new List<ArtikelAnzahlMapping>();

            var ArtikelList = await _context.Artikel.ToListAsync();
            var artikelBestellungen = await _context.ArtikelBestellungen.ToListAsync();
            var artIDs = artikelBestellungen.GroupBy(a => a.Artikel_ID);

            foreach(var id in artIDs)
            {
                int anzahl = artikelBestellungen.Where(a => a.Artikel_ID == id.Key).Sum(a => a.Anzahl);
                Artikel artikel = ArtikelList.Where(a => a.ID == id.Key).First();

                mapping.Add(new ArtikelAnzahlMapping() { Anzahl = anzahl, Artikel = artikel });
            }

            mapping = mapping.OrderByDescending(o => o.Anzahl).ToList();

            foreach(ArtikelAnzahlMapping map in mapping)
            {
                Console.WriteLine("Artikel_ID:  " + map.Artikel.ID);
                Console.WriteLine("Bezeichnung: " + map.Artikel.Bezeichnung);
                Console.WriteLine("Anzahl:      " + map.Anzahl);
                Console.WriteLine();
            }

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
