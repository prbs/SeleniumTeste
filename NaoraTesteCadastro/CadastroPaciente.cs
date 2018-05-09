using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using AvilaCore;
using System.IO;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace NaoraTesteCadastro
{
    [TestClass]
    public class CadastroPaciente
    {



        public static void cadastrar(IWebDriver driver, string baseUrl, string nome, string email, string senha, string dataNascimento, string celular, Enum sexo, string caminhoDiretorio, string caminhoMidia)
        {



            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            //----------------------------------- esperando tag 'a' login estar pronto para ser clicado
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.header-titulo-login.right>ul.nav>li>div.row:last-child>div>a")));

            while (!driver.FindElement(By.CssSelector("div.header-titulo-login.right>ul.nav>li>div.row:last-child>div>a")).Displayed)
            {
                System.Threading.Thread.Sleep(1000);
            }


            ///------------------- procurando login
            IWebElement login = driver.FindElement(By.CssSelector("div.header-titulo-login.right>ul.nav>li>div.row:last-child>div>a"));
            login.Click();

            //---------------------------- esperando butao de cadastrar estar pronto para ser clicado
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.campo-div-2.botao-criar.form-control.drop-shadow-back")));

            IWebElement btnCadastrar = driver.FindElement(By.CssSelector("button.campo-div-2.botao-criar.form-control.drop-shadow-back"));

            btnCadastrar.Click();





            //---------------------------- cadastrando formulario com os dados do paciente 

            //------------------ verifica se existe o diretorio  
            /*
                        var listaImagens = Directory.EnumerateFiles(@caminhoDiretorio + "/" + @caminhoMidia).Select(Path.GetFileName);
                        int indexImage = 0;

                        for (int i = 0; i < listaImagens.ToArray().Length; i++)
                        {
                            if (listaImagens.ToArray()[i].Split('.')[0].Equals(sexo.ToString()))
                            {
                                indexImage = i;
                            }
                        }

                        var testa = listaImagens.ToArray()[indexImage];
                        testa = caminhoDiretorio + @"/" + @caminhoMidia + @"/" + testa;

                        IWebElement imagemPaciente = driver.FindElement(By.Id("input-file"));
                        imagemPaciente.SendKeys( testa);

                        driver.FindElement(By.CssSelector("label[for='input-file']")).Click();
                        var a = 1;
                        driver.FindElement(By.CssSelector("label[for='input-file']")).Submit();
                        IJavaScriptExecutor jsScript = driver as IJavaScriptExecutor;
                        //Robot robot = new Robot();
                        // change body to the element where you'd like to execute the escape key press")
                        // change body to the element where you'd like to execute the escape key press
                        //driver.FindElement(By.CssSelector("button.btn-modal-criar-conta")).Click();

                */


            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("full-name")));
            IWebElement txtNome = driver.FindElement(By.Id("full-name"));



            while (!txtNome.Displayed)
            {
                System.Threading.Thread.Sleep(1000);
            }

            txtNome.Clear();
            txtNome.SendKeys(nome);


            IWebElement txtEmail = driver.FindElement(By.Id("email"));
            txtEmail.Clear();
            txtEmail.SendKeys(email);


            IWebElement txtEmailConfirm = driver.FindElement(By.Id("email-confirm"));
            txtEmailConfirm.Clear();
            txtEmailConfirm.SendKeys(email);


            IWebElement txtPassword = driver.FindElement(By.Id("password"));
            txtPassword.Clear();
            txtPassword.SendKeys(senha);

            IWebElement txtPasswordConfirm = driver.FindElement(By.Id("password-confirm"));
            txtPasswordConfirm.Clear();
            txtPasswordConfirm.SendKeys(senha);


            IWebElement txtBirthday = driver.FindElement(By.Id("birthday"));
            txtBirthday.Clear();
            txtBirthday.SendKeys(dataNascimento);

            IWebElement txtCelularNovo = driver.FindElement(By.Id("celularNovo"));
            txtCelularNovo.Clear();
            txtCelularNovo.SendKeys(celular);

            IWebElement rdSexo = driver.FindElement(By.CssSelector("input[formcontrolname='sexo']:first-child"));
            rdSexo.Click();

            IWebElement rdTipoConsulta = driver.FindElement(By.CssSelector("input[formcontrolname='tipoConsulta']:first-child"));
            rdTipoConsulta.Click();

            IWebElement rdTermoCompromisso = driver.FindElement(By.CssSelector("input[value='termoUso'"));
            rdTermoCompromisso.Click();

            IWebElement rdTipoPlano = driver.FindElement(By.CssSelector("input[formcontrolname='planoSaude']:first-child"));
            rdTipoPlano.Click();

            driver.FindElements(By.TagName("ng2-auto-complete"))[0].Click();

            IWebElement txtNumCarteira = driver.FindElement(By.CssSelector("input[formcontrolname='numeroCarteira']"));
            txtNumCarteira.Clear();
            txtNumCarteira.SendKeys("12323");

            IWebElement txtNumCarteiraVencimento = driver.FindElement(By.CssSelector("input[formcontrolname='vencimentoCarteira']"));
            txtNumCarteiraVencimento.Clear();

            var date = DateTime.Now.ToString("dd/MM/yyyy").Split('/');

            txtNumCarteiraVencimento.SendKeys(date[0] + "/" + date[1] + "/" + (Int32.Parse(date[2]) + 2).ToString());

            //---------------------------------------- butao cadastrar
            driver.FindElement(By.CssSelector("button.naora-btn.yellow.form-button")).Click();

            //------------------------------ clicar no btn de entrar apos ter cadastrado paciente

            //
            while (!driver.FindElement(By.CssSelector("button.naora-btn.yellow.top.form-button.drop-shadow-back")).Displayed)
            {
                System.Threading.Thread.Sleep(1000);
            }
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.naora-btn.yellow.top.form-button.drop-shadow-back")));

            driver.FindElement(By.CssSelector("button.naora-btn.yellow.top.form-button.drop-shadow-back")).Click();

        }

        public void Dropdown(IWebDriver driver, string dropdown_id, string value)
        {
            var crm = new SelectElement(driver.FindElement(By.Id(dropdown_id)));
            crm.SelectByValue(value);
        }
    }
}
