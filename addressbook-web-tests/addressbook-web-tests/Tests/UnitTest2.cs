using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2()
        {
            string[] s = new string[] { "I", "want", "to", "sleep" };
            for (int i=0; i<s.Length; i++)
            {
                System.Console.Out.Write(s[i] + "\n");
            }
            foreach (string element in s)
            {
                System.Console.Out.Write(element + "\n");
            }

            IWebDriver driver = null;
            int attempt = 0;
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60)
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }

            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            } while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60) ;
        }

    }
}
