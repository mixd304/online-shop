namespace it_shop_app.Models {
    public class Warenkorb {
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public int Nutzer_ID { get; set; }
        public Nutzer Nutzer { get; set; }
    }
}