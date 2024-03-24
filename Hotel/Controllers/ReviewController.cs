using Hotel.Data.Entities;
using Hotel.Models.Review;
using Hotel.Models.Room;
using Hotel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService ReviewService;

        public ReviewController(IReviewService ReviewService)
        {
            this.ReviewService = ReviewService;
        }

        public IActionResult Index()
        {
            var Reviews = ReviewService.GetAll();

            return View(Reviews);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateReviewViewModel Review)
        {
            ReviewService.Add(Review);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ReviewService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var Review = ReviewService.Get(id);

            return View(Review);
        }

        [HttpPost]

        public IActionResult Edit(EditReviewViewModel Review)
        {
            ReviewService.Edit(Review);

            return RedirectToAction(nameof(Index));
        }
    }
}
