using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace RedeSocialEF4
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                ListView lvAmigos = (ListView)lvPrincipal.FindControl(
                    "lvAmigos");

                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {

                    var logado = ctx.Usuarios.SingleOrDefault(
                        x => x.Email == Page.User.Identity.Name);

                    var amigos = logado.Solicitantes.Union(
                        logado.Convidados);

                    lvAmigos.DataSource = amigos.Take(9);
                    lvAmigos.DataBind();
                }
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //captura os controles dentro do LoginView
            TextBox txtEmail = (TextBox)
                lvPrincipal.FindControl("txtEmail");
            TextBox txtSenha = (TextBox)
                lvPrincipal.FindControl("txtSenha");

            //o using libera o objeto usado após o término do bloco
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                //captura o objeto Usuario cujo e-mail foi 
                //informado na área de login
                Usuario user = ctx.Usuarios.SingleOrDefault(
                    u => u.Email == txtEmail.Text);
                //se encontrou um usuário com o e-mail informado...
                if (user != null)
                {
                    //aplica hash à senha digitada
                    string senha = FormsAuthentication.
                        HashPasswordForStoringInConfigFile(
                        txtSenha.Text, "SHA1");
                    //compara a senha hasheada com a do usuário
                    if (user.Senha == senha)
                    {
                        //autentica o usuário...
                        FormsAuthentication.SetAuthCookie(
                            txtEmail.Text, true);
                        Response.Redirect("~/Albuns.aspx");
                    }
                    else
                    {
                        Session["info"] = "Senha inválida!";
                    }
                }
                else
                {
                    Session["info"] =
                        "Não existe usuário com este e-mail.";
                }
            }
        }
    }
}