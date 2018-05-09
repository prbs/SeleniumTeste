using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using AvilaCore;
using System.IO;
using System.Linq;
using OpenQA.Selenium.Interactions;
using log4net;
using NaoraTeste.Util;

namespace NaoraTest.perfilUsuario
{
    class TestCase002_Login
    {
        public static string nomeExib;
        public static bool logado = true;

        [TestMethod]
        public static string Login(IWebDriver driver,string caminho, string tipo, string email, string senha, string nome)
        {
            try
            {
                //Mapeamento de elementos da pagina e preenchimento de login.
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

                System.Threading.Thread.Sleep(4000);
                driver.FindElement(By.XPath("//*[@id=\"login-email\"]")).SendKeys(email);
                driver.FindElement(By.XPath("//*[@id=\"login-senha\"]")).SendKeys(senha);
                driver.FindElement(By.XPath("//*[@id=\"btn-login\"]")).Click();
                System.Threading.Thread.Sleep(10000);

                switch (tipo)
                {
                    case "Nome":
                        {
                            nomeExib = driver.FindElement(By.XPath("/html/body/web-agendamento/div[1]/div/div[2]/ul/li[1]/div/span")).Text;
                            driver.FindElement(By.XPath("//*[@id=\"dropdownMenu2\"]")).Click();
                            driver.FindElement(By.XPath("//*[@id=\"menu-sair\"]")).Click();

                            if (nomeExib == ("Olá, " + nome))
                                return "SUCESSO";
                            else
                                return "FALHA";
                        }
                    case "Senha":
                        {
                            if (nomeExib != ("Olá, " + nome))
                                return "SUCESSO";
                            else
                                return "FALHA";
                        }
                    default:
                        return "FALHA";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "FALHA";
            }
        }
    }
}
