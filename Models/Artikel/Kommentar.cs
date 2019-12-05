using it_shop_app.Areas.Identity.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace it_shop_app.Models {
    public class Kommentar {
        public int ID { get; set; }
        [Required]
        public string Inhalt { get; set; }
        public int Bewertung { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        // Verweise auf andere Tabellen
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public string Nutzer_ID { get; set; }
        public IdentityNutzer Nutzer { get; set; }
    }
}