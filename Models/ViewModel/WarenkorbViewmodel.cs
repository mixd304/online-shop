using it_shop_app.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace it_shop_app.Models
{
    public class WarenkorbViewmodel {
        public List<Warenkorb> Warenkoerbe { get; set; } 
        public SelectList Anzahl { get; set; }

        public decimal gesamtpreis { get; set; }
    }
}
