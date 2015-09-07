using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceUser
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //cria uma instância do serviço
            eCommerceService.ConsultaProdutoWS srv =
                new eCommerceService.ConsultaProdutoWS();
            //utiliza o método disponibilizado pelo serviço
            lblPreco.Text = srv.ObterPreco(Convert.ToInt32(
                txtIdProduto.Text)).ToString("c");
        }
    }
}