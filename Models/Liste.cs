using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace it_shop_app.Models {
    public class Liste {
        public int ID { get; set; }
        public string bezeichnung { get; set; }

        // Fremdschlüssel
        public int Nutzer_ID {get; set; }
        public Nutzer Nutzer { get; set; }

        public IList<ListenArtikel> ListenArtikel { get; set; }
    }
}