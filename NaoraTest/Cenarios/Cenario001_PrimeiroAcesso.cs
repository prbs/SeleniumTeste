using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using AvilaCore;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using NaoraTeste.Util;
using NaoraTest.perfilUsuario;
using log4net.Config;
using log4net;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.InteropServices;

namespace NaoraTeste.Cenarios
{
    [TestClass]
    public class Cenario001_PrimeiroAcesso
    {
        string BaseUrl = "https://naorahomolog.azurewebsites.net/criar-conta";
        string LoginUrl = "https://naorahomolog.azurewebsites.net/login";

        int numLinhas, numColunas, contTesteSucesso = 0, contTesteFalha = 0;
        string nome, email, senha, dataNascimento, celular, resultadoTeste, tipo, plano;

        [TestMethod]
        public int Login(string caminho)
        {
            int qtdFalhas;
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            IWebDriver driver = new FirefoxDriver();

            numLinhas = IntegracaoExcel.NumLinhas(caminho, "Login");
            DocumentoPDF.EscrevePDF(caminho, "Login\n" + "Total de testes - " + (numLinhas-1).ToString());

            for (int i = 2; i <= numLinhas; i++)
            {
               driver.Navigate().GoToUrl(LoginUrl);

               tipo = IntegracaoExcel.LeTabela(caminho, "Login", i, 1);
               nome = IntegracaoExcel.LeTabela(caminho, "Login", i, 2);
               email = IntegracaoExcel.LeTabela(caminho, "Login", i, 3);
               senha = IntegracaoExcel.LeTabela(caminho, "Login", i, 4);

               resultadoTeste = TestCase002_Login.Login(driver, caminho, tipo, email, senha, nome);

               DocumentoPDF.PrintScreen(caminho, driver, "Login", i);

               IntegracaoExcel.EscreveTabela(caminho,"Login", i, 5, resultadoTeste);

                if (resultadoTeste == "SUCESSO")
                {
                    contTesteSucesso++;
                }
                else
                {
                    contTesteFalha++;
                    DocumentoPDF.AdicionaImagem(caminho, @"Images\Screenshots\SeleniumTestingScreenshotLogin" + i.ToString());
                    DocumentoPDF.EscreveFalha(caminho, tipo + ": " + nome + ", " + email + ", " + senha);
                }                
            }

            IntegracaoExcel.FechaArquivo(caminho, "Login");
            DocumentoPDF.EscreveResultado(caminho, "Passed: " + (numLinhas-1-contTesteFalha).ToString() + " / Failed: " + contTesteFalha.ToString());

            qtdFalhas = contTesteFalha;
            contTesteFalha = 0;
            contTesteSucesso = 0;

            driver.Close();

            return qtdFalhas;
        }
    }
}
