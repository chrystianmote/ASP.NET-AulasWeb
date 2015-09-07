using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsandoAjax
{
    public partial class FormAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarClick(object sender, EventArgs e)
        {
            sqldsClientes.Insert();
            txtBairro.Text = "";
            txtCliente.Text = "";
            ddlEstados.SelectedIndex = 0;
        }
    }
}