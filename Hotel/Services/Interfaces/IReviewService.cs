using Hotel.Models.Review;

namespace Hotel.Services.Interfaces
{
    public interface IReviewService
    {
        void Add(CreateReviewViewModel review);
        IEnumerable<ReviewViewModel> GetAll();

        void Delete(int id);

        void Edit(EditReviewViewModel review);

        ReviewViewModel Get(int id);
    }
}
