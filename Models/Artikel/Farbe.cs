using System.Collections.Generic;

namespace it_shop_app.Models
{
    public class Farbe
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }

        // Verweise auf andere Tabellen
        public ICollection<ArtikelFarben> ArtikelFarben { get; set; }
    }
}