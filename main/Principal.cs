using log4net;
using log4net.Config;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NaoraTeste;
using NaoraTeste.Cenarios;
using NaoraTeste.Util;

namespace main
{
    public class Principal
    {         
        public static string caminho = System.IO.Path.GetFullPath("ArquivosDados") + @"\";
        public static int numSuites = 0, numCasos = 0, numFalhas = 0;        
        public static int numCasosLogin = (IntegracaoExcel.NumLinhas(caminho, "Login") - 1); 

        public static Cenario001_PrimeiroAcesso primeiroAcesso = new Cenario001_PrimeiroAcesso();
        
        static void Main(string[] args)
        {
            DocumentoPDF.CriandoDocumento(caminho);

            //Paciente
            numFalhas = primeiroAcesso.Login(caminho); numSuites++;
            
            DocumentoPDF.AdicionaTabela(numSuites, numFalhas, numCasosLogin);
            DocumentoPDF.FechaDocumento();
            DocumentoPDF.AdicionaPaginaNum(caminho);

            //SendEmail.EmailProperties(caminho,"renatopaulobs@gmail.com");
        }
    }
}
