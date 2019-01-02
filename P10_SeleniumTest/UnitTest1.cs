using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;

namespace P10_SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChromeMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.co.in/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(3000); //once browser open, close after 3000

            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void IEMethod()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("https://www.google.co.in/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(3000); //once browser open, close after 3000

            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void FireFoxMethod()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.co.in/");
            driver.Manage().Window.Maximize();

            Thread.Sleep(3000); //once browser open, close after 3000

            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void ChromeTestTitle()
        {
            string actualResult, expectedResult = "Google";

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.co.in");
            driver.Manage().Window.Maximize();

            //fetch the page title
            actualResult = driver.Title;

            //Assert, use .contains instead of assert.equal to compare 
            if (actualResult.Contains(expectedResult)) Assert.IsTrue(true, "page title match");
            else Assert.IsTrue(false, "page title does not exist");

            Thread.Sleep(3000); //once browser open, close after 3000
      
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void TwitterRoundUp()
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://twitter.com/login");
                driver.Manage().Window.Maximize();

                IWebElement username, passwd, loginbtn;

                username = driver.FindElement(By.ClassName("js-username-field"));
                username.SendKeys("it2116UserName");  //put your twitter user name here

                #region secret
                passwd = driver.FindElement(By.ClassName("js-password-field"));  
                passwd.SendKeys("passwordForTwitter");  //put your twitter password here
                #endregion

                loginbtn = driver.FindElement(By.XPath(".//*[@id='page-container']/div/div[1]/form/div[2]/button"));

                loginbtn.Click();
                //Thread.Sleep(8000);

          
                IWebElement tweetBox, tweetBtn;
                Random randomNum = new Random();
                int displayRandomNum = randomNum.Next(1, 111); //random num between 1 and 111
                tweetBox = driver.FindElement(By.Name("tweet"));
                tweetBox.SendKeys(displayRandomNum + " it2116 Selenium 8th video recording at: " + DateTime.Now.ToShortTimeString()); //put your tweet text here

                tweetBtn = driver.FindElement(By.ClassName("tweet-action"));
                tweetBtn.Click(); //find the tweet button and Click;
                //Thread.Sleep(5000);


                //browse through the global actions in top menu
                IWebElement ActionContainer = driver.FindElement(By.Id("global-actions"));

                ReadOnlyCollection<IWebElement> globalActions = ActionContainer.FindElements(By.TagName("li"));

                foreach (IWebElement globalAction in globalActions)
                {
                    string ActionName = globalAction.Text;
                    globalAction.Click();
                    Thread.Sleep(5000);
                } 
               

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
