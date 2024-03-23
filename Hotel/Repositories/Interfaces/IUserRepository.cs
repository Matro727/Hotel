using Hotel.Data.Entities;
using Hotel.Models.User;

namespace Hotel.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserViewModel> GetAll();
    }
}
