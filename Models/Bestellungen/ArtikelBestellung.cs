using System.Collections.Generic;

namespace it_shop_app.Models {
    public class ArtikelBestellung {
        public int ID { get; set; }
        public int Anzahl { get; set; }
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public int Bestellung_ID { get; set; }
        public Bestellung Bestellung { get; set; }
        public int? Farbe_ID { get; set; }
        public Farbe Farbe { get; set; }

    }
}