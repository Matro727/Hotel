using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using NUnit.Framework;

namespace YourProject.Tests.Views
{
    [TestFixture]
    public class CreateRoomViewTests
    {
        [Test]
        public void CreateRoomView_RenderedCorrectly()
        {
            // Arrange
            var html = @"
                <html>
                <head><title>Create Room</title></head>
                <body>
                    <h2>Create Product</h2>
                    <form method='post' asp-controller='Room' asp-action='Create'>
                        <p>
                            <label>Number</label>
                            <input type='number' name='number' />
                        </p>
                        <p>
                            <label>Type</label>
                            <input type='text' name='type' />
                        </p>
                        <p>
                            <label>Rentability</label>
                            <input type='text' name='rentability' />
                        </p>
                        <p>
                            <label>Price</label>
                            <input type='number' name='price' />
                        </p>
                        <button type='submit'>Create</button>
                    </form>
                </body>
                </html>";

            var parser = new HtmlParser();

            // Act
            var document = parser.ParseDocument(html);

            // Assert
            var titleElement = document.QuerySelector("title");
            Assert.IsNotNull(titleElement);
            Assert.AreEqual("Create Room", titleElement.TextContent.Trim());

            var formElement = document.QuerySelector("form");
            Assert.IsNotNull(formElement);
            Assert.AreEqual("post", formElement.GetAttribute("method"));
            Assert.AreEqual("Room", formElement.GetAttribute("asp-controller"));
            Assert.AreEqual("Create", formElement.GetAttribute("asp-action"));

            var inputElements = document.QuerySelectorAll("input");
            Assert.AreEqual(4, inputElements.Length);
            foreach (var input in inputElements)
            {
                Assert.IsTrue(input.HasAttribute("name"));
            }

            var buttonElement = document.QuerySelector("button");
            Assert.IsNotNull(buttonElement);
            Assert.AreEqual("submit", buttonElement.GetAttribute("type"));
            Assert.AreEqual("Create", buttonElement.TextContent.Trim());
        }
    }
}
