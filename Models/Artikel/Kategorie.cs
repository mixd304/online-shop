using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Models {
    public class Kategorie {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }

        // Verweise auf andere Tabellen
        public ICollection<Artikel> Artikel { get; set; }
    }
}