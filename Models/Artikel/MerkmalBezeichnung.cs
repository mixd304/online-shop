using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace it_shop_app.Models
{
    public class MerkmalBezeichnung
    {
        public int ID { get; set; }

        [Required]
        public string Bezeichnung { get; set; }
           
        // Verweise auf andere Tabellen
        public ICollection<Merkmal> Merkmale { get; set; }
    }
}
