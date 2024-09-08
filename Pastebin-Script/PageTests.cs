using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Pastebin_Script.Pages;

namespace Pastebin_Script
{
    [TestFixture]
    public class PageTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Page page;

        private string text;
        private string expirationOption;
        private string name;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            page = new Page(driver);
        }

        [Test]
        public void CreateNewPasteTest()
        {
            driver.Navigate().GoToUrl(Page.PastebinUrl);

            text = "Hello from WebDriver";
            expirationOption = "10 Minutes";
            name = "helloweb";

            page.CreateNewPaste(name, expirationOption, name);
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            if(driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}