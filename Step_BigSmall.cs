
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Comprehensive
{
    [Binding]
    public sealed class Step_BigSmall
    {
        IWebDriver driver = new FirefoxDriver();
        [Given(@"I open the website BigSmall")]
        public void GivenIOpenTheWebsiteBIgSmall()
        {
            driver.Url = "https://www.bigsmall.in/";
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "I open the website BIgSmall"));
        }
        [Then(@"the website is loaded properly")]
         public void WhenTheWebsiteIsLoadedProperly()
        {
            String title = driver.Title;
            Console.WriteLine("Page title is : " + title);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "the website is loaded properly"));
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Initialize.png", ScreenshotImageFormat.Png);
            driver.Quit();
        }

        [Given(@"I click on signin button")]
        public void GivenIClickOnSigninButton()
        {
            Thread.Sleep(3000);
            CommonMethods.loginpage(driver);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "I click on signin button"));
        }

        [Given(@"I enter (.*) and (.*)")]
        public void GivenIEnterAbenirGmail_ComAndAbenir(string email, string password)
        {
            Thread.Sleep(3000);
            CommonMethods.EnterloginDetails(driver,email,password);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "I enter " +email+ " and " +password));
        }
        [Given(@"I enter following details")]
        public void GivenIenterfollowingdetails(Table table)
        {
            Thread.Sleep(3000);
            details data = table.CreateInstance<details>();
            string firstname = data.firstname;
            string lastname = data.lastname;
            string email = data.email;
            string password = data.password;
            CommonMethods.EntersigninDetails(driver,firstname,lastname, email, password);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "I enter " + email + " and " + password));
        }
        [Then(@"the account is validated for (.*) and (.*)")]
        public void ThenTheAccountIsValidatedForAbeAndNir(string firstname, string lastname)
        {
            Thread.Sleep(3000);
            CommonMethods.ValidateUsername(driver, firstname, lastname);
            CommonMethods.Logout(driver);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "the account is validated for " + firstname + " - " + lastname));
            driver.Quit();
        }


        [Then(@"the account  username is validated")]
        public void Thentheaccountusernameisvalidated(Table table)
        {
            Thread.Sleep(3000);
            
            Thread.Sleep(15000);
            details data = table.CreateInstance<details>();
            string firstname = data.firstname;
            string lastname = data.lastname;
            CommonMethods.ValidateUsername(driver, firstname, lastname);
            CommonMethods.Logout(driver);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "the account  username is validated"));
            driver.Quit();
        }
        [Given(@"i search for (.*) in the searchbox")]
        public void GivenISearchForInTheSearchbox(string keyword)
        {
            Thread.Sleep(3000);
            CommonMethods.searchbox(driver,keyword);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "i search for " + keyword + " in the searchbox"));
            
            
        }
        [Given(@"i filter based on price from low to high")]
        public void GivenIFilterBasedOnPriceFromLowToHigh()
        {
            Thread.Sleep(3000);
            CommonMethods.filter(driver);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "i filter based on price from low to high"));
        }
        [Then(@"get the number of products")]
        public void ThenGetTheFirstProductName()
        {
            Thread.Sleep(3000);
            CommonMethods.getproduct(driver);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "get the number of products"));
            driver.Quit();
        }
        [Then(@"select the product and add to wishlist")]
        public void ThenSelectTheProductAndAddToWishlist()
        {
            Thread.Sleep(3000);
            CommonMethods.selectproduct(driver);
            Thread.Sleep(3000);
            CommonMethods.addWishlist(driver);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "select the product and add to wishlist"));
        }
        [Then(@"add to cart from wishlist")]
        public void ThenAddToCartFromWishlist()
        {
            Thread.Sleep(3000);
            CommonMethods.addtocart(driver);
            CommonMethods.WriteLog("ConsoleLog", String.Format("{0} @ {1}", DateTime.Now, "add to cart from wishlist"));
            driver.Quit();

        }






    }
}
