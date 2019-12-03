using System.Collections.Generic;

namespace it_shop_app.Models 
{
    public class WarenkorbViewModel 
    {
        public List<Warenkorb> Waren { get; set; }
        public int gesamtPreis { get; set; }
    }
}