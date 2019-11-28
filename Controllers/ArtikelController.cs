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

        public async Task<IActionResult> Index(string searchString)
        {
            var artikel = from m in _context.Artikel
                          select m;

            if (!String.IsNullOrEmpty(searchString)) {
                artikel = artikel.Where(s => s.Bezeichnung.Contains(searchString));
            }

            await _context.Merkmale.ToListAsync();
            return View(await artikel.ToListAsync());
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

        public IActionResult Warenkorb()
        {
            return View();
        }

        public async Task<IActionResult> addToCart(int? id) {

            /*
                @TODO:Wenn nimand angemeldet ist abweisen 
            */
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
                var warEntry = await _context.Warenkoerbe.FirstAsync(w => w.Artikel_ID == artikel.ID);
            } catch {

                IdentityNutzer user = await _UserManager.GetUserAsync(User);

                Warenkorb wkModel = new Warenkorb();
                wkModel.Artikel_ID = artikel.ID;
                wkModel.Nutzer_ID = user.Id;
                wkModel.ID = 1;

                Console.WriteLine("==============Ausgabe====================");
                Console.WriteLine("WK Eintrag: " + wkModel.Artikel_ID + " / " +  wkModel.Nutzer_ID);

                _context.Add(wkModel);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Artikel erfolgreich Hinzugefügt");
                return RedirectToAction("Index");
            }
            _toastNotification.AddInfoToastMessage("Artikel bereits hinzugefügt");
            return RedirectToAction("Index");
        }
    }
}
