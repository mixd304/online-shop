using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Models {
    public class Bewertung {
        public int ID { get; set; }
        public int Wert { get; set; }

        // Verweise auf andere Tabellen
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public string Nutzer_ID { get; set; }
        public IdentityNutzer Nutzer { get; set; }
    }
}