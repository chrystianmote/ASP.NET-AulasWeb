using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace RedeSocialEF4
{
    public partial class Albuns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se o usuário estiver logado...
            if (Page.User.Identity.IsAuthenticated)
            {
                //se for o primeiro carregamento da página
                if (!Page.IsPostBack)
                {
                    //se há um IdUsuario na URL, é porque o usuário logado
                    //está tentando ver os álbuns de outro usuário
                    if (Request.QueryString["IdUsuario"] != null)
                    {
                        //captura o IdUsuario dono do álbum da URL 
                        int idUsuario = Convert.ToInt32(
                            Request.QueryString["IdUsuario"]);
                        AtualizarListaAlbuns(idUsuario);
                        //oculta o link para cadastrar novo álbum
                        hlCadastrarAlbum.Visible = false;
                    }
                    //se o usuário estiver querendo ver seus próprios álbuns
                    else
                    {
                        //cria o contexto do BD
                        using (RedeSocialEntities ctx = new RedeSocialEntities())
                        {
                            //captura o objeto do usuário logado
                            Usuario logado = ctx.Usuarios.SingleOrDefault(
                                x => x.Email == Page.User.Identity.Name);
                            //atribui os álbuns do usuário logado
                            //ordenados pela data de criação de forma
                            //descendente
                            lvAlbuns.DataSource =
                                ctx.Albuns.OrderByDescending(
                                x => x.DataCriacao).Where(
                                x => x.IdPessoa == logado.Id);
                            lvAlbuns.DataBind();
                            //altera o título da página
                            tituloAlbum.InnerText = "Meus Álbuns de Fotos";
                            //esconde o label que mostra o nome do dono do álbum
                            lblUsuario.Visible = false;
                        }
                    }
                }
            }
            //se o usuário não estiver autenticado...
            else
            {
                //mostra mensagem e redireciona
                Session["info"] =
                    "Você precisa estar logado para manipular os álbuns.";
                Response.Redirect("~/Default.aspx");
            }
        }

        private void AtualizarListaAlbuns(int idUsuario)
        {
            //cria um contexto do BD
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                //atribui os álbuns do ser cujo Id veio
                //na URL ordenados pela data de cadastro 
                //de forma descendente
                lvAlbuns.DataSource =
                    ctx.Albuns.OrderByDescending(
                    x => x.DataCriacao).Where(
                    x => x.IdPessoa == idUsuario);
                lvAlbuns.DataBind();
                //captura o objeto do usuário dono do álbum
                Usuario usuario = ctx.Usuarios.SingleOrDefault(
                    x => x.Id == idUsuario);
                //mostra o nome do dono do álbum
                lblUsuario.Text = usuario.Nome + "</br>";
            }
        }

        protected void lvAlbuns_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //se o item renderizado é um item de dados
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //captura a imagem da capa do item do listview
                HtmlImage capa = (HtmlImage)e.Item.FindControl(
                    "imgCapaAlbum");
                //obtem o item de dados convertendo-o para Album,
                //que é o tipo de dados dos itens vinculados
                //ao listview
                Album dataItem =
                    (Album)e.Item.DataItem;

                //captura o botão excluir do álbum
                Button btnExcluir =
                    (Button)e.Item.FindControl("btnExcluir");

                //instancia o contexto...
                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    if (ctx.Albuns.Where(x => x.Id == dataItem.Id).
                        SingleOrDefault().Fotos.Count > 0)
                    {
                        //captura a primeira foto do Album do item
                        //que está sendo renderizado
                        Foto foto = ctx.Albuns.Where(
                            x => x.Id == dataItem.Id).SingleOrDefault().
                            Fotos.First();
                        //altera a url da imagem da capa para o valor
                        //formado pelo id da primeira foto do álbum
                        capa.Src = "~/FotosAlbuns/" +
                            foto.Id.ToString("d9") + ".jpg";
                    }
                    //se o álbum ainda não possui fotos...
                    else
                    {
                        //altera a url da imagem da capa para o valor
                        //padrão para álbuns sem fotos
                        capa.Src = "~/FotosAlbuns/AlbumVazio.jpg";
                    }

                    //captura o objeto do usuário logado
                    Usuario logado = ctx.Usuarios.SingleOrDefault(
                        x => x.Email == Page.User.Identity.Name);
                    //verifica se o usuário logado é dono do álbum e,
                    //caso não seja, oculta o botão de exclusão do álbum
                    if (dataItem.IdPessoa != logado.Id)
                        btnExcluir.Visible = false;
                }
            }
        }

        protected void lvAlbuns_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //verifica se o comando é de exclusão
            if (e.CommandName == "Excluir")
            {
                //captura o id do álbum a ser excluído, vindo
                //do argumento do botão clicado
                int idAlbum = Convert.ToInt32(e.CommandArgument);
                //instancia o contexto que representa o BD
                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    //para cada foto do álbum
                    Album album = ctx.Albuns.SingleOrDefault(
                        x => x.Id == idAlbum);
                    //enquanto houver foto no álbum                
                    while (album.Fotos.Count > 0)
                    {
                        //se o arquivo de foto existe...
                        if (File.Exists(Server.MapPath("~/FotosAlbuns/") +
                                album.Fotos.First().Id.ToString("d9") + ".jpg"))
                        {
                            //exclui o arquivo da primeira foto
                            File.Delete(Server.MapPath("~/FotosAlbuns/") +
                                album.Fotos.First().Id.ToString("d9") + ".jpg");
                        }
                        //exclui a primeira foto do álbum
                        ctx.Fotos.DeleteObject(album.Fotos.First());
                    }
                    //aplica as alterações no BD
                    ctx.SaveChanges();
                    //exclui o álbum em si                   
                    ctx.Albuns.DeleteObject(album);
                    //aplica as alterações no BD
                    ctx.SaveChanges();
                    //mostra mensagem ao usuário
                    Session["info"] = "Álbum excluído com sucesso!";
                    //atualiza a lista de álbuns                    
                    AtualizarListaAlbuns(album.IdPessoa);
                }
            }
        }
    }
}