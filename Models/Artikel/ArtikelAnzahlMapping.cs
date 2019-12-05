using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace it_shop_app.Models
{
    public class ArtikelAnzahlMapping
    {
        public int anzahl { get; set; }
        public int artikelID { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
