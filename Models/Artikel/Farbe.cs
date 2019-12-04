using System.Collections.Generic;

namespace it_shop_app.Models
{
    public class Farbe
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }

        // Verweise auf andere Tabellen
        public IList<ArtikelFarben> ArtikelFarben { get; set; }
        public IList<ArtikelBestellungFarbe> ArtikelBestellungFarben { get; set; }
        public IList<WarenkorbFarbe> WarenkorbFarben { get; set; }
    }
}