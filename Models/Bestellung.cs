namespace it_shop_app.Controllers
{
    public class Bestellung
    {
        public int Id { get; set; }
        public Artikel[] Artikels { get; set; }
        public Kunde kaeufer { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Gesamtpreis { get; set; }

        [DataType(DataType.Date)]
        public Date Bestelldatum { get; set; }
    }
}