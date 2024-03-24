using Hotel.Data.Entities;

namespace Hotel.Repositories.Interfaces
{
    public interface IParkingSlotRepository
    {
        void Add(ParkingSlot parkingSlot);

        IEnumerable<ParkingSlot> GetAll();

        void Delete(int id);

        void Edit(ParkingSlot parkingSlot);

        ParkingSlot Get(int id);
    }
}
