// Victor Marrufo
// James Lundgren

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumRuby
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://uofu-cs4540-50.cloudapp.net:3000/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheSeleniumRubyTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.LinkText("Sign up")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("user_email")).Clear();
            driver.FindElement(By.Id("user_email")).SendKeys("newuser6@email.com");
            driver.FindElement(By.Id("user_password")).Clear();
            driver.FindElement(By.Id("user_password")).SendKeys("passpass");
            driver.FindElement(By.Id("user_password_confirmation")).Clear();
            driver.FindElement(By.Id("user_password_confirmation")).SendKeys("passpass");
            driver.FindElement(By.Name("commit")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.LinkText("Add Item")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            Thread.Sleep(3000);
            driver.FindElement(By.Id("todo_name")).Clear();
            driver.FindElement(By.Id("todo_name")).SendKeys("Play Video Games");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.Name("commit")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.LinkText("Add Item")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            Thread.Sleep(3000);
            driver.FindElement(By.Id("todo_name")).Clear();
            driver.FindElement(By.Id("todo_name")).SendKeys("Learn Ruby");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.Name("commit")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.LinkText("Add Item")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            Thread.Sleep(3000);
            driver.FindElement(By.Id("todo_name")).Clear();
            driver.FindElement(By.Id("todo_name")).SendKeys("Create TODO Application");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.Name("commit")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.XPath("(//a[contains(text(),'Mark as Done')])[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.XPath("(//a[contains(text(),'Mark as Done')])[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.LinkText("Sign out")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Sign in")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            Thread.Sleep(3000);
            driver.FindElement(By.Id("user_email")).Clear();
            driver.FindElement(By.Id("user_email")).SendKeys("newuser@email.com");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.Id("user_password")).Clear();
            driver.FindElement(By.Id("user_password")).SendKeys("passpass");
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.Id("user_remember_me")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | name=faInitWnd|1429810114 | ]]
            driver.FindElement(By.Name("commit")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SeleniumRuby test = new SeleniumRuby();

            test.SetupTest();
            test.TheSeleniumRubyTest();
            test.TeardownTest();
        }
    }

}
