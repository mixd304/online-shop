using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using it_shop_app.Data;
using it_shop_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace it_shop_app.Areas.Identity.Pages.Account.Manage
{
    public class stornoModel : PageModel
    {

        private readonly ShopContext _shopContext;
        private readonly IToastNotification _toastNotification;

        public int Bestellung_id;

        public stornoModel (ShopContext con, IToastNotification toastNotification)
        {
            _shopContext = con;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var bestQuery = from w in _shopContext.Bestellungen
                            select w;

            bestQuery = bestQuery.Where(b => b.ID == id);

            Bestellung bes = bestQuery.FirstOrDefault();

            bes.Status = Stati.Storniert;

            _shopContext.Update<Bestellung>(bes);
            await _shopContext.SaveChangesAsync();
            _toastNotification.AddSuccessToastMessage("Bestellung " + id + " erfolgreich storniert!");

            return RedirectToPage("./Bestellungen");
        }
    }
}
