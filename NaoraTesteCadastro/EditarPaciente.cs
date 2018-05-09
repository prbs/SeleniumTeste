using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaoraTestePerfilUsuario
{
    public class EditarPaciente
    {



        public static void editarPaciente(IWebDriver driver, string email, string senha)
        {




            if (true)
            {
            }

            while (!driver.FindElement(By.CssSelector("input[formcontrolname='nome']")).Displayed)
            {

                System.Threading.Thread.Sleep(1000);
            }

            IWebElement txtNome = driver.FindElement(By.CssSelector("input[formcontrolname='nome']"));
            txtNome.Clear();
            txtNome.SendKeys("Nome editado");



            while (!driver.FindElement(By.CssSelector("input[formcontrolname='dataNascimento']")).Displayed)
            {

                System.Threading.Thread.Sleep(1000);
            }

            IWebElement txtDataNascimento = driver.FindElement(By.CssSelector("input[formcontrolname='dataNascimento']"));
            txtDataNascimento.Clear();
            txtDataNascimento.SendKeys("18121993");



            while (!driver.FindElement(By.CssSelector("input[formcontrolname='celular']")).Displayed)
            {

                System.Threading.Thread.Sleep(1000);
            }

            IWebElement txtCelular = driver.FindElement(By.CssSelector("input[formcontrolname='celular']"));
            txtCelular.Clear();
            txtCelular.SendKeys("81943214321");



            while (!driver.FindElement(By.CssSelector("input[value='Masculino']")).Displayed)
            {

                System.Threading.Thread.Sleep(1000);
            }

            IWebElement rdSexo = driver.FindElement(By.CssSelector("input[value='Masculino']"));
            rdSexo.Click();


            while (!driver.FindElement(By.CssSelector("input[value='consulta-particular']")).Displayed)
            {

                System.Threading.Thread.Sleep(1000);
            }

            IWebElement rdTipoConsulta = driver.FindElement(By.CssSelector("input[value='consulta-particular']"));
            rdTipoConsulta.Click();

            IWebElement btnSalvar = driver.FindElement(By.CssSelector("button.naora-btn"));
            btnSalvar.Click();

            //espera alerta de salva as alteracoes
            while (!driver.FindElement(By.CssSelector("div.simple-notification.sucess")).Displayed)
            {

                System.Threading.Thread.Sleep(1000);
            }

            
        }




    }
}
