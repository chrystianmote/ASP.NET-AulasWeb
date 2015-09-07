using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace eCommerceFrontEnd
{
    public partial class DetalhesCarrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AtualizarItensCarrinho();
            }
        }

        private void AtualizarItensCarrinho()
        {
            var itens = Carrinho.Instancia.ObterItensDetalhados();
            lvCarrinho.DataSource = itens;
            lvCarrinho.DataBind();
            if (Carrinho.Instancia.TemItens)
            {
                decimal precoCarrinho = 0;
                foreach (var item in itens)
                {
                    precoCarrinho += item.PrecoItem;
                }
                lblPrecoCarrinho.InnerText = precoCarrinho.ToString("c");
            }
            else
            {
                divPrecoCarrinho.Visible = false;
                btnFechar.Visible = false;
            }
        }

        protected void btnFecharCompra_Click(object sender, EventArgs e)
        {
            if (Carrinho.Instancia.TemItens)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/FechamentoCompra.aspx");                   
                }
                else
                {
                    Session["mensagem"] = 
                        "Você precisa se identificar para finalizar uma compra.\\n" +
                        "Use a área de identificação no menu esquerdo.";
                }
            }
            else
            {
                Session["mensagem"] = 
                    "Não é possível finalizar uma compra sem itens no carrinho.";
            }
        }

        protected void lvCarrinho_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Aumentar":
                    Carrinho.Instancia.Adicionar(Convert.ToInt32(e.CommandArgument), 1);
                    break;
                case "Reduzir":
                    Carrinho.Instancia.Adicionar(Convert.ToInt32(e.CommandArgument), -1);
                    break;
                case "Remover":
                    Carrinho.Instancia.RemoverItem(Convert.ToInt32(e.CommandArgument));                    
                    break;
            }
            if (Carrinho.Instancia.TemItens)
            {
                AtualizarItensCarrinho();
            }
            else
            {
                Response.Redirect("~/DetalhesCarrinho.aspx");
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
