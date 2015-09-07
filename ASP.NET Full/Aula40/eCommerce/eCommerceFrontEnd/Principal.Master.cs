using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using eCommerceDAL;

namespace eCommerceFrontEnd
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    lvCategorias.DataSource =
                        ctx.Categorias.OrderBy(x => x.Descricao);
                    lvCategorias.DataBind();
                }
            }            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //se há uma mensagem em Session, exibe-a e remove-a
            if (Session["mensagem"] != null)
            {
                //o código a seguir foi substituído para que a mensagem 
                //seja exibida após a página ser carregada
                //Page.ClientScript.RegisterClientScriptBlock(typeof(Page),                
                Page.ClientScript.RegisterStartupScript(typeof(Page),
                    "info", "alert('" + Session["mensagem"].ToString() +
                    "');", true);
                Session["mensagem"] = null;
            }

            //se estiver na página do carrinho, não exibe o ícone no cabeçalho
            if (Request.Url.AbsolutePath != "/DetalhesCarrinho.aspx")
            {
                //atualiza o link do carrinho de compras
                if (Carrinho.Instancia.TemItens)
                {
                    imgCarrinho.Src = "~/Images/carrinho-cheio.png";
                    if (Carrinho.Instancia.QuantidadeTotal > 1)
                    {
                        imgCarrinho.Attributes["title"] =
                            Carrinho.Instancia.QuantidadeTotal.ToString() + " itens";
                    }
                    else
                    {
                        imgCarrinho.Attributes["title"] =
                            Carrinho.Instancia.QuantidadeTotal.ToString() + " item";
                    }
                }
                else
                {
                    imgCarrinho.Src = "~/Images/carrinho-vazio.png";
                    imgCarrinho.Attributes["title"] = " (carrinho vazio)";
                }
            }
            else
            {
                lnkCarrinho.Visible = false;
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            TextBox txtEmail = (TextBox)lvLoginForm.FindControl("txtLoginEmail");
            TextBox txtSenha = (TextBox)lvLoginForm.FindControl("txtLoginSenha");
            using (eCommerceEntities ctx = new eCommerceEntities())
            {
                var usuario = ctx.Usuarios.SingleOrDefault(
                    x => x.Email == txtEmail.Text);

                if (usuario != null)
                {
                    if (usuario.Senha == FormsAuthentication.
                        HashPasswordForStoringInConfigFile(txtSenha.Text, "SHA1"))
                    {
                        //faz o login e redireciona o usuário para a página
                        //que está na QueryString "ReturnUrl", caso haja
                        FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, true);
                        Session["mensagem"] = "Você está logado!";
                    }
                    else
                    {
                        Session["mensagem"] = "Senha incorreta!";
                    }
                    
                }
                else
                {
                    Session["mensagem"] = string.Format("O usuário {0} não existe no sistema.",
                        txtEmail.Text);
                }
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalogo.aspx?Busca=" + txtPesquisa.Text);
        }
    }
}
