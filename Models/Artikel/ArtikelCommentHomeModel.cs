using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace it_shop_app.Models
{
    public class ArtikelCommentHomeModel
    {
        public Artikel Artikel { get; set; }
        public List<Kommentar> kommentare { get; set; }
    }
}
