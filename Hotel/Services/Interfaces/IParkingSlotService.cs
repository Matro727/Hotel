using Hotel.Models.ParkingSlot;

namespace Hotel.Services.Interfaces
{
    public interface IParkingSlotService
    {
        void Add(CreateParkingSlotViewModel parkingSlot);
        IEnumerable<ParkingSlotViewModel> GetAll();

        void Delete(int id);

        void Edit(EditParkingSlotViewModel parkingSlot);

        ParkingSlotViewModel Get(int id);
    }
}
