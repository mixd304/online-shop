using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace it_shop_app.Models {
    public class Merkmal {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public string Wert { get; set; }

        // Verweise auf andere Tabellen
        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }
    }
}