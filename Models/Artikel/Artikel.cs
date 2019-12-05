using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace it_shop_app.Models {
    public class Artikel {
        public int ID { get; set; }
        [Required]
        public string Bezeichnung { get; set; }
        public string Beschreibung { get; set; }  
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preis { get; set; }

        // Verweise auf andere Tabellen
        public ICollection<Merkmal> Merkmale { get; set; }
        public IList<ArtikelFarben> ArtikelFarben { get; set; }
        public IList<ArtikelBestellung> ArtikelBestellungen { get; set; }
        public IList<Warenkorb> Warenkorb { get; set; }
        public IList<ListenArtikel> ListenArtikel { get; set; }
        public ICollection<Kommentar> Kommentare { get; set; }
        public int Kategorie_ID { get; set; }
        public Kategorie Kategorie { get; set; }

    }
}