using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace RedeSocialEF4
{
    public partial class Fotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se o usuário estiver logado
            if (Page.User.Identity.IsAuthenticated)
            {
                //se houver um IdAlbum na URL
                if (Request.QueryString["IdAlbum"] != null)
                {
                    //se for o primeiro carregamento da página
                    if (!Page.IsPostBack)
                    {
                        //atualiza a lista de fotos
                        AtualizarListaFotos();
                    }
                }
                //se não houver IdAlbum na URL
                else
                {
                    //volta para a página de álbuns
                    Response.Redirect("~/Albuns.aspx");
                }
            }
            //se não estiver logado...
            else
            {
                //grava uma mensagem para o usuário
                Session["info"] =
                    "Somente usuários logados podem ver fotos.";
                //redireciona para a página principal
                Response.Redirect("~/Default.aspx");
            }
        }

        private void AtualizarListaFotos()
        {
            //cria o contexto do BD
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                //captura o IdAlbum da URL
                int idAlbum = Convert.ToInt32(
                    Request.QueryString["IdAlbum"]);
                //atribui as fotos do álbum à lista
                lvFotos.DataSource = ctx.Fotos.Where(
                    x => x.IdAlbum == idAlbum);
                lvFotos.DataBind();
                //captura o objeto do álbum
                Album album = ctx.Albuns.SingleOrDefault(
                    x => x.Id == idAlbum);
                //mostra o nome do álbum no título
                h2Album.InnerText = album.Nome;
                //captura o objeto do usuário logado
                Usuario logado = ctx.Usuarios.SingleOrDefault(
                    x => x.Email == Page.User.Identity.Name);
                //se o dono do álbum não for o usuário logado
                if (logado.Id != album.Usuario.Id)
                {
                    //mostra o nome do dono do álbum
                    lblNomeDono.Text = "Pertencente à " +
                        album.Usuario.Nome;
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //se houver IdAlbum na URL
            if (Request.QueryString["IdAlbum"] != null)
            {
                //captura o IdAlbum da URL
                int idAlbum = Convert.ToInt32(
                    Request.QueryString["IdAlbum"]);
                //redireciona para a adição de fotos no álbum 
                //cujo Id veio na URL
                Response.Redirect("~/AdicaoFoto.aspx?IdAlbum=" +
                    idAlbum.ToString());
            }
        }

        protected void lvFotos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //se receber um comando "Excluir"
            if (e.CommandName == "Excluir")
            {
                //captura o Id da foto a excluir
                int idFoto = Convert.ToInt32(e.CommandArgument);
                //cria o contexto do BD
                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    //captura o objeto da foto
                    Foto foto = ctx.Fotos.SingleOrDefault(
                        x => x.Id == idFoto);
                    //se a foto possui comentários..
                    if (foto.Comentarios.Count > 0)
                        //limpa os comentários da foto
                        foto.Comentarios.Clear();
                    //exclui a foto
                    ctx.Fotos.DeleteObject(foto);
                    //aplica as alterações no BD
                    ctx.SaveChanges();
                    //grava mensagem par ao usuário
                    Session["info"] = "Foto excluída com sucesso!";
                    //atualiza a lista de fotos exibida
                    AtualizarListaFotos();
                    //exclui o arquivo da foto que foi excluída do contexto
                    if (File.Exists(Server.MapPath("~/FotosAlbuns/") +
                        foto.Id.ToString("d9") + ".jpg"))
                    {
                        File.Delete(Server.MapPath("~/FotosAlbuns/") +
                            foto.Id.ToString("d9") + ".jpg");
                    }
                }
            }
        }

        protected void lvFotos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //se for a renderização de um item de dados
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //se houver IdAlbum na URL
                if (Request.QueryString["IdAlbum"] != null)
                {
                    //captura o IdAlbum da URL
                    int idAlbum = Convert.ToInt32(
                        Request.QueryString["IdAlbum"]);
                    //cria um contexto do BD
                    using (RedeSocialEntities ctx = new RedeSocialEntities())
                    {
                        //captura o objeto do usuário logado
                        Usuario logado = ctx.Usuarios.SingleOrDefault(
                            x => x.Email == Page.User.Identity.Name);
                        //captura o objeto do álbum dono da foto
                        Album album = ctx.Albuns.SingleOrDefault(
                            x => x.Id == idAlbum);
                        //se o dono do álbum não for o usuário logado
                        if (album.IdPessoa != logado.Id)
                        {
                            //esconde o botão excluir
                            ((LinkButton)e.Item.FindControl("btnExcluir")).
                                Visible = false;
                        }
                    }
                }
            }
        }
    }
}