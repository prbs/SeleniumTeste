using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AvilaCore;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using OpenQA.Selenium.Support.UI;
using NaoraTest.perfilUsuario;
using log4net.Config;
using log4net;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.InteropServices;

namespace NaoraTeste.Util
{
    public class IntegracaoExcel
    {
        public static Excel.Application xlApp = new Excel.Application();

        public static int NumLinhas(string caminho, string nomeTabela)
        {
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(caminho + nomeTabela + ".xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            xlWorkbook.Close();

            return rowCount;
        }

        public static int NumColunas(string caminho, string nomeTabela)
        {
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(caminho + nomeTabela + ".xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int colCount = xlRange.Columns.Count;
            xlWorkbook.Close();

            return colCount;
        }
        public static string LeTabela(string caminho, string nomeTabela, int linha, int coluna)
        {

            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(caminho + nomeTabela + ".xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            string leituraTabela = xlRange.Cells[linha, coluna].Value2.ToString();

            xlWorkbook.Close();
            return leituraTabela;
        }

        public static void EscreveTabela(string caminho, string nomeTabela, int linha, int coluna, string texto)
        {
            try
            {
                xlApp.Visible = false;
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(caminho + nomeTabela + ".xlsx");
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                xlWorksheet.Cells[linha, coluna] = texto;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                xlApp.Visible = false;
                xlApp.UserControl = false;

                xlWorkbook.Save();
                xlWorkbook.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public static void FechaArquivo(string caminho, string nomeTabela)
        {
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(caminho + nomeTabela + ".xlsx");

            xlWorkbook.Close();
            xlApp.Quit();
        }
    }
}
