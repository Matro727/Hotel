using Hotel.Data.Entities;
using Hotel.Data;
using Hotel.Repositories.Interfaces;

namespace Hotel.Repositories
{
    public class TaxiRepository : ITaxiRepository
    {
        private readonly ApplicationContext context;

        public TaxiRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(Taxi taxi)
        {
            context.Taxis.Add(taxi);
            context.SaveChanges();
        }

        public IEnumerable<Taxi> GetAll()
            => context.Taxis.ToList();


        public void Delete(int id)
        {
            var taxi = Get(id);

            context.Taxis.Remove(taxi);
            context.SaveChanges();
        }

        public void Edit(Taxi taxi)
        {
            var entity = Get(taxi.Id);

            entity.Number = taxi.Number;
            entity.Type = taxi.Type;
            entity.Rentability = taxi.Rentability;
            entity.PricePerMinute = taxi.PricePerMinute;

            context.SaveChanges();
        }

        public Taxi Get(int id)
            => context.Taxis.FirstOrDefault(taxi => taxi.Id == id);
    }
}
