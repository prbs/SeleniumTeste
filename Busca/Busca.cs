using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NaoraTesteBusca
{
    [TestClass]
    public class Busca
    {
      
        public static void BuscarNomeProfissional(string baseUrl)
        {

            IWebDriver driver = new ChromeDriver();

           

            IJavaScriptExecutor jsScript = driver as IJavaScriptExecutor;
         
            driver.Navigate().GoToUrl(baseUrl + "home");

            //jsScript.ExecuteScript("location.replace(" + baseUrl + "'home')");

            //location.replace("https://www.w3schools.com")




        }
    }
}
