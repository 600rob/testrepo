using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;

namespace Selenium_Setup
{
    [TestClass]
    public class ElementInterrogation
    {

        IWebDriver driver;
        string testUrl = "https://www.ultimateqa.com/simple-html-elements-for-automation/";



        [TestMethod]
        public void ElementIterogation()
        {
            driver = GetChromeDriver();

            driver.Navigate().GoToUrl(testUrl);
            driver.Manage().Window.Maximize();

            IWebElement button = driver.FindElement(By.XPath("//button[.='Click Me!']"));

            Assert.AreEqual("submit", button.GetAttribute("type"));
            Assert.IsTrue(button.Displayed);
            Assert.IsTrue(button.Enabled);
            Assert.IsFalse(button.Selected);
            Assert.AreEqual(button.Text, "Click Me!");
            Assert.AreEqual("button", button.TagName);
           







            driver.Quit();








        }






        // helper class to get the chrome driver from our local project

        private IWebDriver GetChromeDriver()
        {

            var outputdirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputdirectory);
        }
    }
}
