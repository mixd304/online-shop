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
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                mapping = await getMostBuyed(),
                ACMapping = await getNewestComments()

            };

            return View(model);
        }

        private async Task<List<ArtikelAnzahlMapping>> getMostBuyed() 
        {
            List<ArtikelAnzahlMapping> mapping = new List<ArtikelAnzahlMapping>();
            int anz = 4;

            var ArtikelList = await _context.Artikel.ToListAsync();
            var artikelBestellungen = await _context.ArtikelBestellungen.ToListAsync();
            var artIDs = artikelBestellungen.GroupBy(a => a.Artikel_ID);

            foreach (var id in artIDs)
            {
                int anzahl = artikelBestellungen.Where(a => a.Artikel_ID == id.Key).Sum(a => a.Anzahl);
                Artikel artikel = ArtikelList.Where(a => a.ID == id.Key).First();

                mapping.Add(new ArtikelAnzahlMapping() { Anzahl = anzahl, Artikel = artikel });
            }

            mapping = mapping.OrderByDescending(o => o.Anzahl).ToList();

            foreach (ArtikelAnzahlMapping map in mapping)
            {
                Console.WriteLine("Artikel_ID:  " + map.Artikel.ID);
                Console.WriteLine("Bezeichnung: " + map.Artikel.Bezeichnung);
                Console.WriteLine("Anzahl:      " + map.Anzahl);
                Console.WriteLine();
            }

            if (mapping.Count < anz) anz = mapping.Count;

            List<ArtikelAnzahlMapping> firstFour = new List<ArtikelAnzahlMapping>();
            
            for(int i = 0; i < anz; i++)
            {
                firstFour.Add(mapping[i]);
            }

            return firstFour;
        }

        private async Task<List<ArtikelCommentHomeModel>> getNewestComments()
        {

            int anzahl = 6;

            await _context.Artikel.ToListAsync();
            await _context.Nutzer.ToListAsync();
            var kommentare = await _context.Kommentare.ToListAsync();

            kommentare = kommentare.OrderByDescending(d => d.Datum).ToList();

            foreach (Kommentar kom in kommentare)
            {
                Console.WriteLine("Artikel_ID:  " + kom.Artikel.ID);
                Console.WriteLine("Bezeichnung: " + kom.Artikel.Bezeichnung);
                Console.WriteLine("Inhalt:      " + kom.Inhalt);
                Console.WriteLine("Nutzer:      " + kom.Nutzer.UserName);
                Console.WriteLine("Datum:       " + kom.Datum);
                Console.WriteLine();
            }

            if (kommentare.Count < anzahl) anzahl = kommentare.Count;

            List<Kommentar> newest = new List<Kommentar>();

            for (int i = 0; i < anzahl; i++)
            {
                newest.Add(kommentare[i]);
            }

            List<ArtikelCommentHomeModel> achm = new List<ArtikelCommentHomeModel>();
            Boolean alreadyInList = false;

            foreach(Kommentar kom in newest)
            {
                foreach(var model in achm)
                {
                    if(model.Artikel.ID == kom.Artikel.ID)
                    {
                        model.kommentare.Add(kom);
                        alreadyInList = true;
                        break;
                    }
                }

                if(alreadyInList) { alreadyInList = false; continue; } 
                else 
                {

                    ArtikelCommentHomeModel _new = new ArtikelCommentHomeModel()
                    {
                        Artikel = kom.Artikel,
                        kommentare = new List<Kommentar>()
                    };

                    _new.kommentare.Add(kom);

                    achm.Add(_new);
                }

            }


            return achm;
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
