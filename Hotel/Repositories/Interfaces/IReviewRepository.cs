using Hotel.Data.Entities;

namespace Hotel.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        void Add(Review review);

        IEnumerable<Review> GetAll();

        void Delete(int id);

        void Edit(Review review);

        Review Get(int id);
    }
}
