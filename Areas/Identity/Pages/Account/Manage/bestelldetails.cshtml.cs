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
    public class bestelldetailsModel : PageModel
    {

        private readonly ShopContext _shopContext;

        public int Bestellung_id;

        public bestelldetailsModel(
            ShopContext shopContext
            )
        {
            _shopContext = shopContext;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            this.Bestellung_id = id;
            await _shopContext.Bestellungen.ToListAsync();

            return Page();
        }
    }
}
