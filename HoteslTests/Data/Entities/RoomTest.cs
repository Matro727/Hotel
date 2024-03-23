using Hotel.Data.Entities;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Tests.Entities
{
    [TestFixture]
    public class RoomTests
    {
        [Test]
        public void Room_Constructors_SetsPropertiesCorrectly()
        {
            
            int id = 1;
            int number = 101;
            string type = "Single";
            string rentability = "Rentable";
            int price = 50;

            
            var room1 = new Room(number, type, rentability, price);
            var room2 = new Room(id, number, type, rentability, price);

            
            Assert.AreEqual(id, room2.Id);
            Assert.AreEqual(number, room1.Number);
            Assert.AreEqual(type, room1.Type);
            Assert.AreEqual(rentability, room1.Rentability);
            Assert.AreEqual(price, room1.Price);
        }

        [Test]
        public void Room_Number_Property_IsRequired()
        {
            
            var room = new Room();

            
            var validationResult = ValidateModel(room);

            
            Assert.IsFalse(validationResult);
        }

        [Test]
        public void Room_Type_Property_IsRequired()
        {
            
            var room = new Room();

            
            var validationResult = ValidateModel(room);

            
            Assert.IsFalse(validationResult);
        }

        [Test]
        public void Room_Rentability_Property_IsRequired()
        {
            
            var room = new Room();

            
            var validationResult = ValidateModel(room);

            
            Assert.IsFalse(validationResult);
        }

        [Test]
        public void Room_Price_Property_IsRequired()
        {
            
            var room = new Room();

            
            var validationResult = ValidateModel(room);

            
            Assert.IsFalse(validationResult);
        }

        private bool ValidateModel(object model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();

            return Validator.TryValidateObject(model, context, validationResults, validateAllProperties: true);
        }
    }
}
