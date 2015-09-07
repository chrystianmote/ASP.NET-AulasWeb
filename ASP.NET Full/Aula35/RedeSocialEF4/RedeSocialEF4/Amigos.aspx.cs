using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedeSocialEF4
{
    public partial class Amigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    AtualizarListaAmigos();
                }
                else
                {
                    Session["info"] =
                        "É preciso estar logado para ver seus amigos.";
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        private void AtualizarListaAmigos()
        {
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                //captura o objeto que representa o usuário logado
                Usuario logado = ctx.Usuarios.SingleOrDefault(
                    x => x.Email == Page.User.Identity.Name);
                //obtém todos os amigos do usuário logado, incluindo
                //os que ele convidou e os que solicitaram ele
                var amigos = logado.Solicitantes.Union(
                    logado.Convidados);
                //atribui os amigos obtidos à lista lvAmigos
                lvAmigos.DataSource = amigos;
                lvAmigos.DataBind();
            }
        }

        protected void lvAmigos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Libertar")
            {
                int idUsuario = Convert.ToInt32(
                    e.CommandArgument);

                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    //captura o usuário cujo botão "Libertar" foi clicado
                    Usuario usuario = ctx.Usuarios.SingleOrDefault(
                        x => x.Id == idUsuario);
                    //captura o usuário logado
                    Usuario logado = ctx.Usuarios.SingleOrDefault(
                        x => x.Email == Page.User.Identity.Name);
                    //se o usuário clicado está na lista de solicitados 
                    //do usuário logado, remove-o da lista
                    if (logado.Solicitantes.Contains(usuario))
                        logado.Solicitantes.Remove(usuario);
                    //se o usuário clicado está na lista de convidados
                    //do usuário logado, remove-o da lista
                    if (logado.Convidados.Contains(usuario))
                        logado.Convidados.Remove(usuario);
                    //aplica as alterações no banco de dados
                    ctx.SaveChanges();
                    //atualiza a lista de amigos
                    AtualizarListaAmigos();
                    //mostra mensagem informando que a operação foi ok
                    Session["info"] = string.Format(
                        "O ser \"{0}\" foi libertado com sucesso!",
                        usuario.Nome);
                }
            }
        }
    }
}