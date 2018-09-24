using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

using System.Reflection;
using OpenQA.Selenium;
using System.IO;


namespace Selenium_Setup
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        string testUrl = "https://www.ultimateqa.com/simple-html-elements-for-automation/";


        [TestMethod]
        public void TestMethod1()
        {

            driver = GetChromeDriver();

            driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");

            var linkList = driver.FindElements(By.ClassName("et_pb_blurb_description"));
            linkList[4].Click();

            driver.Close();

            driver.Quit();
        }


        [TestMethod]
        public void clickARadioButton()
        {
            driver = GetChromeDriver();

            driver.Navigate().GoToUrl(testUrl);
            var radioButtons = driver.FindElements(By.XPath("//input[@type='radio']"));
            radioButtons[0].Click();

            driver.Quit();


        }

        [TestMethod]
        public void selectACheckbox()
        {
            driver = GetChromeDriver();

            driver.Navigate().GoToUrl(testUrl);
            var checkBox = driver.FindElements(By.XPath("//input[@type='checkbox']"));
            checkBox[0].Click();

            driver.Quit();


        }


        [TestMethod]
        public void selectADropDownOption()
        {
            driver = GetChromeDriver();

            driver.Navigate().GoToUrl(testUrl);
            var dropDowns = driver.FindElements(By.XPath("//select/option"));
            dropDowns[3].Click();

            driver.Quit();


        }

        [TestMethod]
        public void selectTabTwo()
        {
            driver = GetChromeDriver();

         
            driver.Navigate().GoToUrl(testUrl);
            driver.FindElement(By.XPath("//li[@class='et_pb_tab_1']")).
                Click();

            IWebElement tabSelection = driver.FindElement
                (By.XPath("//div[contains(@style,'z-index: 1')]//div[@class]"));

            Assert.AreEqual("Tab 2 content", tabSelection.
                Text);

            driver.Quit();


        }




        // helper class to get the chrome driver from out local project

        private IWebDriver GetChromeDriver()
        {

            var outputdirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputdirectory);
        }
    }
}
