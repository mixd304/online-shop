using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Models {
    public class Artikel {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public string Beschreibung { get; set; }  

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preis { get; set; }

        // Verweise auf andere Tabellen
        public ICollection<Merkmal> Merkmale { get; set; }
        public IList<ArtikelBestellungen> ArtikelBestellungen { get; set; }
        public IList<Warenkorb> Warenkorb { get; set; }
        public IList<ListenArtikel> ListenArtikel { get; set; }
    }
}