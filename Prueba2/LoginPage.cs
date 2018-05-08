using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Prueba2
{
    public class LoginPage
    {
        private ChromeDriver Chrome;
        private StringBuilder verificationErrors;
        private string baseURL;

        [OneTimeSetUp]
        public void SetupTest()
        {
            Chrome = new ChromeDriver();
            baseURL = "https://account.measureup.com/login";
            verificationErrors = new StringBuilder();
            Chrome.Manage().Window.Maximize();
            Chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [Test]
        public void LogInMUP()
        {
            try
            {
                string TabName = "Learning Locker";
                Chrome.Navigate().GoToUrl(baseURL);
                Chrome.FindElement(By.Name("name")).Click();
                Console.WriteLine("Caja nombre localizada");
                Chrome.FindElement(By.Name("name")).SendKeys("mdgarcia");
                Console.WriteLine("Username añadido");
                Chrome.FindElement(By.Name("password")).Click();
                Console.WriteLine("Caja contraseña localizada");
                Chrome.FindElement(By.Name("password")).SendKeys("MUP.Pr0d");
                Console.WriteLine("Contraseña Añadida");
                Chrome.FindElement(By.XPath("//*[@id='loginTab']/div/form/button")).Click();
                Console.WriteLine("Botón Submmit clickado");
                string ActualTab = Chrome.Title;
                Assert.AreEqual(TabName, ActualTab);
                Console.WriteLine("El nombre de la pestaña es correcto");
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TearDown]
        public void TeardownTest()
        {

            Chrome.Quit();
        }
    }
}