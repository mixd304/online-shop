using System.ComponentModel.DataAnnotations;

namespace it_shop_app.Models {
    public class Merkmal {
        public int ID { get; set; }
        [Required]
        public string Wert { get; set; }

        // Verweise auf andere Tabellen
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }
        public int Bezeichnung_ID { get; set; }
        public MerkmalBezeichnung Bezeichnung { get; set; }
    }
}