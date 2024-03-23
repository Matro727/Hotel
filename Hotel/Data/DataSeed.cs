using Hotel.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Hotel.Data
{
    public static class DataSeed
    {
        public static void SeedUserRoles(WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationContext>();
            var roleStore = new RoleStore<IdentityRole>(dbContext);

            var roles = Enum.GetValues(typeof(UserRoles));
            foreach (var role in roles)
            {
                var roleName = role.ToString();

                var roleExists = dbContext.Roles.Any(roleEntity => roleEntity.Name == roleName);

                if (!roleExists)
                {
                    var identityRole = new IdentityRole(roleName)
                    {
                        NormalizedName = roleName.ToUpper()
                    };
                    dbContext.Roles.Add(identityRole);
                }
            }

            dbContext.SaveChanges();
        }
    }
}
