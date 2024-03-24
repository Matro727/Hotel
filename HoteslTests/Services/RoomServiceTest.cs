using Moq;
using Hotel.Data.Entities;
using Hotel.Repositories.Interfaces;
using Hotel.Services;
using Hotel.Models.Room;

namespace rooms_Web.Tests.Services
{
    public class roomServiceTests
    {
        private RoomService roomService;

        private Mock<IRoomRepository> roomRepositoryMock;

        private readonly IEnumerable<Room> roomsInDatabase;

        public roomServiceTests()
        {
            roomsInDatabase = new[]
            {
                new Room(1, 101, "single", "Nottaken", 120),
                new Room(2, 102, "single", "Nottaken", 120),
                new Room(3, 103, "single", "Nottaken", 120)
            };
        }

        [SetUp]
        public void SetUp()
        {
            roomRepositoryMock = SetUproomRepositoryMock();

            roomService = new RoomService(roomRepositoryMock.Object);
        }

        #region Add
        [Test]
        public void GivenValidroom_WhenAddingAroom_TheroomIsAdded()
        {

            var room = new CreateRoomViewModel()
            {
                Number = 1,
                Type = "NotTaken",
                Price = 132
            };
            roomService.Add(room);

            roomRepositoryMock.Verify(
                mock => mock.Add(It.Is<Room>(roomEntity =>
                    roomEntity.Number == room.Number &&
                    roomEntity.Type == room.Type &&
                    roomEntity.Price == room.Price)),
                Times.Once);
        }
        #endregion

        #region GetAll
        [Test]
        public void GivenroomsExist_WhenGettingAllrooms_AllroomsAreReturned()
        {
            var rooms = roomService.GetAll();

            Assert.AreEqual(
                roomsInDatabase.Count(),
                rooms.Count(),
                "rooms count different than expected");

            foreach (var roomInDatabase in roomsInDatabase)
            {
                var roomExists = rooms.Any(room =>
                        room.Id == roomInDatabase.Id &&
                        room.Number == roomInDatabase.Number &&
                        room.Type == roomInDatabase.Type &&
                        room.Price == roomInDatabase.Price);

                Assert.True(
                    roomExists,
                    $"room with Id {roomInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoroomsExist_WhenGettingAllrooms_ReturnsEmptyCollection()
        {
            roomRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<Room>());

            var rooms = roomService.GetAll();

            Assert.AreEqual(0, rooms.Count());
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAroom_ReturnsTheroom()
        {
            var expectedroom = roomsInDatabase.First();

            var room = roomService.Get(expectedroom.Id);

            Assert.AreEqual(expectedroom.Id, room.Id);
            Assert.AreEqual(expectedroom.Number, room.Number);
            Assert.AreEqual(expectedroom.Type, room.Type);
            Assert.AreEqual(expectedroom.Price, room.Price);
        }
        #endregion

        private Mock<IRoomRepository> SetUproomRepositoryMock()
        {
            var roomRepositoryMock = new Mock<IRoomRepository>();

            roomRepositoryMock.Setup(mock => mock.Add(It.IsAny<Room>()));

            roomRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(roomsInDatabase);

            roomRepositoryMock
                .Setup(mock => mock.Get(roomsInDatabase.First().Id))
                .Returns(roomsInDatabase.First());

            return roomRepositoryMock;
        }
    }
}