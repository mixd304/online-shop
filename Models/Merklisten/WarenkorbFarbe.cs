namespace it_shop_app.Models
{
    public class WarenkorbFarbe
    {
        public int Warenkorb_ID { get; set; }
        public Warenkorb Warenkorb { get; set; }

        public int Farbe_ID { get; set; }
        public Farbe Farbe { get; set; }
    }
}
