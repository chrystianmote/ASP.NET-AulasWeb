using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CasasEstranhas.com
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                divLogin.Visible = false;
                divLogout.Visible = true;
            }
            else
            {
                divLogin.Visible = true;
                divLogout.Visible = false;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["info"] != null)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "info",
                    "alert('" + Session["info"].ToString() + "');", true);
                Session["info"] = null;
            }
        }

        protected void lvCategorias_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //captura o listview de exibição das casas da categoria
            //que está sendo renderizada
            ListView lv = e.Item.FindControl("lvCasasPorCategoria") as ListView;
            //captura o campo oculto que contém o código (id) da 
            //categoria que está sendo renderizada
            HiddenField hf = e.Item.FindControl("hdfIdCategoria") as HiddenField;

            //deve-se preencher o parâmetro de sqldsCasasPorCategoria
            sqldsCasasPorCategoria.SelectParameters["id_categoria"].DefaultValue =
                hf.Value;

            //deve-se associar o resultado de sqldsCasasPorCategoria ao lv capturado
            lv.DataSource = sqldsCasasPorCategoria.Select(
                DataSourceSelectArguments.Empty);
            lv.DataBind();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Usuario.Validar(txtUsuario.Value, txtSenha.Value) != null)
            {
                FormsAuthentication.SetAuthCookie("usuario", true);
                Session["info"] = "Você está logado.";
            }
            //para o codigo sem banco de dados funcionar, descomentar o codigo abaixo.
            //if ((txtUsuario.Value == "maroquio") &&
            //    (txtSenha.Value == "123456"))
            //{
            //    FormsAuthentication.RedirectFromLoginPage(
            //        txtUsuario.Value, true);
            //}
            //else
            //{
            //    Session["info"] = "Usuário e/ou senha inválido(s).";
            //}
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["info"] = "Logout realizado com sucesso.";
            //se for postback, ou seja, sem redirecionamento,
            //o código a seguir deve ser descomentado
            //divLogin.Visible = true;
            //divLogout.Visible = false;
            Response.Redirect("~/Default.aspx");
        }
    }
}
