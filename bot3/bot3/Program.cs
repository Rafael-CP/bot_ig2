using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace bot3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            driver.Manage().Window.Maximize();

            try //caso ocorra um erro 
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //espera no max 10s pra buscar o elemento
                driver.FindElement(By.Name("username")).SendKeys(ConfigurationManager.AppSettings["username"]);
                driver.FindElement(By.Name("password")).SendKeys(ConfigurationManager.AppSettings["password"]);
                driver.FindElement(By.XPath("//*[@id='loginForm']/div/div[3]/button/div")).Click();


            }
            catch(Exception ex) //imprime o erro
            {
                Console.WriteLine(ex.ToString()); 
            }

        }
    }
}
