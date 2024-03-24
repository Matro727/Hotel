using Hotel.Data.Entities;
using Hotel.Models.ParkingSlot;
using Hotel.Repositories.Interfaces;
using Hotel.Services.Interfaces;

namespace Hotel.Services
{
    public class ParkingSlotService : IParkingSlotService
    {
        private readonly IParkingSlotRepository parkingSlotRepository;

        public ParkingSlotService(IParkingSlotRepository parkingSlotRepository)
        {
            this.parkingSlotRepository = parkingSlotRepository;
        }

        public void Add(CreateParkingSlotViewModel parkingSlot)
        {
            var parkingSlotEntity = new ParkingSlot(parkingSlot.Number, parkingSlot.Type, parkingSlot.Rentability, parkingSlot.PricePerDay);

            parkingSlotRepository.Add(parkingSlotEntity);
        }

        public IEnumerable<ParkingSlotViewModel> GetAll()
        {
            var parkingSlotEntities = parkingSlotRepository.GetAll();

            var parkingSlots = parkingSlotEntities.Select(parkingSlot => new ParkingSlotViewModel(
                parkingSlot.Id, 
                parkingSlot.Number, 
                parkingSlot.Type, 
                parkingSlot.Rentability, 
                parkingSlot.PricePerDay));

            return parkingSlots;
        }

        public ParkingSlotViewModel Get(int id)
        {
            var parkingSlot = parkingSlotRepository.Get(id);

            return new ParkingSlotViewModel(parkingSlot.Id, parkingSlot.Number, parkingSlot.Type, parkingSlot.Rentability, parkingSlot.PricePerDay);
        }
        public void Edit(EditParkingSlotViewModel parkingSlot)
        {
            var parkingSlotEntity = new ParkingSlot(parkingSlot.Id, parkingSlot.Number, parkingSlot.Type, parkingSlot.Rentability, parkingSlot.PricePerDay);

            parkingSlotRepository.Edit(parkingSlotEntity);
        }

        public void Delete(int id)
                => parkingSlotRepository.Delete(id);
    }
}
