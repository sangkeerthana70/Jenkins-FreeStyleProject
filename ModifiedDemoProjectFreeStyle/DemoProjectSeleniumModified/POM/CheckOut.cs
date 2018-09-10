using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjectSeleniumModified.POM
{
    public class CheckOut
    {
        [Obsolete("Use newMethod instead", false)]
        //empty constructor
        public CheckOut()
        {
            Console.WriteLine("Inside Constructor : Checkout");
            PageFactory.InitElements(PropertiesCollection.driver, this);

        }
        [FindsBy(How = How.ClassName, Using = "standard-checkout")]
        public IWebElement CheckOutButton { get; set; }

        public IWebElement AcceptBox { get; set; }

        public void CompleteTransaction()
        {

            Console.WriteLine("Inside CompleteTransaction");
            Console.WriteLine(CheckOutButton);
            CheckOutButton.Click();
            //for page reload
            //address tab
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("After First Click and Sleep");
            CheckOutButton = PropertiesCollection.driver.FindElement(By.Name("processAddress"));
            Console.WriteLine(CheckOutButton);
            CheckOutButton.Click();
            //shipping tab
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("After second click and sleep");
            CheckOutButton = PropertiesCollection.driver.FindElement(By.Name("processCarrier"));
            Console.WriteLine(CheckOutButton);
            //terms of service
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Accept terms");
            AcceptBox = PropertiesCollection.driver.FindElement(By.Id("cgv"));
            Console.WriteLine("Clicking check box " + AcceptBox);
            AcceptBox.Click();
            CheckOutButton.Click();
            //Payment 
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Pay check");
            CheckOutButton = PropertiesCollection.driver.FindElement(By.ClassName("cheque"));
            Console.WriteLine(CheckOutButton);
            CheckOutButton.Click();
            //confirm order
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Confirm Order");
            CheckOutButton = PropertiesCollection.driver.FindElement(By.XPath("//*[@id=\"cart_navigation\"]/button"));
            Console.WriteLine("Checkout button " + CheckOutButton);
            CheckOutButton.Click();
            

        }
    }
}
