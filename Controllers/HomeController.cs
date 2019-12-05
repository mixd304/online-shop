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
            List<ArtikelBestellung> artikelBestellung = new List<ArtikelBestellung>();
            List<ArtikelAnzahlMapping> mapping = new List<ArtikelAnzahlMapping>();

            await _context.Artikel.ToListAsync();
            artikelBestellung = await _context.ArtikelBestellungen.ToListAsync();

            bool alreadyInList = false;

            Console.WriteLine("==================Startseite Test=================");

            foreach (ArtikelBestellung model in artikelBestellung)
            {
                foreach(ArtikelAnzahlMapping map in mapping)
                {
                    if(map.artikelID == model.Artikel_ID)
                    {
                        map.anzahl = map.anzahl + (model.Anzahl);
                        alreadyInList = true;
                        break;
                    } 
                }

                if (alreadyInList)
                {
                    alreadyInList = false;
                    continue;
                }
                mapping.Add(new ArtikelAnzahlMapping() { anzahl = model.Anzahl, artikelID = model.Artikel_ID });
            }

            mapping = mapping.OrderByDescending(o => o.anzahl).ToList();

            foreach(ArtikelAnzahlMapping map in mapping)
            {
                Console.WriteLine("Artikel_ID: " + map.artikelID);
                Console.WriteLine("Anzahl:     " + map.anzahl);
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
