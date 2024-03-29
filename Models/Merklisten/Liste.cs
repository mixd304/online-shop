using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Models {
    public class Liste {
        public int ID { get; set; }
        [Required]
        public string bezeichnung { get; set; }

        // Fremdschlüssel
        public string Nutzer_ID {get; set; }
        public IdentityNutzer Nutzer { get; set; }

        public IList<ListenArtikel> ListenArtikel { get; set; }
    }
}