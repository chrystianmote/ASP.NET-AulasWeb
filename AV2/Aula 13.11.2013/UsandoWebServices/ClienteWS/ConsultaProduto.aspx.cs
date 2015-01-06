using ClienteWS.UNES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWS
{
    public partial class ConsultaProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_ServerClick(object sender, EventArgs e)
        {
            ServicesSoapClient  ws = new UNES.ServicesSoapClient();
            //decimal resultado = ws.ObterValor(Convert.ToInt32(txtCodigo.Value));
            //spnPreco.InnerText = resultado.ToString("C");

            Produto resultado = ws.ObterProduto(Convert.ToInt32(txtCodigo.Value));
            spnPreco.InnerHtml = string.Format("Produto: {0}<br/> Preço: {1:C}",
                resultado.Nome, resultado.Preco);
        }
    }
}