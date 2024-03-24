using Hotel.Data.Entities;
using Hotel.Data;
using Hotel.Repositories.Interfaces;

namespace Hotel.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationContext context;

        public ReviewRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
        }

        public IEnumerable<Review> GetAll()
            => context.Reviews.ToList();


        public void Delete(int id)
        {
            var review = Get(id);

            context.Reviews.Remove(review);
            context.SaveChanges();
        }

        public void Edit(Review review)
        {
            var entity = Get(review.Id);

            entity.Comment = review.Comment;

            context.SaveChanges();
        }

        public Review Get(int id)
            => context.Reviews.FirstOrDefault(review => review.Id == id);

    }
}
