namespace Hotel.Models.ParkingSlot
{
    public class CreateParkingSlotViewModel
    {
        public int Number { get; set; }

        public string Type { get; set; }

        public string Rentability { get; set; }

        public int PricePerDay { get; set; }
    }
}
