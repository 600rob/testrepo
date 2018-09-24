using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;


namespace Selenium_Setup
{
    [TestClass]
    public class ElementManipulation
    {

        IWebDriver driver;
        string testUrl = "https://www.ultimateqa.com/filling-out-forms/";
    




        [TestMethod]
        public void experiementWithForms()
        {
            driver = GetChromeDriver();

            driver.Navigate().GoToUrl(testUrl);
            driver.Manage().Window.Maximize();

          Assert.AreEqual("Filling Out Forms - Ultimate QA", driver.Title);


            
                
            IWebElement nameField = driver.FindElement(By.XPath("//p[contains(@class,'_field_2')]//input"));
            var messageField = driver.FindElement(By.XPath("//p[contains(@class,'_field_3')]//textarea"));
            var capthca = driver.FindElement(By.XPath("//input[@class='input et_pb_contact_captcha']"));
            var answerField = driver.FindElement(By.XPath("//input[@class='input et_pb_contact_captcha']"));
            

           

               

            int fisrtInt = int.Parse(capthca.GetAttribute("data-first_digit"));
            int secondInt = int.Parse(capthca.GetAttribute("data-second_digit"));

            nameField.SendKeys("robbo");
            messageField.SendKeys("this is a test");

            answerField.SendKeys((fisrtInt+secondInt).ToString());

            driver.FindElements(By.XPath("//button[@type='submit']"))[1].Click();


            var message = driver.FindElement(By.CssSelector("div[class='et-pb-contact-message'] p"));

            Assert.Equals(message.Text, ("Sucess"));














            driver.Quit();




            //Trace.WriteLine(capthca.Text);
            // can find the submit button and subit the form if required
            //IWebElement submitButton = driver.findElement(By.CssSelector)

            //nameField.SendKeys("ivan drago");
            // messageField.SendKeys("this is a test");
            // messageField.Clear();

            // messageField.SendKeys("this is for Real!!");








        }

        

        //helper method to get driver object.

        private IWebDriver GetChromeDriver()
        {
            var outputdirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputdirectory);

        }
    }

   
    }

