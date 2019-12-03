using System.Collections.Generic;

namespace it_shop_app.Models {
    public class Kategorie {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }

        // Verweise auf andere Tabellen
        public ICollection<Artikel> Artikel { get; set; }
    }
}