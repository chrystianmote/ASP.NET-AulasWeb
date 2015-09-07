using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace eCommerceFrontEnd
{
    public class eCommerceUtil
    {
        public static bool UrlExiste(string url)
        {
            bool urlExiste = false;
            WebRequest req = WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                urlExiste = true;
            }
            catch (System.Net.WebException ex)
            {
            }
            return urlExiste;
        }

        public static void EnviarEmail(string destinatario,
            string assunto, string corpo)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(destinatario));
            MailAddress remetente = new MailAddress(
                "ecommerce@softmark.com.br",
                "Softmark e-Commerce");
            msg.From = remetente;
            msg.Subject = assunto;
            msg.Body = corpo;
            
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
        }
    }
}
