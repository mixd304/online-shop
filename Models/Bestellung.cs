using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace it_shop_app.Models {
    public class Bestellung {
        public int ID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Gesamtpreis { get; set; }

        [DataType(DataType.Date)]
        public DateTime Bestelldatum { get; set; }
        
        // Verweise auf andere Tabellen
        public int Nutzer_ID { get; set; }
        public Nutzer Kaeufer { get; set; }
        
        public IList<ArtikelBestellungen> ArtikelBestellungen { get; set; }

    }
}