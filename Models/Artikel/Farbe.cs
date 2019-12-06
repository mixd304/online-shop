using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace it_shop_app.Models
{
    public class Farbe
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }

        // Verweise auf andere Tabellen
        public IList<ArtikelFarben> ArtikelFarben { get; set; }
        public IList<ArtikelBestellung> ArtikelBestellungen { get; set; }
        public IList<Warenkorb> Warenkoerbe { get; set; }
    }
}