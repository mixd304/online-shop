using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace it_shop_app.Models
{
    public class Warenkorb
    {
        public int ID { get; set; }

        // Verweise auf andere Tabellen
        public Nutzer Nutzer { get; set; }
        public virtual ICollection<Artikel> Artikel { get; set; }
    }
}