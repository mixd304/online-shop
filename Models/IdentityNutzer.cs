using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using it_shop_app.Models;

namespace it_shop_app.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the IdentityNutzer class
    public class IdentityNutzer : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public string Plz { get; set; }
        [PersonalData]
        public string Ort { get; set; }
        [PersonalData]
        public string Strasse { get; set; }
        [PersonalData]
        public string Hausnummer { get; set; }
        [PersonalData]
        public DateTime Geburtsdatum { get; set; }

        public virtual IList<Warenkorb> Warenkorb { get; set; }
        public ICollection<Bestellung> Bestellungen {get; set; }
        public ICollection<Liste> Listen {get; set; }
        public ICollection<Bewertung> Bewertungen { get; set; }
        public ICollection<Kommentar> Kommentare { get; set; }

        public string getAnzeigeName() {
            return this.Name;
        }
    }
}
