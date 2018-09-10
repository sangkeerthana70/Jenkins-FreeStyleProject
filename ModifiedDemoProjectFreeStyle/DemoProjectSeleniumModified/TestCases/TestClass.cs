using DemoProjectSeleniumModified.POM;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjectSeleniumModified.TestCases
{
    class TestClass
    {
        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            //navigate to automationpractice.com
            PropertiesCollection.driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            //maximize window
            PropertiesCollection.driver.Manage().Window.Maximize();

            //Find the sign-in text box element
            PropertiesCollection.driver.FindElement(By.ClassName("login")).Click();

            Console.WriteLine("Opened URL and clicked Login Page");

        }

        [Test]
        public void ExecuteTest()
        {

            Console.WriteLine("1. Starting");

            //login to application by creating an instance of Authentication class
            Authentication authentication = new Authentication();
            Console.WriteLine("2. Authentication loaded");
            AccountPage accountPage = authentication.SignIn("asangeethu@yahoo.com", "@nuK1978");
            Console.WriteLine("3. Sign In Done");
            SearchResultsPage searchResults = accountPage.EnterSearchText("printed summer dress");
            Console.WriteLine("4. Search Done");
            CheckOut checkout = searchResults.AddToCart();
            Console.WriteLine("5. Added to cart");

            System.Threading.Thread.Sleep(5000);
            checkout.CompleteTransaction();
            Console.WriteLine("6. Proceed to checkout");

            IWebElement OrderConfirm = PropertiesCollection.driver.FindElement(By.XPath("//*[@id=\"center_column\"]/p[1]"));
            Console.WriteLine(OrderConfirm);
            Boolean Message = OrderConfirm.Text.Contains("Your order on My Store is complete");

            Assert.IsTrue(Message);
        }


        [Test]
        public void IncorrectUserIdOrPassword()
        {
            //login to application by creating an instance of Authentication class
            Authentication authentication = new Authentication();
            AccountPage accountPage = authentication.SignIn("asanhu@yahoo.com", "qwertop8");
            //AccountPage accountPage = authentication.SignIn("asangeethu@yahoo.com", " ");

            IWebElement loginMessage = PropertiesCollection.driver.FindElement(By.XPath("//*[@id=\"center_column\"]/div[1]/ol/li"));
            Console.WriteLine(loginMessage.Text);
            Boolean loginError = loginMessage.Text.Contains("Authentication failed");
            Console.WriteLine(loginError);
            Assert.IsTrue(loginError);
        }

        


        [TearDown]
        public void CleanUp()
        {
            //close window
            //driver.Close();

            Console.WriteLine("Closed the browser");
        }
    }
}
