using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace it_shop_app.Models
{
    public class Artikel
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public string Beschreibung { get; set; }
        public Dictionary<string, string> Merkmale { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preis { get; set; }
    }
}