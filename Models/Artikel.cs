using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace it_shop_app.Models
{
    public class Artikel
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public string Beschreibung { get; set; }  

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preis { get; set; }

        // Verweise auf andere Tabellen
        public ICollection<Merkmal> Merkmale { get; set; }
        public virtual ICollection<Bestellung> Bestellungen { get; set; }
        public virtual ICollection<Warenkorb> Warenkoerbe { get; set; }
    }
}