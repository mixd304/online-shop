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
    public class BestellungenModel : PageModel
    {
        private readonly UserManager<IdentityNutzer> _userManager;
        private readonly SignInManager<IdentityNutzer> _signInManager;
        private readonly ShopContext _context;
        private readonly IToastNotification _toastNotification;

        public IList<Bestellung> bestellungenList;

        public BestellungenModel(
            UserManager<IdentityNutzer> userManager,
            SignInManager<IdentityNutzer> signInManager,
            ShopContext shopContext,
            IToastNotification toastNotification
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = shopContext;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            IdentityNutzer user = await _userManager.GetUserAsync(User);
            
            var bestellungen = from w in _context.Bestellungen
                               select w;

            bestellungen =  bestellungen.Where(bes => bes.Nutzer_ID == user.Id);

            bestellungenList = await bestellungen.ToListAsync();

            bestellungenList = bestellungenList.OrderByDescending(b => b.Bestelldatum).ToList();

            return Page();
        }
    }
}
