using Hotel.Data;
using Hotel.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Hotel.Tests.Data
{
    [TestFixture]
    public class ApplicationContextTests
    {
        [Test]
        public void ApplicationContext_CanCreateInstance()
        {
            
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            
            using (var context = new ApplicationContext(options))
            {
                
                Assert.IsNotNull(context);
            }
        }

        [Test]
        public void ApplicationContext_CanAccessRooms()
        {
            
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            
            using (var context = new ApplicationContext(options))
            {
                
                Assert.IsNotNull(context.Rooms);
            }
        }

        
    }
}

