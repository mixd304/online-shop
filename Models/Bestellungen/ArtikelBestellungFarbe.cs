using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace it_shop_app.Models
{
    public class ArtikelBestellungFarbe
    {
        public int Farbe_ID { get; set; }
        public Farbe Farbe { get; set; }
        public int ArtikelBestellung_ID { get; set; }
        public ArtikelBestellung ArtikelBestellung { get; set; }
    }
}
