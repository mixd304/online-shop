using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace it_shop_app.Models
{
    public class Nutzer
    {
        public int ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Postleitzahl")]
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string Straße { get; set; }
        public int Hausnummer { get; set; }

        [DataType(DataType.Date)]
        public DateTime Geburtsdatum { get; set; }
        
        // Verweise auf andere Tabellen
        public virtual ICollection<Bestellung> Bestellungen {get; set; }
        public Warenkorb Warenkorb { get; set; }
        public virtual ICollection<Liste> Listen {get; set; }
    }
}