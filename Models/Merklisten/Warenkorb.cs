using it_shop_app.Areas.Identity.Data;
using System.Collections.Generic;

namespace it_shop_app.Models {
    public class Warenkorb {
        public int ID { get; set; }
        public int Anzahl { get; set; }
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }
        public string Nutzer_ID { get; set; }
        public virtual IdentityNutzer Nutzer { get; set; }
        public int? Farbe_ID { get; set; }
        public Farbe Farbe { get; set; }
    }
}