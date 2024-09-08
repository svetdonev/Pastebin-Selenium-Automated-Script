using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastebin_Script.Pages
{
    public class Page
    {
        private IWebDriver driver;
        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static string PastebinUrl = "https://pastebin.com/";
        public IWebElement TextInput => driver.FindElement(By.Id("postform-text"));
        public IWebElement ExpirationDropdown => driver.FindElement(By.Id("select2-postform-expiration-container"));
        public IWebElement PasteNameInput => driver.FindElement(By.Id("postform-name"));
        public IWebElement CreateNewPasteButton => driver.FindElement(By.XPath("//button[text()='Create New Paste']"));
        public void SelectPasteExpiration(string expirationOption)
        {
            ExpirationDropdown.Click();
            driver.FindElement(By.XPath($"//li[text()='{expirationOption}']")).Click();
        }
        public void CreateNewPaste(string text, string expirationOption, string name)
        {
            TextInput.SendKeys(text);
            SelectPasteExpiration(expirationOption);
            PasteNameInput.SendKeys(name);
            CreateNewPasteButton.Click();
        }
    }
}
