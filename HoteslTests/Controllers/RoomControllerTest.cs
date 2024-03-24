using System.Collections.Generic;
using Hotel.Controllers;
using Hotel.Models.Room;
using Hotel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Hotel.Tests.Controllers
{
    [TestFixture]
    public class RoomControllerTests
    {
        [Test]
        public void Index_ReturnsAViewResult_WithListOfRooms()
        {
            
            var mockRoomService = new Mock<IRoomService>();
            var expectedRooms = new List<RoomViewModel>
            {
                new RoomViewModel(1, 101, "Single", "High", 100),
                new RoomViewModel(2, 102, "Double", "Low", 150)
            };
            mockRoomService.Setup(service => service.GetAll()).Returns(expectedRooms);
            var controller = new RoomController(mockRoomService.Object);

            
            var result = controller.Index() as ViewResult;

            
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRooms, result.Model);
        }

        
    }
}
