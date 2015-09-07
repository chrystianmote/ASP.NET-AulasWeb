using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedeSocialEF4
{
    public partial class NaoAmigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    using (RedeSocialEntities ctx = new RedeSocialEntities())
                    {
                        //captura o objeto do usuário logado
                        Usuario logado = ctx.Usuarios.SingleOrDefault(
                            x => x.Email == Page.User.Identity.Name);
                        //captura todos os usuários que não
                        //são amigos do usuário logado
                        var naoAmigos = ctx.Usuarios.Where(
                            x => (x.Solicitantes.Count(
                                s => s.Id == logado.Id) <= 0) &&
                                (x.Convidados.Count(
                                c => c.Id == logado.Id) <= 0)).
                                Where(x => x.Id != logado.Id);
                        //atribui a coleção de não amigos à lista
                        lvNaoAmigos.DataSource = naoAmigos;
                        lvNaoAmigos.DataBind();
                    }
                }
            }
        }

        protected void lvNaoAmigos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Abduzir")
            {
                int idUsuario = Convert.ToInt32(
                    e.CommandArgument);

                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    Usuario logado = ctx.Usuarios.SingleOrDefault(
                        x => x.Email == Page.User.Identity.Name);

                    Usuario novoAmigo = ctx.Usuarios.SingleOrDefault(
                        x => x.Id == idUsuario);

                    logado.Convidados.Add(novoAmigo);

                    ctx.SaveChanges();

                    Session["info"] = string.Format(
                        "O ser \"{0}\" foi abduzido com sucesso!",
                        novoAmigo.Nome);

                    Response.Redirect("~/Amigos.aspx");
                }
            }
        }
    }
}