using System.Collections.Generic;

namespace it_shop_app.Models {
    public class ArtikelBestellung {
        public int ID_ArtikelBestellung { get; set; }
        public int Anzahl { get; set; }
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public int Bestellung_ID { get; set; }
        public Bestellung Bestellung { get; set; }

        public IList<ArtikelBestellungFarbe> ArtikelBestellungFarben { get; set; }
    }
}