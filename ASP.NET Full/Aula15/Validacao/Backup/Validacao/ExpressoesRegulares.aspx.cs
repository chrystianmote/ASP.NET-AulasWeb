using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validacao
{
    public partial class ExpressoesRegulares : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDefinirER_Click(object sender, EventArgs e)
        {
            revDinamico.ValidationExpression = txtNovaER.Text;
            lblERAtual.Text = "Expressão regular atual: ";
            lblERAtual.Text += txtNovaER.Text;
            txtNovaER.Text = "";

        }
    }
}
