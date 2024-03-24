using Hotel.Data.Entities;
using Hotel.Models.Review;
using Hotel.Models.Room;
using Hotel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public IActionResult Index()
        {
            var reviews = reviewService.GetAll();

            return View(reviews);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateReviewViewModel review)
        {
            reviewService.Add(review);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            reviewService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var review = reviewService.Get(id);

            return View(review);
        }

        [HttpPost]

        public IActionResult Edit(EditReviewViewModel review)
        {
            reviewService.Edit(review);

            return RedirectToAction(nameof(Index));
        }
    }
}
