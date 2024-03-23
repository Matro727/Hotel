using Hotel.Models.User;

namespace Hotel.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAll();

        Task<IEnumerable<UserViewModel>> GetAllAsync();

    }
}
