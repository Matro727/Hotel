using Hotel.Data.Entities;

namespace Hotel.Repositories.Interfaces
{
    public interface ITaxiRepository
    {
        void Add(Taxi taxi);

        IEnumerable<Taxi> GetAll();

        void Delete(int id);

        void Edit(Taxi taxi);

        Taxi Get(int id);
    }
}
