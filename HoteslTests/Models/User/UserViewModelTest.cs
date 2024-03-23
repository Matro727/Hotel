using Hotel.Models.User;
using NUnit.Framework;

namespace Hotel.Tests.Models.User
{
    [TestFixture]
    public class UserViewModelTests
    {
        [Test]
        public void UserViewModel_Properties_CanBeSetAndGet()
        {
            // Arrange
            var viewModel = new UserViewModel("1", "user@example.com", "John Doe", "Admin");

            // Assert
            Assert.AreEqual("1", viewModel.Id);
            Assert.AreEqual("user@example.com", viewModel.Email);
            Assert.AreEqual("John Doe", viewModel.Name);
            Assert.AreEqual("Admin", viewModel.Role);
        }
    }
}
