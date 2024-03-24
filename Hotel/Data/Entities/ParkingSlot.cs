using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Entities
{
    public class ParkingSlot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Rentability { get; set; }

        [Required]
        public int PricePerDay { get; set; }

        public ParkingSlot()
        { }

        public ParkingSlot(int number, string type, string rentability, int pricePerDay)
        {
            Number = number;
            Type = type;
            Rentability = rentability;
            PricePerDay = pricePerDay;
        }

        public ParkingSlot(int id, int number, string type, string rentability, int pricePerDay)
            : this(number, type, rentability, pricePerDay)
        {
            Id = id;
        }
    }
}
