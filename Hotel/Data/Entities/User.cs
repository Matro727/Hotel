using Microsoft.AspNetCore.Identity;

namespace Hotel.Data.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
