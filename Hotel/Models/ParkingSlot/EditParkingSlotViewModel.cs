namespace Hotel.Models.ParkingSlot
{
    public class EditParkingSlotViewModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Type { get; set; }

        public string Rentability { get; set; }

        public int PricePerDay { get; set; }
    }
}
