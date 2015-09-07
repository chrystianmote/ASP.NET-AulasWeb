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
    public partial class ListaCategorias : System.Web.UI.Page
    {
        private void AtualizarLista(eCommerceDAL.eCommerceEntities ctx)
        {
            //atribui a lista de categorias ao gvLista
            gvLista.DataSource =
                ctx.Categorias.OrderBy(
                x => x.Descricao);
            //popula os campos do gvLista
            gvLista.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o carregamento principal...
            if (!Page.IsPostBack)
            {
                //cria um contexto do banco de dados
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
            //se o comando for "Excluir"
            if (e.CommandName == "Excluir")
            {
                //se o usuário for administrador...
                if (Roles.IsUserInRole("administrador"))
                {
                    //obtém o código da categoria a excluir
                    int idCategoria = Convert.ToInt32(
                        e.CommandArgument);
                    //cria um contexto do banco de dados
                    using (eCommerceDAL.eCommerceEntities ctx =
                        new eCommerceDAL.eCommerceEntities())
                    {
                        //se a categoria não possui produtos...
                        if (ctx.Produtos.Select(
                            x => x.IdCategoria == idCategoria).
                            Count() == 0)
                        {
                            //captura o objeto DAL da categoria
                            Categoria categoria =
                                ctx.Categorias.SingleOrDefault(
                                x => x.IdCategoria == idCategoria);
                            //exclui o objeto do contexto do banco de dados
                            ctx.Categorias.DeleteObject(categoria);
                            //salva as alterações no banco de dados
                            ctx.SaveChanges();
                            //grava mensagem para o usuário
                            Session["info"] =
                                "Categoria excluída com sucesso!";
                            //atualiza o gvLista
                            AtualizarLista(ctx);
                        }
                        //se a categoria possui produtos
                        else
                        {
                            //grava mensagem para o usuário
                            Session["info"] =
                                "Não é possível excluir uma categoria com produtos.";
                        }
                    }
                }
                //se o usuário não for administrador...
                else
                {
                    //grava mensagem para o usuário
                    Session["info"] =
                        "Você não possui permissão para excluir categorias.";
                }
            }
        }
    }
}