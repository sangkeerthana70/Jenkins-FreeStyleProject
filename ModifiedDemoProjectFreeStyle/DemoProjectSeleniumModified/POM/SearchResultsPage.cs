using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjectSeleniumModified.POM
{
    public class SearchResultsPage
    {
        [Obsolete("Use newMethod instead", false)]
        public SearchResultsPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);

        }
        [FindsBy(How = How.ClassName, Using = "product_img_link")]
        public IWebElement SearchResult { get; set; }

        [FindsBy(How = How.ClassName, Using = "ajax_add_to_cart_button")]
        public IWebElement AddToCartButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a")]
        public IWebElement ProceedToCheckOutButton { get; set; }

        //hover on search item and add to cart
        public CheckOut AddToCart()
        {
            Actions action = new Actions(PropertiesCollection.driver);
            action.MoveToElement(SearchResult).Perform();

            AddToCartButton.Click();
            //manage element not visible
            System.Threading.Thread.Sleep(5000);
            ProceedToCheckOutButton.Click();
            System.Threading.Thread.Sleep(5000);
            return new CheckOut();
        }
    }
}
