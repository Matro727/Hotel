using Hotel.Data;
using Hotel.Data.Entities;
using Hotel.Models.User;
using Hotel.Repositories.Interfaces;

namespace Hotel.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationContext dbContext;

        public UserRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<UserViewModel> GetAll()
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            => dbContext.Users
                .ToList()
                .Select(userEntity =>
            {
                var userRole = dbContext.UserRoles
                    .FirstOrDefault(userRoleEntity => userRoleEntity.UserId == userEntity.Id);
                if (userRole is null)
                {
                    return null;
                }
                var role = dbContext.Roles
                    .FirstOrDefault(roleEntity => roleEntity.Id == userRole.RoleId);
                return new UserViewModel(
                    userEntity.Id, 
                    userEntity.Email, 
                    userEntity.Name, 
                    role.Name);
            })
                .Where(user => user!= null);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }
}
