using Hotel.Data.Entities;
using Hotel.Models.Taxi;
using Hotel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class TaxiController : Controller
    {
        private readonly ITaxiService taxiService;

        public TaxiController(ITaxiService taxiService)
        {
            this.taxiService = taxiService;
        }

        public IActionResult Index()
        {
            var taxis = taxiService.GetAll();

            return View(taxis);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTaxiViewModel taxi)
        {
            taxiService.Add(taxi);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            taxiService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var taxi = taxiService.Get(id);

            return View(taxi);
        }

        [HttpPost]

        public IActionResult Edit(EditTaxiViewModel taxi)
        {
            taxiService.Edit(taxi);

            return RedirectToAction(nameof(Index));
        }
    }
}
