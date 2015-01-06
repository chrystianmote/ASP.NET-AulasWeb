using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlCssJScript_SistSolar
{
    public partial class Cadastros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            Response.Write( "<script>var op = window.confirm(\"Deseja Efetuar o cadastro?\");if (op) {window.alert(\"Cadastro Efetuado com Sucesso!\");}else {window.alert(\"Repita o Cadastro!\");}</script>");
        }
    }
}