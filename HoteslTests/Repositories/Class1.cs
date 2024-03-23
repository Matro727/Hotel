using NUnit.Framework;
using Hotel.Data.Entities;
using Hotel.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Repositories.Tests
{
    [TestFixture]
    public class RoomRepositoryTests
    {
        private Mock<IRoomRepository> mockRoomRepository;

        [SetUp]
        public void Setup()
        {
            // Arrange
            mockRoomRepository = new Mock<IRoomRepository>();
        }

        [Test]
        public void GetAll_ReturnsAllRooms()
        {
            // Arrange
            var rooms = new List<Room>
            {
                new Room { Id = 1, Number = 101, Type = "Single", Rentability = "taken", Price = 50 },
                new Room { Id = 2, Number = 102, Type = "Double", Rentability = "taken", Price = 100 }
            };
            mockRoomRepository.Setup(repo => repo.GetAll()).Returns(rooms);

            // Act
            var result = mockRoomRepository.Object.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(rooms[0], result.ElementAt(0));
            Assert.AreEqual(rooms[1], result.ElementAt(1));
        }

        [Test]
        public void Get_ValidId_ReturnsRoom()
        {
            // Arrange
            var roomToReturn = new Room { Id = 1, Number = 101, Type = "Single", Rentability = "taken", Price = 50 };
            mockRoomRepository.Setup(repo => repo.Get(1)).Returns(roomToReturn);

            // Act
            var result = mockRoomRepository.Object.Get(1);

            // Assert
            Assert.AreEqual(roomToReturn, result);
        }


    }
}