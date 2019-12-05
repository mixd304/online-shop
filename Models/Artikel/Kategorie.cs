using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace it_shop_app.Models {
    public class Kategorie {
        public int ID { get; set; }
        [Required]
        public string Bezeichnung { get; set; }

        // Verweise auf andere Tabellen
        public ICollection<Artikel> Artikel { get; set; }
    }
}