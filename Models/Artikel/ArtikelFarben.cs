namespace it_shop_app.Models
{
    public class ArtikelFarben
    {        
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public int Farbe_ID { get; set; }
        public Farbe Farbe { get; set; }
    }
}