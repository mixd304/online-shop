namespace it_shop_app.Models {
    public class ListenArtikel {
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public int Liste_ID { get; set; }
        public Liste Liste { get; set; }
    }
}