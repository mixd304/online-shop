using it_shop_app.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace it_shop_app.Models
{
    public class WarenkorbViewmodel {
        public Warenkorb Warenkorb { get; set; } 
        public SelectList Anzahl { get; set; }
    }
}
