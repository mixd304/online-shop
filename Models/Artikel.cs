namespace it_shop_app.Controllers
{
    public class Artikel
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public string Beschreibung { get; set; }
        public Map<string, string> Merkmale { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preis { get; set; }
    }
}