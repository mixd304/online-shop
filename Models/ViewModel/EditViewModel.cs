using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace it_shop_app.Models
{
    public class EditViewModel
    {
        public Artikel artikel { get; set; }
        public List<ArtikelFarben> farben { get; set; }
        public List<Merkmal> merkmale { get; set; }
    }
}
