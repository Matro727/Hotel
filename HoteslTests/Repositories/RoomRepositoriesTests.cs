using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using Hotel.Repositories;
using Hotel.Data.Entities;

namespace Hotel.Repositories
{
    public class RoomRepositoryTests
    {
        private RoomRepository roomRepository;

        private ApplicationContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();

            roomRepository = new RoomRepository(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        #region Add
        [Test]
        public void GivenAroom_WhenAddingAroom_AddsIt()
        {
            var room = new Room(1, 101, "single", "Nottaken", 120);

            roomRepository.Add(room);

            var createdroom = applicationContext.Rooms.LastOrDefault();

            Assert.AreEqual(room, createdroom, "room is different than expected");
        }

        [Test]
        public void GivenNullroom_WhenAddingAroom_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => roomRepository.Add(null));

            Assert.AreEqual(
                "room can't be null!",
                exception.Message,
                "Exception message is different than expexted");
        }
        #endregion

        #region GetAll
        [Test]
        public void WhenGettingAll_ReturnsAllrooms()
        {
            var expectedrooms = Seedrooms();

            var rooms = roomRepository.GetAll();

            Assert.AreEqual(expectedrooms, rooms);
        }
        #endregion

        #region Get
        [Test]
        public void GivenAnExistingId_WhenGettingAroom_ReturnsTheroom()
        {
            var expectedrooms = Seedrooms();
            var expectedroom = expectedrooms.First();

            var room = roomRepository.Get(expectedroom.Id);

            Assert.AreEqual(expectedroom, room, "room is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingAroom_ReturnsTheroom()
        {
            Seedrooms();
            var nonExistingId = -1;

            var room = roomRepository.Get(nonExistingId);

            Assert.Null(room);
        }
        #endregion

        private IEnumerable<Room> Seedrooms()
        {
            var rooms = new[]
            {
                new Room(1, 101, "single", "Nottaken", 120),
                new Room(2, 102,  "single", "Nottaken", 120),
                new Room(3, 103,  "single", "Nottaken", 120)
            };

            applicationContext.Rooms.AddRange(rooms);
            applicationContext.SaveChanges();

            return rooms;
        }

        private ApplicationContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationContext(options.Options);
        }
    }
}