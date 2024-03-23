using System.Collections.Generic;
using Hotel.Models.User;
using Hotel.Repositories.Interfaces;
using Moq;
using NUnit.Framework;

namespace Hotel.Tests.Repositories.Interfaces
{
    [TestFixture]
    public class IUserRepositoryTests
    {
        [Test]
        public void IUserRepository_GetAll_ReturnsUserViewModels()
        {
            // Arrange
            var userViewModels = new List<UserViewModel>
            {
                new UserViewModel("1", "user1@example.com", "User1", "Admin"),
                new UserViewModel("2", "user2@example.com", "User2", "User")
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetAll()).Returns(userViewModels);

            // Act
            var result = userRepositoryMock.Object.GetAll();

            // Assert
            Assert.AreEqual(userViewModels, result);
        }
    }
}
