using System;
using System.Configuration;
using System.Threading;
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
                //Thread.Sleep(TimeSpan.FromSeconds(5)); // ira literalmente esperar todos esse tempo
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //espera no max 10s pra buscar o elemento
                driver.FindElement(By.Name("username")).SendKeys(ConfigurationManager.AppSettings["username"]);
                driver.FindElement(By.Name("password")).SendKeys(ConfigurationManager.AppSettings["password"]);
                driver.FindElement(By.XPath("//*[@id='loginForm']/div/div[3]/button/div")).Click();
                
                Thread.Sleep(TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl(@"https://www.instagram.com/portalg1/");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath("//*[@id='react-root']/section/main/div/header/section/div[1]/div[2]/div/div/div/span/span[1]/button")).Click();
                //driver.FindElement(By.XPath("//button[contains(text(),'Seguir')]")).Click(); // outra alternativa de XPath
            }
            catch (Exception ex) //imprime o erro
            {
                Console.WriteLine(ex.ToString()); 
            }
            finally
            {
                driver.Close(); // fecha browser
                driver.Dispose(); //libera memoria, etc
            }

        }
    }
}
