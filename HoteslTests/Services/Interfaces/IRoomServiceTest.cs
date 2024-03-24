using System.Collections.Generic;
using Hotel.Models.Room;
using Hotel.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace Hotel.Tests.Services.Interfaces
{
    [TestFixture]
    public class IRoomServiceTests
    {
        [Test]
        public void IRoomService_GetAll_ReturnsRoomViewModels()
        {
            
            var roomViewModels = new List<RoomViewModel>
            {
                new RoomViewModel(1, 101, "Single", "Rentable", 50),
                new RoomViewModel(2, 102, "Double", "Rentable", 75)
            };

            var roomServiceMock = new Mock<IRoomService>();
            roomServiceMock.Setup(service => service.GetAll()).Returns(roomViewModels);

            
            var result = roomServiceMock.Object.GetAll();

            
            Assert.AreEqual(roomViewModels.Count, result.Count());
            Assert.IsTrue(result.All(r => roomViewModels.Exists(room => room.Id == r.Id)));
        }

        
    }
}
