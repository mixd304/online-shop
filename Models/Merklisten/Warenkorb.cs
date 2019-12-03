using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Models {
    public class Warenkorb {
        public int ID { get; set; }

        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public string Nutzer_ID { get; set; }
        public virtual IdentityNutzer Nutzer { get; set; }
    }
}