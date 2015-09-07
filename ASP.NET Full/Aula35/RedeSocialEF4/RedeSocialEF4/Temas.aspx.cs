using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedeSocialEF4
{
    public partial class Temas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                if (!Page.IsPostBack)
                {
                    AtualizarListaDeTemas();
                }
            }
            else
            {
                Session["info"] =
                    "Você só pode cadastrar temas se estiver logado.";

                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                Tema tema = new Tema();
                tema.Nome = txtNome.Text;
                ctx.Temas.AddObject(tema);
                ctx.SaveChanges();
                txtNome.Text = "";
                AtualizarListaDeTemas();
            }
        }

        private void AtualizarListaDeTemas()
        {
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                lvTemas.DataSource = ctx.Temas.OrderBy(
                    x => x.Nome);
                lvTemas.DataBind();
            }
        }

        protected void lvTemas_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    int idTema = Convert.ToInt32(e.CommandArgument);

                    if (ctx.Temas.SingleOrDefault(x => x.Id == idTema).
                        Albuns.Count == 0)
                    {
                        ctx.Temas.DeleteObject(
                            ctx.Temas.SingleOrDefault(x => x.Id == idTema));
                        ctx.SaveChanges();
                        AtualizarListaDeTemas();
                    }
                    else
                    {
                        Session["info"] = 
                            "Não é possível excluir um tema com álbuns relacionados.";
                    }
                }
            }
        }
    }
}
