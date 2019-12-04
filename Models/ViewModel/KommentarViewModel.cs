using Microsoft.AspNetCore.Mvc.Rendering;

namespace it_shop_app.Models
{
    public class KommentarViewModel {
        public Kommentar kommentar { get; set; } 
        public SelectList bewertung { get; set; }
    }
}
