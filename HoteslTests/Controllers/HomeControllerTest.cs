using Hotel.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Hotel.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
