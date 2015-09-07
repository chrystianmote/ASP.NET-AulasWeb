using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using eCommerceDAL;

namespace eCommerceBackEnd
{
    public partial class ListaProdutos : System.Web.UI.Page
    {
        //atualiza o gvLista
        private void AtualizarLista(eCommerceDAL.eCommerceEntities ctx)
        {
            //se estiver exibindo todos os produtos
            if (Request.QueryString["IdCategoria"] == null)
            {
                //obtém os produtos do contexto do banco de dados
                gvLista.DataSource =
                    ctx.Produtos.OrderBy(
                    x => x.Nome);
                gvLista.DataBind();
            }
            //se estiver exibindo os produtos de uma categoria...
            else
            {
                //captura o IdCategoria da URL
                int idCat = Convert.ToInt32(
                    Request.QueryString["IdCategoria"]);
                //captura o objeto DAL da categoria cujo 
                //IdCategoria veio na URL
                Categoria cat = ctx.Categorias.SingleOrDefault(
                    x => x.IdCategoria == idCat);
                //altera o título da página
                lblTitulo.Text =
                    "Produtos da Categoria " +
                    cat.Descricao;
                //obtém os produtos da categoria que veio na URL
                gvLista.DataSource =
                    ctx.Produtos.OrderBy(
                    x => x.Nome).Where(
                    x => x.IdCategoria == idCat);
                gvLista.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o carregamento principal da página...
            if (!Page.IsPostBack)
            {
                //cria o contexto do banco de dados
                using (eCommerceDAL.eCommerceEntities ctx =
                    new eCommerceDAL.eCommerceEntities())
                {
                    //atualiza o gvLista
                    AtualizarLista(ctx);
                }
            }
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //se o comando for Excluir..
            if (e.CommandName == "Excluir")
            {
                //se o usuário estiver no perfil administrador
                if (Roles.IsUserInRole("administrador"))
                {
                    //obtém o código do produto a excluir
                    int idProduto = Convert.ToInt32(
                        e.CommandArgument);
                    //cria o contexto do banco de dados
                    using (eCommerceDAL.eCommerceEntities ctx =
                        new eCommerceDAL.eCommerceEntities())
                    {
                        //se o produto ainda não foi vendido
                        if (ctx.ItensPedido.Select(
                            x => x.IdProduto == idProduto).
                            Count() == 0)
                        {
                            //obtém o objeto Produto a ser excluído
                            Produto produto =
                                ctx.Produtos.SingleOrDefault(
                                x => x.IdProduto == idProduto);
                            //exclui o produto do contexto do banco de dados
                            ctx.Produtos.DeleteObject(produto);
                            //salva as alterações no banco de dados
                            ctx.SaveChanges();
                            //grava mensagem para o usuário
                            Session["info"] =
                                "Produto excluído com sucesso!";
                            //atualiza a gvLista
                            AtualizarLista(ctx);
                        }
                        //se o produto já foi vendido
                        else
                        {
                            //grava mensagem para o usuários
                            Session["info"] =
                                "Não é possível excluir um produto que já tenha sido vendido.";
                        }
                    }
                }
                //se o usuário não for administrador...
                else
                {
                    //grava mensagem para o usuário
                    Session["info"] =
                        "Você não possui permissão para excluir produtos.";
                }
            }
        }
    }
}