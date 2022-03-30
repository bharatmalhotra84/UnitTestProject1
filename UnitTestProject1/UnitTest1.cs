using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System.Globalization;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Driver");
            try
            {
                
                executeTest(driver, "laptop", 100);
                executeTest(driver, "mobile", 50);
            }
            finally
            {
                //driver.Close();
                driver.Quit();

            }

        }
        static void executeTest(IWebDriver driver, string searchPharse, decimal expectedMaximumValue)
        {              
                driver.Navigate().GoToUrl("https://www.amazon.com");

                IWebElement query = driver.FindElement(By.Id("twotabsearchtextbox"));
                query.SendKeys(searchPharse);
                query.Submit();

                driver.FindElement(By.XPath("//a[@class='a-link-normal s-no-outline']")).Click();

                IWebElement element = driver.FindElement(By.Id("corePrice_feature_div"));

                decimal amount = decimal.Parse(element.Text.Replace("$", ""), NumberStyles.Currency);

                if (element != null)
                {
                    Assert.IsTrue(amount > expectedMaximumValue, "the '"+ searchPharse +"' price is less than $100");
                }
            }
          


            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //string script = "alert('" + amount + "');";
            //js.ExecuteScript(script);
            //

    }
}

