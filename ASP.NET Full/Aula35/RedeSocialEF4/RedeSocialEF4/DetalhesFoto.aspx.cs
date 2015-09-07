using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedeSocialEF4
{
    public partial class DetalhesFoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se o usuário estiver logado
            if (Page.User.Identity.IsAuthenticated)
            {
                //se for o primeiro carregamento da página
                if (!Page.IsPostBack)
                {
                    //se houver um IdFoto na URL
                    if (Request.QueryString["IdFoto"] != null)
                    {
                        //captura o IdFoto da URL
                        int idFoto = Convert.ToInt32(
                            Request.QueryString["IdFoto"]);
                        //cria o contexto do BD
                        using (RedeSocialEntities ctx = new RedeSocialEntities())
                        {
                            //captura o objeto do usuário logado
                            Usuario logado = ctx.Usuarios.SingleOrDefault(
                                x => x.Email == Page.User.Identity.Name);
                            //captura o objeto que representa a
                            //foto cujo Id veio na URL
                            Foto foto = ctx.Fotos.SingleOrDefault(
                                x => x.Id == idFoto);
                            //se for amigo do dono da foto ou o próprio dono da foto...
                            if ((logado.Convidados.Count(x => x.Id == foto.Album.IdPessoa) > 0) ||
                                (logado.Solicitantes.Count(x => x.Id == foto.Album.IdPessoa) > 0) ||
                                (logado.Id == foto.Album.IdPessoa))
                            {
                                //altera o endereço da imagem da foto
                                imgFoto.Src = "~/FotosAlbuns/" +
                                    idFoto.ToString("d9") + ".jpg";

                                //captura os comentários da foto atribuindo novos
                                //nomes aos campos vindos da coleção
                                AtualizarListaComentarios(ctx);
                            }
                        }
                    }
                    //se não houver IdFoto na URL...
                    else
                    {
                        Session["info"] =
                            "Foto não informada.";
                        Response.Redirect("~/Default.aspx");
                    }
                }
            }
            //se o usuário não estiver logado
            else
            {
                Session["info"] =
                    "Você deve estar logado para ver uma foto.";
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnEnviarComentario_Click(object sender, EventArgs e)
        {
            //cria o contexto do BD
            using (RedeSocialEntities ctx = new RedeSocialEntities())
            {
                //captura o objeto do usuário logado
                Usuario logado = ctx.Usuarios.SingleOrDefault(
                    x => x.Email == Page.User.Identity.Name);
                //captura o IdFoto que veio na URL
                int idFoto = Convert.ToInt32(
                    Request.QueryString["IdFoto"]);
                //captura o objeto da foto cujo Id veio na URL
                Foto foto = ctx.Fotos.SingleOrDefault(
                    x => x.Id == idFoto);
                //cria um novo objeto Comentario
                Comentario com = new Comentario();
                //preenche os dados do comentário
                com.IdPessoa = logado.Id;
                com.IdFoto = idFoto;
                com.Texto = txtNovoComentario.Text.Trim();
                com.DataCadastro = DateTime.Now;
                com.Aprovado = true;
                //adiciona o comentário criado à coleção de 
                //comentários da foto
                foto.Comentarios.Add(com);
                //aplica as alterações no BD
                ctx.SaveChanges();
                //limpa o campo
                txtNovoComentario.Text = "";
                //atualiza a lista de comentários
                AtualizarListaComentarios(ctx);
            }
        }

        protected void lvComentarios_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //se receber um comando de exclusão
            if (e.CommandName == "Excluir")
            {
                //captura o id do comentário a excluir
                int idComentario = Convert.ToInt32(
                    e.CommandArgument);
                //cria um contexto do BD
                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    //captura o objeto Comentario a ser excluído
                    Comentario com = ctx.Comentarios.SingleOrDefault(
                        x => x.Id == idComentario);
                    //exclui o objeto da coleção Comentarios do contexto
                    ctx.Comentarios.DeleteObject(com);
                    //aplica as alterações no BD
                    ctx.SaveChanges();
                    //grava mensagem para o usuário
                    Session["info"] = "Comentário excluído com sucesso.";
                    //atualiza a lista de usuário
                    AtualizarListaComentarios(ctx);
                }
            }
        }

        private void AtualizarListaComentarios(RedeSocialEntities ctx)
        {
            //captura o IdFoto que veio na URL
            int idFoto = Convert.ToInt32(
                Request.QueryString["IdFoto"]);
            //captura o objeto da foto cujo Id veio na URL
            Foto foto = ctx.Fotos.SingleOrDefault(
                x => x.Id == idFoto);
            //atualiza a lista de comentários
            var query = from c in foto.Comentarios
                        select new
                        {
                            NomeAmigo = c.Usuario.Nome,
                            Comentario = c.Texto,
                            DataCadastro = c.DataCadastro,
                            IdPessoa = c.IdPessoa,
                            Id = c.Id
                        };
            lvComentarios.DataSource =
                query.OrderByDescending(x => x.DataCadastro);
            lvComentarios.DataBind();
        }

        protected void lvComentarios_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //se for a renderização de um item de dados
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                //captura o botão de exclusão do item
                LinkButton btnExcluir = (LinkButton)
                    e.Item.FindControl("btnExcluir");
                //captura o Id do comentário deste item
                int idCom = Convert.ToInt32(
                    DataBinder.Eval(e.Item.DataItem, "Id"));
                //cria um contexto do BD
                using (RedeSocialEntities ctx = new RedeSocialEntities())
                {
                    //captura o objeto do comentário do item
                    Comentario com = ctx.Comentarios.SingleOrDefault(
                        x => x.Id == idCom);
                    //captura o objeto do usuário logado
                    Usuario usuario = ctx.Usuarios.SingleOrDefault(
                        x => x.Email == Page.User.Identity.Name);
                    //se o usuário logado não for dono da foto e
                    //não for dono do comentário...
                    if ((com.IdPessoa != usuario.Id) &&
                        (com.Foto.Album.IdPessoa != usuario.Id))
                    {
                        //oculta o botão de exclusão do comentário
                        btnExcluir.Visible = false;
                    }                    
                }
            }
        }
    }
}