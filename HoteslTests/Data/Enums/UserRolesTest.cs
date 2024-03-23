using Hotel.Data.Enums;
using NUnit.Framework;

namespace Hotel.Tests.Enums
{
    [TestFixture]
    public class UserRolesTests
    {
        [Test]
        public void UserRoles_Enum_ContainsExpectedValues()
        {
           
            Assert.AreEqual("User", UserRoles.User.ToString());
            Assert.AreEqual("Admin", UserRoles.Admin.ToString());
        }

        
    }
}
