using Hotel.Data.Entities;
using Hotel.Data.Enums;
using Hotel.Models.User;
using Hotel.Repositories.Interfaces;
using Hotel.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void GetAll_ReturnsUserViewModels_WhenUsersExist()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetAll())
                .Returns(new List<UserViewModel>
                {
                    new UserViewModel("1", "user1@example.com", "User 1", "Role1"),
                    new UserViewModel("2", "user2@example.com", "User 2", "Role2")
                });

            var userManagerMock = MockUserManagerFactory.CreateMockUserManager();

            var userService = new UserService(userRepositoryMock.Object, userManagerMock.Object);

            // Act
            var result = userService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());

            // Check the first user
            var user1ViewModel = result.ElementAt(0);
            Assert.AreEqual("1", user1ViewModel.Id);
            Assert.AreEqual("user1@example.com", user1ViewModel.Email);
            Assert.AreEqual("User 1", user1ViewModel.Name);
            Assert.AreEqual("Role1", user1ViewModel.Role);

            // Check the second user
            var user2ViewModel = result.ElementAt(1);
            Assert.AreEqual("2", user2ViewModel.Id);
            Assert.AreEqual("user2@example.com", user2ViewModel.Email);
            Assert.AreEqual("User 2", user2ViewModel.Name);
            Assert.AreEqual("Role2", user2ViewModel.Role);
        }

     
        }
    }

    public static class MockUserManagerFactory
    {
        public static Mock<UserManager<User>> CreateMockUserManager()
        {
            var users = new List<User>
            {
                new User { Id = "1", Email = "user1@example.com", Name = "User 1" },
                new User { Id = "2", Email = "user2@example.com", Name = "User 2" },
                new User { Id = "3", Email = "user3@example.com", Name = "User 3" }
            };

            var roles = new List<string> { "Role1", "Role2", "Role3" };

            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            userManagerMock.Setup(um => um.GetUsersInRoleAsync(It.IsAny<string>()))
                .ReturnsAsync((string role) =>
                {
                    return users.Where(u => u.Id == role).ToList();
                });

            userManagerMock.Setup(um => um.GetRolesAsync(It.IsAny<User>()))
                .ReturnsAsync((User user) =>
                {
                    return roles.Where(r => r == user.Id).ToList();
                });

            return userManagerMock;
        }
    }

