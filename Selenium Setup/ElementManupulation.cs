using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;

namespace Selenium_Setup
{
    [TestClass]
    public class NavigationTest
    {

        IWebDriver driver;
        string testUrl1 = "https://www.ultimateqa.com";
        string testUrl2 = "https://www.ultimateqa.com/automation";



        [TestMethod]

        public void navigateUsingDirectDriver()
        {
            //this test uses the instance of chromedriver that is set up on my machine. I beleive that so long as the
            //ChromeDriver location is On the path then this will work. ( to be confirmed and updated!)
            var directDriver = new ChromeDriver();

            directDriver.Navigate().GoToUrl(testUrl1);

            directDriver.Quit();


        }






        [TestMethod]
        public void navigateAndAssertTitle()
        {
            driver = GetChromeDriver();

            driver.Navigate().GoToUrl(testUrl1);
            Assert.AreEqual("Home - Ultimate QA", driver.Title);

            driver.Quit();

        }


        [TestMethod]
        public void navigateToAndBack()

        {
            // this uses the GetChromeDriverMethod, which has been set up to point at an instance of chromedriver.exe which is installed in this project
            //this means the project can be transferred from machne to machine without having to reconfigure the chromedriver setup
            driver = GetChromeDriver();
            driver.Navigate().GoToUrl(testUrl2);

            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);

            driver.FindElement(By.XPath("//a[@href='../complicated-page']")).Click();

            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);

            driver.Navigate().Back();
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);





        }

        //helper method to get drive object.

       private IWebDriver GetChromeDriver()
        {
            var outputdirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputdirectory);

        }
    }
}
