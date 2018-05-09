using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NaoraTeste.Util
{
    public class SendEmail
    {
        public static NetworkCredential login;
        public static SmtpClient client;
        public static MailMessage msg;

        public static void EmailProperties(string caminho, string mailto)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("naoratesteavila@gmail.com");
                mail.To.Add(mailto);
                mail.Subject = "Relatório de Execucao de Testes";
                mail.Body = "Em anexo relatório de testes Naora.";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(caminho + @"RelatorioResultado\Relatorio.pdf");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("naoratesteavila", "naorateste");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }       
}
