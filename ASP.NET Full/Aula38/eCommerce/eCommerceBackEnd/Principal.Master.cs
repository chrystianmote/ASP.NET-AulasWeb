using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace eCommerceBackEnd
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //se há uma mensagem na sessão do usuário...
            if (Session["info"] != null)
            {
                //registra um javascript para mostrar a mensagem
                Page.ClientScript.RegisterStartupScript(
                    typeof(Page), "info",
                    "alert('" + Session["info"].ToString() +
                    "');", true);
                //remove a mensagem da sessão
                Session["info"] = null;
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            //captura o campo de e-mail do formulário de login
            TextBox txtEmail = (TextBox)lvLoginForm.FindControl("txtLoginEmail");
            //captura o campo de senha do formulário de login
            TextBox txtSenha = (TextBox)lvLoginForm.FindControl("txtLoginSenha");
            //obtém o usuário membership cujo e-mail foi informado
            if (Membership.GetUser(txtEmail.Text) != null)
            {
                //se o perfil do usuário for administrador ou vendedor
                if ((Roles.IsUserInRole(txtEmail.Text, "administrador")) ||
                    (Roles.IsUserInRole(txtEmail.Text, "vendedor")))
                {
                    //se o login e senha forem válidos...
                    if (Membership.ValidateUser(txtEmail.Text, txtSenha.Text))
                    {
                        //cria o cookie de autenticação
                        FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, true);
                        //grava mensagem para o usuário
                        Session["info"] = "Você está logado!";
                    }
                    //se login e/ou senha não forem válidos
                    else
                    {
                        //grava mensagem para o usuário
                        Session["info"] = "Senha incorreta!";
                    }
                }
                //se o usuário não está no perfil permitido...
                else
                {
                    //grava mensagem para o usuario
                    Session["info"] = string.Format("O usuário {0} não possui permissão para administrar o site.",
                        txtEmail.Text);
                }
            }
            //se não há usuário com o e-mail informado...
            else
            {
                //grava mensagem para o usuário
                Session["info"] = string.Format("O usuário {0} não existe no sistema.",
                    txtEmail.Text);
            }
        }
    }
}