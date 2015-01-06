using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UsandoAJAX
{
    /// <summary>
    /// Summary description for Noticias
    /// </summary>
    public class Noticias : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            StringBuilder html = new StringBuilder();
            string filtro = context.Request.QueryString["filtro"].TrimEnd();
            using (DatabaseEntities db = new DatabaseEntities())
            { /*AppendFormat permite uso de curingas*/
                foreach (Noticia item in db.Noticias.Where(
                    x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) ||
                     x.Texto.ToUpper().Contains(filtro.ToUpper())))
                {
                    html.AppendFormat("<h3>{0}</h3>", item.Titulo);
                    html.AppendFormat("<p>{0}</p>", item.Texto);
                    html.Append("<hr/>");
                }
            }
            context.Response.Write(html);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}