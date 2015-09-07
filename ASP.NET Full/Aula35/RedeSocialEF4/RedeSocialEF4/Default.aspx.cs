using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;

namespace RedeSocialEF4
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //verifica se usuário está logado
            if (Page.User.Identity.IsAuthenticated)
            {
                //captura o componente que mostra a lista de amigos
                ListView lvAmigos = (ListView)lvPrincipal.FindControl(
                    "lvAmigos");
                //cria um novo contexto do BD
                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    //captura o objeto do usuário logado
                    var logado = ctx.Usuarios.SingleOrDefault(
                        x => x.Email == Page.User.Identity.Name);
                    //obtém a lista de amigos, unindo os
                    //solicitantes aos convidados
                    var amigos = logado.Solicitantes.Union(
                        logado.Convidados);
                    //obtém os 6 primeiros amigos da lista,
                    //ordenados pela data de acesso, da mais
                    //atual para a mais antiga
                    lvAmigos.DataSource = amigos.OrderByDescending(
                        x => x.DataAcesso).Take(6);
                    lvAmigos.DataBind();
                    //monta o HTML de dados do usuário
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<h2>Seu Perfil</h2>");
                    sb.Append(string.Format(
                        "<img src=\"Fotos/{0}.jpg\" />",
                        logado.Id.ToString("d6")));
                    sb.Append(string.Format(
                        "<h3>Bem-vindo, {0}!</h3>",
                        logado.Nome));
                    sb.Append(string.Format(
                        "<p>E-mail: <a href=\"mailto:{0}\">{0}</a></p>",
                        logado.Email));
                    sb.Append(string.Format(
                        "<p>Data de Nascimento: {0}</p>",
                        logado.DataNascimento.ToShortDateString()));
                    sb.Append(string.Format(
                        "<p>Data de Cadastro: {0}</p>",
                        logado.DataCadastro.ToShortDateString()));
                    //captura o label de que exibe dados do usuário
                    Label lblDadosUsuario = (Label)
                        lvPrincipal.FindControl("lblDadosUsuario");
                    //joga o HTML gerado para o label capturado
                    lblDadosUsuario.Text = sb.ToString();
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