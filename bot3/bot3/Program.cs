using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace bot3
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
        }
    }
}
