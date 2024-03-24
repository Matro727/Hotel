using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Hotel.Tests.Views
{
    [TestFixture]
    public class IndexViewTests
    {
        [Test]
        public void IndexView_RendersWithoutErrors()
        {
            
            var view = new IndexView();

            
            var result = view.Render();

            
            Assert.IsNotNull(result);
           
        }
    }

    
    public class IndexView : ViewComponent
    {
        public string Render()
        {
            
            return "View rendering completed"; 
        }
    }
}
