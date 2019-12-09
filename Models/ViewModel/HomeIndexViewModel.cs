using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace it_shop_app.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ArtikelAnzahlMapping> mapping { get; set; }
        public List<ArtikelCommentHomeModel> ACMapping { get; set; }
    }
}
