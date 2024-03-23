using Hotel.Data.Entities;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace Hotel.Tests.Entities
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_Inherits_IdentityUser()
        {
            
            var user = new User();

            
            Assert.IsInstanceOf<IdentityUser>(user);
        }

        [Test]
        public void User_Name_Property_CanBeSetAndGet()
        {
            
            var user = new User();

            
            user.Name = "John Doe";

          
            Assert.AreEqual("John Doe", user.Name);
        }
    }
}
