using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comprehensive
{
    class CommonMethods
    {

        public static bool WriteLog(string strFileName, string strMessage)
        {
            try
            {
                string path = "C:/Users/David/Desktop/Comprehensive/logs";
                FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", Path.GetFullPath(path), strFileName), FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(strMessage);
                objStreamWriter.Close();
                objFilestream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal static void loginpage(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//header/div[2]/div[2]/div[4]/div[1]/div[1]/a[1]")).Click();
            //driver.FindElement(By.PartialLinkText("/account/login")).Click();
        }

        internal static void EnterloginDetails(IWebDriver driver, string email,string password)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//input[@id='CustomerEmail']")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@id='CustomerPassword']")).SendKeys(password);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("login.png", ScreenshotImageFormat.Png);
            driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();
        }

        internal static void ValidateUsername(IWebDriver driver, string firstname, string lastname)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Thread.Sleep(15000);// to do capcha
            driver.FindElement(By.XPath("//header/div[2]/div[2]/div[4]/div[1]/div[1]/a[1]")).Click();
            
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("loginpage.png", ScreenshotImageFormat.Png);
            string s = firstname + " " + lastname;
            string path = "//p[contains(text(),'" + s + "')]";
            string r = driver.FindElement(By.XPath(path)).Text.ToString();
            if (r == s)
            {
                Console.WriteLine("username is correct");
                Console.WriteLine(r);
            }
            else
            {
                Console.WriteLine("username does not match");
                Console.WriteLine(r);
            }

        }

        internal static void EntersigninDetails(IWebDriver driver, string firstname, string lastname, string email, string password)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            try
            {
                driver.FindElement(By.XPath("//a[@id='customer_register_link']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//input[@id='FirstName']")).SendKeys(firstname);
                driver.FindElement(By.XPath("//input[@id='LastName']")).SendKeys(lastname);
                driver.FindElement(By.XPath("//input[@id='Email']")).SendKeys(email);
                driver.FindElement(By.XPath("//input[@id='CreatePassword']")).SendKeys(password);
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("signin.png", ScreenshotImageFormat.Png);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            }
            catch(Exception ex)
            {
                Console.WriteLine("gmail already taken....Enter new details");
                Console.WriteLine(ex);
            }
            
            
        }

        internal static void searchbox(IWebDriver driver, string keyword)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//header/div[2]/div[2]/div[3]/form[1]/input[2]")).SendKeys(keyword);
            driver.FindElement(By.XPath("//header/div[2]/div[2]/div[3]/form[1]/input[2]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);//for screenshot
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("search.png", ScreenshotImageFormat.Png);
        }

        internal static void filter(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath("//span[contains(text(),'Relevance')]"))).Build().Perform();
            driver.FindElement(By.XPath("//a[contains(text(),'Price: Low to High')]")).Click();
            Thread.Sleep(3000);//for sceenshot
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("filtered.png", ScreenshotImageFormat.Png);

        }

        internal static void getproduct(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            string no_ofproducts = driver.FindElement(By.XPath("//body/div[2]/div[2]/div[1]/main[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[1]/a[1]")).Text;
            Console.WriteLine(no_ofproducts);
        }

        internal static void Logout(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//a[@id='customer_logout_link']")).Click();
        }

        internal static void selectproduct(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//span[contains(text(),'Harry Potter Characters Keychain')]")).Click();
            Thread.Sleep(3000);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("selectedproduct.png", ScreenshotImageFormat.Png);
        }

        internal static void addWishlist(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//span[contains(text(),'Add to Wishlist')]")).Click();
            Thread.Sleep(3000);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("wishlist.png", ScreenshotImageFormat.Png);

        }

        internal static void addtocart(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.XPath("//span[contains(text(),'wish list')]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[contains(text(),'Add To Cart')]")).Click();
            Thread.Sleep(3000);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("cart.png", ScreenshotImageFormat.Png);
        }
    }
}
