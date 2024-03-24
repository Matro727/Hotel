namespace Hotel.Models.Taxi
{
    public class TaxiViewModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Type { get; set; }

        public string Rentability { get; set; }

        public int PricePerMinute { get; set; }

        public TaxiViewModel(int id, int number, string type, string rentability, int pricePerMinute)
        {
            Id = id;
            Number = number;
            Type = type;
            Rentability = rentability;
            PricePerMinute = pricePerMinute;
        }
    }
}
