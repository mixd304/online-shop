namespace it_shop_app.Models {
    public class WarenkorbArtikel {
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public int Warenkorb_ID { get; set; }
        public Warenkorb Warenkorb { get; set; }
    }
}