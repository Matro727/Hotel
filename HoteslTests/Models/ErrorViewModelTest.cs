using Hotel.Models;
using NUnit.Framework;

namespace Hotel.Tests.Models
{
    [TestFixture]
    public class ErrorViewModelTests
    {
        [Test]
        public void ErrorViewModel_RequestId_Property_CanBeSetAndGet()
        {
            // Arrange
            var viewModel = new ErrorViewModel();

            // Act
            viewModel.RequestId = "123";

            // Assert
            Assert.AreEqual("123", viewModel.RequestId);
        }

        [Test]
        public void ErrorViewModel_ShowRequestId_Property_ReturnsFalseWhenRequestIdIsNull()
        {
            // Arrange
            var viewModel = new ErrorViewModel();

            // Act
            viewModel.RequestId = null;

            // Assert
            Assert.IsFalse(viewModel.ShowRequestId);
        }

        [Test]
        public void ErrorViewModel_ShowRequestId_Property_ReturnsFalseWhenRequestIdIsEmpty()
        {
            // Arrange
            var viewModel = new ErrorViewModel();

            // Act
            viewModel.RequestId = "";

            // Assert
            Assert.IsFalse(viewModel.ShowRequestId);
        }

        [Test]
        public void ErrorViewModel_ShowRequestId_Property_ReturnsTrueWhenRequestIdIsNotEmpty()
        {
            // Arrange
            var viewModel = new ErrorViewModel();

            // Act
            viewModel.RequestId = "123";

            // Assert
            Assert.IsTrue(viewModel.ShowRequestId);
        }
    }
}
