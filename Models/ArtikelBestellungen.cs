namespace it_shop_app.Models {
    public class ArtikelBestellungen {
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public int Bestellung_ID { get; set; }
        public Bestellung Bestellung { get; set; }
    }
}