using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Controllers;
using Hotel.Models.User;
using Hotel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Hotel.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        [Test]
        public async Task IndexAsync_ReturnsAViewResult_WithListOfUsers()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var expectedUsers = new List<UserViewModel>
            {
                new UserViewModel("1", "example1@example.com", "John Doe", "User"),
                new UserViewModel("2", "example2@example.com", "Jane Doe", "Admin")
            };
            mockUserService.Setup(service => service.GetAllAsync()).Returns(Task.FromResult<IEnumerable<UserViewModel>>(expectedUsers));
            var controller = new UserController(mockUserService.Object);

            // Act
            var result = await controller.IndexAsync() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUsers, result.Model);
        }
    }
}
