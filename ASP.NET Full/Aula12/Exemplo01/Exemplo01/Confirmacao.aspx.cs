using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exemplo01
{
    public partial class Confirmacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Registro reg = (Registro)Session["registro"];
            divDados.InnerHtml =
                "Nome: " + reg.Nome + "<br/>" +
                "UF: " + reg.UF + "<br/>" +
                "Cidade: " + reg.Cidade + "<br/>" +
                "Capital: " + (reg.Capital ? "Sim" : "Não") + "<br/>" +
                "População: " + reg.Populacao.ToString() + "<br/>" +
                "Data de Emancipação: " + reg.DataEmancipacao.ToString("dd/mm/yyyy");
        }
    }
}
