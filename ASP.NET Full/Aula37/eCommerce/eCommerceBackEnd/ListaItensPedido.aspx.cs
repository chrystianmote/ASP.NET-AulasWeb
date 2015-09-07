using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerceDAL;

namespace eCommerceBackEnd
{
    public partial class ListaItensPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //se for o carregamento principal da página
            if (!Page.IsPostBack)
            {
                //se houver um IdPedido na URL...
                if (Request.QueryString["IdPedido"] != null)
                {
                    //cria o contexto do banco de dados
                    using (eCommerceEntities ctx = new eCommerceEntities())
                    {
                        //captura o IdPedido da URL
                        int idPedido = Convert.ToInt32(
                            Request.QueryString["IdPedido"]);
                        //acrescenta o IdPedido ao título da página
                        lblTitulo.Text += idPedido.ToString("d6");
                        AtualizarListaItens(ctx, idPedido);
                    }
                }
                //se não houver IdPedido na URL...
                else
                {                    
                    Session["info"] =
                        "Não foi informado um pedido para se listar os itens.";
                }
            }
        }

        private void AtualizarListaItens(eCommerceEntities ctx, int idPedido)
        {
            //obtém a lista de itens de pedido pertencetes
            //ao pedido cujo IdPedido veio na URL
            gvLista.DataSource = ctx.ItensPedido.Where(
                x => x.IdPedido == idPedido);
            gvLista.DataBind();
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //se receber um comando "Excluir" do gvLista...
            if (e.CommandName == "Excluir")
            {
                //captura o IdProduto que vem no argumento
                //do comando de exclusão
                int idProduto = Convert.ToInt32(
                    e.CommandArgument);
                //captura o IdPedido que veio na URL
                int idPedido = Convert.ToInt32(
                    Request.QueryString["IdPedido"]);
                //cria o contexto do banco de dados
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    //obtém o objeto ItemPedido a ser excluído
                    ItemPedido ip = ctx.ItensPedido.SingleOrDefault(
                        x => (x.IdPedido == idPedido) &&
                            (x.IdProduto == idProduto));
                    //remove o objeto ip do contexto
                    ctx.ItensPedido.DeleteObject(ip);
                    //salva as alterações no banco de dados
                    ctx.SaveChanges();
                    //registra mensagem para o usuário
                    Session["info"] = "Item excluído com sucesso!";
                    //atualiza a lista de itens de pedido
                    AtualizarListaItens(ctx, idPedido);
                }
            }
        }
    }
}