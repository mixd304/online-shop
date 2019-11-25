using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace it_shop_app.Models
{
    public class Liste
    {
        public int ID { get; set; }

        // Fremdschlüssel
        public Nutzer Nutzer { get; set; }
        public virtual ICollection<Artikel> Artikel { get; set; }
    }
}