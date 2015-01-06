using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HtmlCssJScript_SistSolar
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Olá!");
            aLink.InnerText = "HTML Server Control";
            aLink.HRef = "http://www.google.com.br";
            btnClicar.Text = "Texto gerado pelo C#";
        }

        protected void btnClicar_Click(object sender, EventArgs e)
        {
            Response.Write(string.Format("<script>alert(\"Você clicou no botão em {0} \")</script>", DateTime.Now.ToString()));
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantidade.Text != null)
                {
                    int Valor = Convert.ToInt32(rblSexo.SelectedValue);
                    int Quantidade = Convert.ToInt32(txtQuantidade.Text);
                    lblTotal.Text = "O valor total é de: " + (Valor * Quantidade).ToString();
                }
            }
            catch (Exception z)
            {
                //Response.Write(z);
                Response.Write("<script>alert(\"Insira um valor para ser calculado.\")</script>");
            }

        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx");
        }
    }
}