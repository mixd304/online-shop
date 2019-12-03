using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace it_shop_app.Models
{
    public class ArtikelIndexViewModel
    {
        public List<Artikel> artikel;
        public SelectList kategorien;
        public string selectedKategorie;
        public string searchString;
    }
}
