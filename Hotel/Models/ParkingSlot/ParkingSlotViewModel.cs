namespace Hotel.Models.ParkingSlot
{
    public class ParkingSlotViewModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Type { get; set; }

        public string Rentability { get; set; }

        public int PricePerDay { get; set; }

        public ParkingSlotViewModel(int id, int number, string type, string rentability, int pricePerDay)
        {
            Id = id;
            Number = number;
            Type = type;
            Rentability = rentability;
            PricePerDay = pricePerDay;
        }
    }
}
