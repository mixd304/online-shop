using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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

        public string getAnzeigeName() {
            return this.Name;
        }
    }
}
