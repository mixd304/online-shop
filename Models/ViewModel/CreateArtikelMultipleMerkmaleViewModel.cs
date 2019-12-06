using System.Collections.Generic;

namespace it_shop_app.Models
{
    public class CreateArtikelMultipleMerkmaleViewModel 
    {
        public Artikel artikel { get; set; }
        public List<Merkmal> merkmale { get; set; }
        public List<MerkmalBezeichnung> merkmalBezeichnungen { get; set; }
        public Kategorie kategorie { get; set; }
    }
}