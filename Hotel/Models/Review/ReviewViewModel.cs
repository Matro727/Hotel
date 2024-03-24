namespace Hotel.Models.Review
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public string Comment { get; set; }


        public ReviewViewModel(int id, string comment)
        {
            Id = id;
            Comment = comment;
        }
    }
}
