using Hotel.Models.Room;
using NUnit.Framework;

namespace Hotel.Tests.Models.Room
{
    [TestFixture]
    public class CreateRoomViewModelTests
    {
        [Test]
        public void CreateRoomViewModel_Properties_CanBeSetAndGet()
        {
            // Arrange
            var viewModel = new CreateRoomViewModel
            {
                Number = 101,
                Type = "Single",
                Rentability = "Rentable",
                Price = 50
            };

            // Assert
            Assert.AreEqual(101, viewModel.Number);
            Assert.AreEqual("Single", viewModel.Type);
            Assert.AreEqual("Rentable", viewModel.Rentability);
            Assert.AreEqual(50, viewModel.Price);
        }
    }
}
