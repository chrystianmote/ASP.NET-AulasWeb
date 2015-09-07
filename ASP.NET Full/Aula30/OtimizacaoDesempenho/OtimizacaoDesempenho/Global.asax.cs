using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;
using System.IO;

namespace OtimizacaoDesempenho
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            if (Server != null)
            {
                Exception ex;
                //Captura a última exceção ocorrida, percorrendo todas as sub-exceções (internas) da exceção ocorrida
                for (ex = Server.GetLastError(); ex != null; ex = ex.InnerException)
                {
                    message.AppendFormat("{0}: {1}{2}",
                    ex.GetType().FullName,
                    ex.Message,
                    ex.StackTrace);
                }
                //faça alguma coisa com message
                message.AppendLine("URL: " + Request.Url.ToString());
                message.AppendLine("Navegador: " + Request.Browser.Browser);
                StreamWriter sw = new StreamWriter(Server.MapPath("~/") + "Erro.txt");
                sw.Write(message.ToString());
                sw.Close();
            }

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        public override string GetVaryByCustomString(
        HttpContext context, string arg)
        {
            // Verifica o tipo de Caching utilizado
            if (arg == "browser")
            {
                // Determina o navegador atual.
                string browserName;
                browserName = Context.Request.Browser.Browser;
                browserName += Context.Request.Browser.MajorVersion.ToString();
                // indica que essa string deve ser usada para variar o Caching
                return browserName;
            }
            else
            {
                return base.GetVaryByCustomString(context, arg);
            }
        }

    }
}