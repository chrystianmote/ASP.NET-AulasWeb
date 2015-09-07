using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ExemplosAula13Tarde
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Produto> produtos = (List<Produto>)Application["produtos"];

            StringBuilder sb = new StringBuilder();
            foreach (var p in produtos)
            {
                sb.Append(p.Nome);
                sb.Append("<br/><a href='DetalhesProduto.aspx?codigo=");
                sb.Append(p.ID.ToString());
                sb.Append("'>Detalhes</a><br/><br/>");
            }

            lblCatalogo.Text = sb.ToString();
        }
    }
}
