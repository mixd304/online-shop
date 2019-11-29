using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Models {
    public class ListenArtikel {
        public int ID { get; set; }

        public int Artikel_ID { get; set; }
        public Artikel Artikel { get; set; }

        public int Liste_ID { get; set; }
        public Liste Liste { get; set; }
    }
}