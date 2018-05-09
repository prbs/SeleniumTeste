using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace NaoraTesteCommon
{
    [TestClass]
    public class Common
    {
       
         

        
        public static void acessoPerfilPacienteMenuSanduiche(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            while (!driver.FindElement(By.Id("dropdownMenu2")).Displayed)
            {
                System.Threading.Thread.Sleep(1000);
            }

            while (!driver.FindElement(By.Id("dropdownMenu2")).Displayed)
            {
                System.Threading.Thread.Sleep(1000);
            }

            IWebElement dropMenu = driver.FindElement(By.Id("dropdownMenu2"));

            dropMenu.Click();

            while (!driver.FindElement(By.CssSelector("ul[aria-labelledby='dropdownMenu2']>li:first-child")).Displayed)
            {
                System.Threading.Thread.Sleep(1000);
            }


            IWebElement chooseMenu = driver.FindElement(By.CssSelector("ul[aria-labelledby='dropdownMenu2']>li:first-child"));

            chooseMenu.Click();
        }

        [TestMethod]
        public static void login(IWebDriver driver, string email, string senha)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            IWebElement btnLogin = driver.FindElement(By.CssSelector("button.campo-div-2.botao-entrar.form-control.drop-shadow-back"));

            IWebElement formEmail = driver.FindElement(By.CssSelector("input[formcontrolname='email']"));

            while (!btnLogin.Displayed)
            {
                System.Threading.Thread.Sleep(1000);
            }

            formEmail.Clear();
            formEmail.SendKeys(email);

            IWebElement formPassword = driver.FindElement(By.CssSelector("input[formcontrolname='senha']"));

            formPassword.Clear();
            formPassword.SendKeys(senha);

            btnLogin.Click();
        }

    }
}
