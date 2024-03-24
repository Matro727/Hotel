using System.Collections.Generic;
using System.Linq;
using Hotel.Data.Entities;
using Hotel.Models.Room;
using Hotel.Repositories.Interfaces;
using Hotel.Services;
using Moq;
using NUnit.Framework;

namespace Hotel.Tests.Services
{
    [TestFixture]
    public class RoomServiceTests
    {
        [Test]
        public void RoomService_GetAll_ReturnsRoomViewModels()
        {
            // Arrange
            var roomEntities = new List<Room>
            {
                new Room { Id = 1, Number = 101, Type = "Single", Rentability = "Rentable", Price = 50 },
                new Room { Id = 2, Number = 102, Type = "Double", Rentability = "Rentable", Price = 75 }
            };

            var roomViewModels = roomEntities.Select(room => new RoomViewModel(room.Id, room.Number, room.Type, room.Rentability, room.Price));

            var roomRepositoryMock = new Mock<IRoomRepository>();
            roomRepositoryMock.Setup(repo => repo.GetAll()).Returns(roomEntities);

            var roomService = new RoomService(roomRepositoryMock.Object);

            // Act
            var result = roomService.GetAll();

            // Assert
            Assert.AreEqual(roomViewModels.Count(), result.Count());
            Assert.IsTrue(result.All(r => roomViewModels.Any(viewModel => viewModel.Id == r.Id)));
        }

        // Similar tests can be written for other methods such as Add, Delete, Edit, and Get.
    }
}
