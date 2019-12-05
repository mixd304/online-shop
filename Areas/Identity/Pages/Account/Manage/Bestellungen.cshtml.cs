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

namespace it_shop_app.Areas.Identity.Pages.Account.Manage
{
    public class BestellungenModel : PageModel
    {
        private readonly UserManager<IdentityNutzer> _userManager;
        private readonly SignInManager<IdentityNutzer> _signInManager;
        private readonly ShopContext _context;

        public IList<Bestellung> bestellungenList;

        public BestellungenModel(
            UserManager<IdentityNutzer> userManager,
            SignInManager<IdentityNutzer> signInManager,
            ShopContext shopContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = shopContext;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            IdentityNutzer user = await _userManager.GetUserAsync(User);
            
            var bestellungen = from w in _context.Bestellungen
                               select w;

            bestellungen =  bestellungen.Where(bes => bes.Nutzer_ID == user.Id);

            bestellungenList = await bestellungen.ToListAsync();

            return Page();
        }
    }
}
