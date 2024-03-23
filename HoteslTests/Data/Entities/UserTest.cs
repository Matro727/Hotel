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
            // Arrange
            var user = new User();

            // Assert
            Assert.IsInstanceOf<IdentityUser>(user);
        }

        [Test]
        public void User_Name_Property_CanBeSetAndGet()
        {
            // Arrange
            var user = new User();

            // Act
            user.Name = "John Doe";

            // Assert
            Assert.AreEqual("John Doe", user.Name);
        }
    }
}
