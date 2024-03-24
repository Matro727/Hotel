using System.ComponentModel.DataAnnotations;

namespace Hotel.Data.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }

        public Review()
        { }

        public Review(string comment)
        {

            Comment = comment;

        }

        public Review(int id, string comment)
            : this(comment)
        {
            Id = id;
        }
    }
}
