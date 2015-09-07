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
    public partial class ListaPedidos : System.Web.UI.Page
    {
        //atualiza a lista de pedidos
        private void AtualizarLista(eCommerceDAL.eCommerceEntities ctx)
        {
            //inicializa a página atual com 1
            int paginaAtual = 1;
            //captura a qtde de pedidos por página a exibir
            int tamanhoPagina = Convert.ToInt32(
                WebConfigurationManager.
                AppSettings["PedidosPorPagina"]);
            //inicializa a qtde total de pedidos
            int qtdeTotalPedidos = 0;
            //captura o número da página da URL, caso haja
            if (Request.QueryString["Pagina"] != null)
            {
                paginaAtual = Convert.ToInt32(
                    Request.QueryString["Pagina"]);
            }
            //se há um status na URL..
            if (Request.QueryString["Status"] != null)
            {
                //captura o status da URL...
                string status = Request.QueryString["Status"];
                //monta o link de paginação
                linkAnterior.HRef = "~/ListaPedidos.aspx?Status=" +
                    status + "&Pagina=" + (paginaAtual - 1).ToString();
                linkPosterior.HRef = "~/ListaPedidos.aspx?Status=" +
                    status + "&Pagina=" + (paginaAtual + 1).ToString();
                //atribui ao gvLista os pedidos cujo status 
                //seja igual ao que veio na URL
                gvLista.DataSource =
                    ctx.Pedidos.Include("Usuario").
                    OrderByDescending(x => x.DataHora).
                    Where(x => x.Status == status).
                    Skip(tamanhoPagina * (paginaAtual - 1)).
                    Take(tamanhoPagina);
                //obtém a quantidade total de pedidos
                qtdeTotalPedidos = ctx.Pedidos.
                    Count(x => x.Status == status);
            }
            //se há uma data na URL...
            else if (Request.QueryString["Data"] != null)
            {
                //captura a data que veio na URL
                string data = Request.QueryString["Data"];
                //monta o link de paginação
                linkAnterior.HRef = "~/ListaPedidos.aspx?Data=" +
                    data + "&Pagina=" + (paginaAtual - 1).ToString();
                linkPosterior.HRef = "~/ListaPedidos.aspx?Data=" +
                    data + "&Pagina=" + (paginaAtual + 1).ToString();
                //cria variáveis para armazanar o intervalo
                //de datas para filtrar os pedidos
                DateTime dataInicio, dataFim;
                //se a data da URL for "HOJE"
                if (data.ToUpper() == "HOJE")
                {
                    //captura a data atual com a hora zerada
                    dataInicio = DateTime.Now.Date;
                    //captura a data de amanhã com a hora zerada
                    dataFim = DateTime.Now.Date.AddDays(1);
                }
                //se a data real veio na URL
                else
                {
                    //captura a data que veio na URL e a
                    //configura como data de início
                    dataInicio = Convert.ToDateTime(data);
                    //configura a dataFim como a dataInicio + 1 dia
                    dataFim = Convert.ToDateTime(data).AddDays(1);
                }
                //atribui à gvLista os pedidos cuja DataHora
                //esteja entre dataInicio e dataFim
                gvLista.DataSource =
                    ctx.Pedidos.Include("Usuario").
                    OrderByDescending(x => x.DataHora).
                    Where(x => (x.DataHora >= dataInicio) &&
                        (x.DataHora < dataFim)).
                    Skip(tamanhoPagina * (paginaAtual - 1)).
                    Take(tamanhoPagina);
                //obtém a quantidade total de pedidos
                qtdeTotalPedidos = ctx.Pedidos.Count(
                    x => (x.DataHora >= dataInicio) &&
                        (x.DataHora < dataFim));
            }
            //se não tem filtro na URL...
            else
            {
                //monta o link de paginação
                linkAnterior.HRef = "~/ListaPedidos.aspx?Pagina=" +
                    (paginaAtual - 1).ToString();
                linkPosterior.HRef = "~/ListaPedidos.aspx?Pagina=" +
                    (paginaAtual + 1).ToString();
                //atribui a gvLista todos os pedidos ordenados
                //pela DataHora de forma descendente
                gvLista.DataSource =
                    ctx.Pedidos.Include("Usuario").
                    OrderByDescending(
                    x => x.DataHora).
                    Skip(tamanhoPagina * (paginaAtual - 1)).
                    Take(tamanhoPagina);
                //obtém a quantidade total de pedidos
                qtdeTotalPedidos = ctx.Pedidos.Count();
            }
            //popula os campos do gvLista
            gvLista.DataBind();
            //esconde e/ou mostra os links de paginação
            //de acordo com a página atual e com a 
            //quantidade total de registros
            linkAnterior.Visible = paginaAtual > 1;
            linkPosterior.Visible = (paginaAtual * tamanhoPagina) <
                qtdeTotalPedidos;
            //atualiza a exibição da página atual e do total de páginas
            lblPaginaAtual.Text = paginaAtual.ToString();
            lblTotalPaginas.Text = (Math.Ceiling(
                (double)qtdeTotalPedidos / (double)tamanhoPagina)).
                ToString();
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
                    //obtém o código do pedido a excluir
                    int idPedido = Convert.ToInt32(
                        e.CommandArgument);
                    //cria um contexto do banco de dados
                    using (eCommerceDAL.eCommerceEntities ctx =
                        new eCommerceDAL.eCommerceEntities())
                    {
                        //se o pedido não possui itens...
                        if (ctx.ItensPedido.Select(
                            x => x.IdPedido == idPedido).
                            Count() == 0)
                        {
                            //captura o objeto DAL do pedido
                            Pedido pedido =
                                ctx.Pedidos.SingleOrDefault(
                                x => x.IdPedido == idPedido);
                            //exclui o objeto do contexto do banco de dados
                            ctx.Pedidos.DeleteObject(pedido);
                            //salva as alterações no banco de dados
                            ctx.SaveChanges();
                            //grava mensagem para o usuário
                            Session["info"] =
                                "Pedido excluído com sucesso!";
                            //atualiza o gvLista
                            AtualizarLista(ctx);
                        }
                        //se o pedido possui itens
                        else
                        {
                            //grava mensagem para o usuário
                            Session["info"] =
                                "Não é possível excluir um pedido com itens.";
                        }
                    }
                }
                //se o usuário não for administrador...
                else
                {
                    //grava mensagem para o usuário
                    Session["info"] =
                        "Você não possui permissão para excluir pedidos.";
                }
            }
            else if (e.CommandName == "DiminuirStatus")
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    int idPedido = Convert.ToInt32(
                        e.CommandArgument);

                    Pedido p = ctx.Pedidos.SingleOrDefault(
                        x => x.IdPedido == idPedido);

                    switch (p.Status)
                    {
                        case "Entregue":
                            p.Status = "Enviado";
                            break;
                        case "Enviado":
                            p.Status = "Pago";
                            break;
                        case "Pago":
                            p.Status = "Pendente";
                            break;
                        default:
                            break;
                    }
                    ctx.SaveChanges();
                    AtualizarLista(ctx);
                }
            }
            else if (e.CommandName == "AumentarStatus")
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    int idPedido = Convert.ToInt32(
                        e.CommandArgument);

                    Pedido p = ctx.Pedidos.SingleOrDefault(
                        x => x.IdPedido == idPedido);

                    switch (p.Status)
                    {
                        case "Pendente":
                            p.Status = "Pago";
                            break;
                        case "Pago":
                            p.Status = "Enviado";
                            break;
                        case "Enviado":
                            p.Status = "Entregue";
                            break;
                        default:
                            break;
                    }
                    ctx.SaveChanges();
                    AtualizarLista(ctx);
                }
            }
        }
    }
}