using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using eCommerceDAL;
using System.Web.Configuration;

namespace eCommerceBackEnd
{
    public partial class ListaProdutos : System.Web.UI.Page
    {
        //atualiza o gvLista
        private void AtualizarLista(eCommerceDAL.eCommerceEntities ctx)
        {
            //inicializa a página atual com 1
            int paginaAtual = 1;
            //captura a qtde de pedidos por página a exibir
            int tamanhoPagina = Convert.ToInt32(
                WebConfigurationManager.
                AppSettings["ProdutosPorPagina"]);
            //inicializa a qtde total de pedidos
            int qtdeTotalProdutos = 0;
            //captura o número da página da URL, caso haja
            if (Request.QueryString["Pagina"] != null)
            {
                paginaAtual = Convert.ToInt32(
                    Request.QueryString["Pagina"]);
            }

            //se estiver exibindo os produtos em destaque
            if (Request.QueryString["Tipo"] != null)
            {
                if (Request.QueryString["Tipo"] == "EmDestaque")
                {
                    //monta o link de paginação
                    linkAnterior.HRef = 
                        "~/ListaProdutos.aspx?Tipo=EmDestaque&Pagina=" +
                        (paginaAtual - 1).ToString();
                    linkPosterior.HRef = 
                        "~/ListaProdutos.aspx?Tipo=EmDestaque&Pagina=" +
                        (paginaAtual + 1).ToString();
                    //atribui ao gvLista todos os produtos da página solicitada
                    gvLista.DataSource =
                        ctx.Produtos.
                        OrderBy(x => x.Nome).
                        Where(x => x.EmDestaque == true).
                        Skip(tamanhoPagina * (paginaAtual - 1)).
                        Take(tamanhoPagina);
                    //obtém a quantidade total de produtos
                    qtdeTotalProdutos = ctx.Produtos.
                        Where(x => x.EmDestaque == true).Count();
                }
            }
            //se estiver exibindo todos os produtos
            else if (Request.QueryString["IdCategoria"] == null)
            {                
                //monta o link de paginação
                linkAnterior.HRef = "~/ListaProdutos.aspx?Pagina=" + 
                    (paginaAtual - 1).ToString();
                linkPosterior.HRef = "~/ListaProdutos.aspx?Pagina=" + 
                    (paginaAtual + 1).ToString();
                //atribui ao gvLista todos os produtos da página solicitada
                gvLista.DataSource =
                    ctx.Produtos.
                    OrderBy(x => x.Nome).
                    Skip(tamanhoPagina * (paginaAtual - 1)).
                    Take(tamanhoPagina);
                //obtém a quantidade total de produtos
                qtdeTotalProdutos = ctx.Produtos.Count();
            }
            //se estiver exibindo os produtos de uma categoria...
            else
            {
                //captura o IdCategoria da URL...
                int idCategoria = Convert.ToInt32(
                    Request.QueryString["IdCategoria"]);
                //monta o link de paginação
                linkAnterior.HRef = "~/ListaProdutos.aspx?IdCategoria=" +
                    idCategoria.ToString() +
                    "&Pagina=" + (paginaAtual - 1).ToString();
                linkPosterior.HRef = "~/ListaProdutos.aspx?IdCategoria=" +
                    idCategoria.ToString() +
                    "&Pagina=" + (paginaAtual + 1).ToString();
                //atribui ao gvLista os produtos cujo IdCategoria
                //seja igual ao que veio na URL
                gvLista.DataSource =
                    ctx.Produtos.
                    OrderBy(x => x.Nome).
                    Where(x => x.IdCategoria == idCategoria).
                    Skip(tamanhoPagina * (paginaAtual - 1)).
                    Take(tamanhoPagina);
                //obtém a quantidade total de produtos cujo IdCategoria
                //seja igual ao que veio na URL
                qtdeTotalProdutos = ctx.Produtos.
                    Count(x => x.IdCategoria == idCategoria);
            }
            //popula os campos do gvLista
            gvLista.DataBind();
            //esconde e/ou mostra os links de paginação
            //de acordo com a página atual e com a 
            //quantidade total de registros
            linkAnterior.Visible = paginaAtual > 1;
            linkPosterior.Visible = (paginaAtual * tamanhoPagina) <
                qtdeTotalProdutos;
            //atualiza a exibição da página atual e do total de páginas
            lblPaginaAtual.Text = paginaAtual.ToString();
            lblTotalPaginas.Text = (Math.Ceiling(
                (double)qtdeTotalProdutos / (double)tamanhoPagina)).
                ToString();
            //se não há produtos, esconde a área de paginação
            if (qtdeTotalProdutos == 0)
            {
                prgPaginacao.Visible = false;
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