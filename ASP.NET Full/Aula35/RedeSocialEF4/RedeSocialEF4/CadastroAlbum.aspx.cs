using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedeSocialEF4
{
    public partial class CadastroAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se o usuário está autenticado
            if (Page.User.Identity.IsAuthenticated)
            {
                //se é o primeiro carregamento da página (não postback)
                if (!Page.IsPostBack)
                {
                    using (RedeSocialEntities ctx = new RedeSocialEntities())
                    {
                        //preenche o ddlTemas com os temas cadastrados
                        ddlTema.DataTextField = "Nome";
                        ddlTema.DataValueField = "Id";
                        ddlTema.DataSource = 
                            ctx.Temas.OrderBy(x => x.Nome);
                        ddlTema.DataBind();
                    }
                }
            }
            else
            {
                //se não está autenticado, dá uma mensagem
                Session["info"] =
                    "Você precisa estar logado para cadastrar um novo álbum.";

                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                //cria um novo objeto Album
                Album album = new Album();
                album.Nome = txtNome.Text;
                album.Descricao = txtDescricao.Text;
                album.IdTema = Convert.ToInt32(ddlTema.SelectedValue);
                album.DataCriacao = DateTime.Now;
                //preenche o IdPessoa com o Id do usuário logado
                album.IdPessoa = ctx.Usuarios.SingleOrDefault(
                    x => x.Email == Page.User.Identity.Name).Id;
                //adiciona o novo objeto à lista do contexto
                ctx.Albuns.AddObject(album);
                //aplica as alterações no BD
                ctx.SaveChanges();
                //grava mensagem a ser mostrada
                Session["info"] = "Álbum adicionado com sucesso!";
                //redirecina para a lista de álbuns
                Response.Redirect("~/Albuns.aspx");
            }
        }    
    }
}