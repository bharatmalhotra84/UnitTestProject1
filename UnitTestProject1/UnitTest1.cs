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
            executeTest();
        }
        static void executeTest()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Driver");
            driver.Navigate().GoToUrl("https://www.amazon.com");
            IWebElement query = driver.FindElement(By.Id("twotabsearchtextbox"));
            query.SendKeys("laptop");            
            query.Submit();

            driver.FindElement(By.XPath("//a[@class='a-link-normal s-no-outline']")).Click();

            IWebElement element = driver.FindElement(By.Id("corePrice_feature_div"));

            decimal amount = decimal.Parse(element.Text.Replace("$", ""), NumberStyles.Currency);

            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //string script = "alert('" + amount + "');";
            //js.ExecuteScript(script);
            //
            Assert.IsTrue(amount > 100, "the laptop price is less than $100");
        }



    }
}

