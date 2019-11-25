using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace it_shop_app.Models
{
    public class Bestellung
    {
        public int ID { get; set; }
        public Artikel[] Artikels { get; set; }
        public Nutzer kaeufer { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Gesamtpreis { get; set; }

        [DataType(DataType.Date)]
        public DateTime Bestelldatum { get; set; }
    }
}