using Hotel.Data.Entities;
using Hotel.Data;
using Hotel.Repositories.Interfaces;

namespace Hotel.Repositories
{
    public class ParkingSlotRepository : IParkingSlotRepository
    {
        private readonly ApplicationContext context;

        public ParkingSlotRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(ParkingSlot parkingSlot)
        {
            context.ParkingSlots.Add(parkingSlot);
            context.SaveChanges();
        }

        public IEnumerable<ParkingSlot> GetAll()
            => context.ParkingSlots.ToList();


        public void Delete(int id)
        {
            var parkingSlot = Get(id);

            context.ParkingSlots.Remove(parkingSlot);
            context.SaveChanges();
        }

        public void Edit(ParkingSlot parkingSlot)
        {
            var entity = Get(parkingSlot.Id);

            entity.Number = parkingSlot.Number;
            entity.Type = parkingSlot.Type;
            entity.Rentability = parkingSlot.Rentability;
            entity.PricePerDay = parkingSlot.PricePerDay;

            context.SaveChanges();
        }

        public ParkingSlot Get(int id)
            => context.ParkingSlots.FirstOrDefault(parkingSlot => parkingSlot.Id == id);

    }
}
