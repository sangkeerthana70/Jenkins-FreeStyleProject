using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjectSeleniumModified.POM
{
    public class AccountPage
    {
        [Obsolete("Use newMethod instead", false)]
        public AccountPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        //identify the search text box element by the id value as search_query_top
        [FindsBy(How = How.Id, Using = "search_query_top")]
        public IWebElement TxtSearch { get; set; }
        //identify the search button with name value as submit_search
        [FindsBy(How = How.Name, Using = "submit_search")]
        public IWebElement BtnClick { get; set; }

        //method to enter a search text in the search box and click search
        public SearchResultsPage EnterSearchText(string searchTxt)
        {
            TxtSearch.SendKeys(searchTxt);
            BtnClick.Click();

            return new SearchResultsPage();
        }
    }
}
