using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NaoraTeste.Util
{
    public class DocumentoPDF
    {
        public static DateTime thisDay = DateTime.Today;
        public static Document document = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada

        public static void CriandoDocumento(string caminho)
        {
            document.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            document.AddCreationDate();//adicionando as configuracoes

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(caminho + @"\RelatorioResultado\Relatorio.pdf", FileMode.Create));
            document.Open();

            var font = FontFactory.GetFont("Calibri", 20);
            font.SetStyle("bold");

            var font2 = FontFactory.GetFont("Calibri", 18);
            font2.SetStyle("bold");

            // Figuras geométricas.
            var contentByte = writer.DirectContent;

            // Imagem.
            var cabecalho = Image.GetInstance(caminho + "images" + @"\cabecalho.jpg");
            cabecalho.ScaleToFit(600, 300);
            cabecalho.SetAbsolutePosition(0, 760);
            contentByte.AddImage(cabecalho);

            var image = Image.GetInstance(caminho + "images" + @"\avilalogo.jpg");
            image.ScaleToFit(100, 75);
            image.SetAbsolutePosition(80, 740);
            contentByte.AddImage(image);

            // Textos.         
            var paragraph = new Paragraph("\n\n\nRelatório de execução de testes - Naora", font);
            paragraph.Alignment = Element.ALIGN_CENTER;
            document.Add(paragraph);

            //Data
            var data = new Paragraph("Data: "+thisDay.Day+"/"+thisDay.Month+"/"+thisDay.Year+"\n", font2);
            data.Alignment = Element.ALIGN_CENTER;
            document.Add(data);
        }

        public static void EscrevePDF(string caminho, string texto)
        {
            var font = FontFactory.GetFont("Calibri", 14);
            font.SetStyle("bold");
            var data = new Paragraph("\n" + texto, font);

            data.Alignment = Element.ALIGN_CENTER;
            document.Add(data);
        }

        public static void EscreveFalha(string caminho, string texto)
        {
            var font = FontFactory.GetFont("Calibri", 12);
            font.SetStyle("bold");
            font.SetColor(179, 36, 0);

            var data = new Paragraph(texto, font);
            data.Alignment = Element.ALIGN_CENTER;
            document.Add(data);
        }

        public static void EscreveResultado(string caminho, string texto)
        {
            var font = FontFactory.GetFont("Calibri", 14);
            font.SetStyle("bold");
            var data = new Paragraph(texto, font);

            data.Alignment = Element.ALIGN_CENTER;
            document.Add(data);
        }

        public static void AdicionaImagem(string caminho, string imagem)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(caminho + imagem + ".jpg");
            image.ScalePercent(25f);
            image.Alignment = Element.ALIGN_CENTER;
            document.Add(image);
        }

        public static void AdicionaTabela(int numSuites, int numFalhas, int numCasos)
        {
            var font = FontFactory.GetFont("Calibri", 14);
            font.SetStyle("bold");

            var fontTitulo = FontFactory.GetFont("Calibri", 14);
            fontTitulo.SetStyle("bold");
            fontTitulo.SetColor(255, 255, 255);

            var paragraph = new Paragraph("\n\n", font);
            paragraph.Alignment = Element.ALIGN_CENTER;
            document.Add(paragraph);

            float[] width = { 5, 1 };
            PdfPTable table = new PdfPTable(width);
            PdfPCell titulo = new PdfPCell(new Phrase("Total", fontTitulo));
            PdfPCell suite = new PdfPCell(new Phrase("Suites de Teste", font));
            PdfPCell numSuite = new PdfPCell(new Phrase(numSuites.ToString(), font));
            PdfPCell casos = new PdfPCell(new Phrase("Casos de Teste", font));
            PdfPCell numbCasos = new PdfPCell(new Phrase(numCasos.ToString(), font));
            PdfPCell sucessos = new PdfPCell(new Phrase("Passed", font));
            PdfPCell numSucessos = new PdfPCell(new Phrase((numCasos - numFalhas).ToString(), font));
            PdfPCell falhas = new PdfPCell(new Phrase("Failed", font));
            PdfPCell numbFalhas = new PdfPCell(new Phrase(numFalhas.ToString(), font));

            titulo.Colspan = 3;
            titulo.HorizontalAlignment = Element.ALIGN_CENTER;
            titulo.BackgroundColor = GrayColor.DARK_GRAY;
            table.AddCell(titulo);

            suite.HorizontalAlignment = Element.ALIGN_CENTER;
            numSuite.HorizontalAlignment = Element.ALIGN_CENTER;
            casos.HorizontalAlignment = Element.ALIGN_CENTER;
            numbCasos.HorizontalAlignment = Element.ALIGN_CENTER;
            sucessos.HorizontalAlignment = Element.ALIGN_CENTER;
            numSucessos.HorizontalAlignment = Element.ALIGN_CENTER;
            falhas.HorizontalAlignment = Element.ALIGN_CENTER;
            numbFalhas.HorizontalAlignment = Element.ALIGN_CENTER;

            table.AddCell(suite);
            table.AddCell(numSuite);
            table.AddCell(casos);
            table.AddCell(numbCasos);
            table.AddCell(sucessos);
            table.AddCell(numSucessos);
            table.AddCell(falhas);
            table.AddCell(numbFalhas);

            document.Add(table);
        }

        public static void PrintScreen(string caminho, IWebDriver driver, string tipo, int i)
        {
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            screenShot.SaveAsFile(caminho + @"Images\Screenshots\SeleniumTestingScreenshot" + tipo + i.ToString() + ".jpg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
        }

        public static void AdicionaPaginaNum(string caminho)
        {
            byte[] bytes = File.ReadAllBytes(caminho + @"\RelatorioResultado\Relatorio.pdf");
            Font blackFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader reader = new PdfReader(bytes);
                using (PdfStamper stamper = new PdfStamper(reader, stream))
                {
                    int pages = reader.NumberOfPages;
                    for (int i = 1; i <= pages; i++)
                    {
                        ColumnText.ShowTextAligned(stamper.GetUnderContent(i), Element.ALIGN_RIGHT, new Phrase(i.ToString(), blackFont), 568f, 15f, 0);
                    }
                }
                bytes = stream.ToArray();
            }
            File.WriteAllBytes(caminho + @"\RelatorioResultado\Relatorio.pdf", bytes);
        }

        public static void FechaDocumento()
        {
            document.Close();
        }
    }
}
