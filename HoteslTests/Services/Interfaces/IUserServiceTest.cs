using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models.User;
using Hotel.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace Hotel.Tests.Services.Interfaces
{
    [TestFixture]
    public class IUserServiceTests
    {
        [Test]
        public async Task IUserService_GetAllAsync_ReturnsUserViewModels()
        {
            // Arrange
            var userViewModels = new List<UserViewModel>
            {
                new UserViewModel("1", "user1@example.com", "User1", "Admin"),
                new UserViewModel("2", "user2@example.com", "User2", "User")
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(userViewModels);

            // Act
            var result = await userServiceMock.Object.GetAllAsync();

            // Assert
            Assert.AreEqual(userViewModels.Count, result.Count());
            Assert.IsTrue(result.All(u => userViewModels.Exists(user => user.Id == u.Id)));
        }

        
    }
}
