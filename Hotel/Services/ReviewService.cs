using Hotel.Data.Entities;
using Hotel.Models.Review;
using Hotel.Repositories;
using Hotel.Repositories.Interfaces;
using Hotel.Services.Interfaces;

namespace Hotel.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public void Add(CreateReviewViewModel review)
        {
            var reviewEntity = new Review(review.Comment);

            reviewRepository.Add(reviewEntity);
        }

        public IEnumerable<ReviewViewModel> GetAll()
        {
            var reviewEntities = reviewRepository.GetAll();

            var review = reviewEntities.Select(review => new ReviewViewModel(
                review.Id,
                review.Comment));

            return review;
        }

        public ReviewViewModel Get(int id)
        {
            var review = reviewRepository.Get(id);

            return new ReviewViewModel(review.Id, review.Comment);
        }
        public void Edit(EditReviewViewModel review)
        {
            var reviewEntity = new Review(review.Id, review.Comment);

            reviewRepository.Edit(reviewEntity);
        }

        public void Delete(int id)
                => reviewRepository.Delete(id);
    }
}
