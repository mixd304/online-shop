using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using it_shop_app.Areas.Identity.Data;
using it_shop_app.Data;
using it_shop_app.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace it_shop_app.Areas.Identity.Pages.Account.Manage
{
    public class KommentareModel : PageModel
    {
        private readonly UserManager<IdentityNutzer> _userManager;
        private readonly SignInManager<IdentityNutzer> _signInManager;
        private readonly ShopContext _context;

        public KommentareModel(
            UserManager<IdentityNutzer> userManager,
            SignInManager<IdentityNutzer> signInManager,
            ShopContext shopContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = shopContext;
        }

        public IList<Kommentar> Kommentare;

        public async Task<IActionResult> OnGetAsync()
        {
            var UserID = _userManager.GetUserId(User);

            var query = from k in _context.Kommentare
                        select k;

            query = query.Where(k => k.Nutzer_ID == UserID);

            Console.WriteLine("==================TEST=?============");
            Console.WriteLine(UserID);

            Kommentare = await query.ToListAsync();
            await _context.Artikel.ToListAsync();

            return Page();
        }
    }
}
