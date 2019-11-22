using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace it_shop_app.Controllers
{
    public class Nutzer
    {
        public int Id { get; set; }
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
    }
}