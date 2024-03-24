using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Entities
{
    public class Taxi
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
        public int PricePerMinute { get; set; }

        public Taxi()
        { }

        public Taxi(int number, string type, string rentability, int pricePerMinute)
        {
            Number = number;
            Type = type;
            Rentability = rentability;
            PricePerMinute = pricePerMinute;
        }

        public Taxi(int id, int number, string type, string rentability, int pricePerMinute)
            : this(number, type, rentability, pricePerMinute)
        {
            Id = id;
        }
    }
}
