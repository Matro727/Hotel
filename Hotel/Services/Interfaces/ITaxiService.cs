using Hotel.Models.ParkingSlot;
using Hotel.Models.Taxi;

namespace Hotel.Services.Interfaces
{
    public interface ITaxiService
    {
        void Add(CreateTaxiViewModel taxi);
        IEnumerable<TaxiViewModel> GetAll();

        void Delete(int id);

        void Edit(EditTaxiViewModel taxi);

        TaxiViewModel Get(int id);
    }
}
