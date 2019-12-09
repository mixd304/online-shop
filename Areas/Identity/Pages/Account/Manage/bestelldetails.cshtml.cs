using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using it_shop_app.Areas.Identity.Data;
using it_shop_app.Data;
using it_shop_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace it_shop_app.Areas.Identity.Pages.Account.Manage
{
    public class bestelldetailsModel : PageModel
    {

        private readonly ShopContext _shopContext;
        private readonly IToastNotification _toastNotification;

        public int Bestellung_id;
        public Bestellung bestellung;
        public List<ArtikelBestellung> artikelBestellung;

        public bestelldetailsModel(
            ShopContext shopContext,
            IToastNotification toastNotification
            )
        {
            _shopContext = shopContext;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            this.Bestellung_id = id;

            var bestellungQuery = from bes in _shopContext.Bestellungen
                        select bes;
            bestellungQuery = bestellungQuery.Where(b => b.ID == Bestellung_id);

            bestellung = bestellungQuery.FirstOrDefault();

            var artikelQuery = from art in _shopContext.ArtikelBestellungen
                               select art;
            await _shopContext.Artikel.ToListAsync();
            artikelQuery = artikelQuery.Where(art => art.Bestellung_ID == Bestellung_id);

            artikelBestellung = await artikelQuery.ToListAsync();

            return Page();
        }
    }
}
