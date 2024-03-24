using Hotel.Data.Entities;
using Hotel.Models.ParkingSlot;
using Hotel.Models.Room;
using Hotel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class ParkingSlotController : Controller
    {
        private readonly IParkingSlotService parkingSlotService;

        public ParkingSlotController(IParkingSlotService parkingSlotService)
        {
            this.parkingSlotService = parkingSlotService;
        }

        public IActionResult Index()
        {
            var parkingSlots = parkingSlotService.GetAll();

            return View(parkingSlots);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateParkingSlotViewModel parkingSlot)
        {
            parkingSlotService.Add(parkingSlot);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            parkingSlotService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var parkingSlot = parkingSlotService.Get(id);

            return View(parkingSlot);
        }

        [HttpPost]

        public IActionResult Edit(EditParkingSlotViewModel parkingSlot)
        {
            parkingSlotService.Edit(parkingSlot);

            return RedirectToAction(nameof(Index));
        }
    }
}
