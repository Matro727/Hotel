using Hotel.Models.Room;
using NUnit.Framework;

namespace Hotel.Tests.Models.Room
{
    [TestFixture]
    public class RoomViewModelTests
    {
        [Test]
        public void RoomViewModel_Properties_CanBeSetAndGet()
        {
            // Arrange
            var viewModel = new RoomViewModel(1, 101, "Single", "Rentable", 50);

            // Assert
            Assert.AreEqual(1, viewModel.Id);
            Assert.AreEqual(101, viewModel.Number);
            Assert.AreEqual("Single", viewModel.Type);
            Assert.AreEqual("Rentable", viewModel.Rentability);
            Assert.AreEqual(50, viewModel.Price);
        }
    }
}
