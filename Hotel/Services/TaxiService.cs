using Hotel.Data.Entities;
using Hotel.Models.ParkingSlot;
using Hotel.Models.Taxi;
using Hotel.Repositories.Interfaces;
using Hotel.Services.Interfaces;

namespace Hotel.Services
{
    public class TaxiService : ITaxiService
    {
        private readonly ITaxiRepository taxiRepository;

        public TaxiService(ITaxiRepository taxiRepository)
        {
            this.taxiRepository = taxiRepository;
        }

        public void Add(CreateTaxiViewModel taxi)
        {
            var taxiEntity = new Taxi(taxi.Number, taxi.Type, taxi.Rentability, taxi.PricePerMinute);

            taxiRepository.Add(taxiEntity);
        }

        public IEnumerable<TaxiViewModel> GetAll()
        {
            var taxiEntities = taxiRepository.GetAll();

            var taxis = taxiEntities.Select(taxi => new TaxiViewModel(
                taxi.Id,
                taxi.Number,
                taxi.Type,
                taxi.Rentability,
                taxi.PricePerMinute));

            return taxis;
        }

        public TaxiViewModel Get(int id)
        {
            var taxi = taxiRepository.Get(id);

            return new TaxiViewModel(taxi.Id, taxi.Number, taxi.Type, taxi.Rentability, taxi.PricePerMinute);
        }
        public void Edit(EditTaxiViewModel taxi)
        {
            var taxiEntity = new Taxi(taxi.Id, taxi.Number, taxi.Type, taxi.Rentability, taxi.PricePerMinute);

            taxiRepository.Edit(taxiEntity);
        }

        public void Delete(int id)
                => taxiRepository.Delete(id);
    }
}
