using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class RazorViewTests
{
    private IWebDriver _driver;
    private const string BaseUrl = "http://localhost:5000"; 

    [Test]
    public void Setup()
    {
        
        var options = new ChromeOptions();
        options.AddArgument("--headless"); 
        _driver = new ChromeDriver(options);
    }

    
}
