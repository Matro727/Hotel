using Hotel.Data;
using Hotel.Data.Entities;
using Hotel.Data.Enums;
using Hotel.Models.User;
using Hotel.Repositories.Interfaces;
using Hotel.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }
        public IEnumerable<UserViewModel> GetAll()
            => userRepository.GetAll();

        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var users = new List<UserViewModel>();

            var userRoles = Enum.GetValues(typeof(UserRoles));
            foreach (var role in userRoles)
            {
                var usersInRoleEntities = await userManager.GetUsersInRoleAsync(role.ToString());
                var usersInRole = usersInRoleEntities
                    .Select(user => new UserViewModel(user.Id, user.Email, user.Name, role.ToString()));

                users.AddRange(usersInRole);
            }

            return users;
        }

    }
}
