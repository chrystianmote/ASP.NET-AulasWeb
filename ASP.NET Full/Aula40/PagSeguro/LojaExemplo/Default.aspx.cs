using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        //Esta linha deve ser removida para que seja utilizado o ambiente real do PagSeguro
        this.VendaPagSeguro1.UrlPagSeguro = "http://localhost:9090/checkout/checkout.jhtml";
    }

    protected void AdicionarItem(object sender, EventArgs e) {
        Carrinho.Instancia.Adicionar(int.Parse(((Button)sender).CommandArgument), 1);
        this.AtualizarStatus();
    }

    protected void LimparCarrinho(object sender, EventArgs e) {
        Carrinho.Instancia.Limpar();
        this.AtualizarStatus();
    }

    private void AtualizarStatus() {
        this.lblCarrinho.Text = String.Format("Seu carrinho tem {0} itens", Carrinho.Instancia.QuantidadeTotal);
    }

    protected void btnEfetuarPagamento_Click(object sender, EventArgs e) {
        //Somente executa se tiver itens
        if (Carrinho.Instancia.TemItens) {

            //Grave o seu pedido do ser carrinho no banco de dados, e informe o código do mesmo ao PagSeguro
            string codigoPedido = AcessoDados.Instancia.GravarPedido(Carrinho.Instancia);
            this.VendaPagSeguro1.CodigoReferencia = codigoPedido;

            //Instancie a lista de produtos a ser comprados
            this.VendaPagSeguro1.Produtos = new List<UOL.PagSeguro.Produto>();

            //Varrendo os itens do carrinho
            foreach (int codigo in Carrinho.Instancia.CodigosDosItens) {

                //Obtendo o produto do banco de dados
                this.AccessDataSource1.FilterExpression = string.Format("ID = {0}", codigo);
                DataView dataView = (DataView)this.AccessDataSource1.Select(new DataSourceSelectArguments());
                DataRow registro = dataView[0].Row;

                //Obtendo a quantidade solicitada para o mesmo produto
                int quantidade = Carrinho.Instancia.ObterQuantidadeDoItem(codigo);

                //Criando o produto para ser adicionado à venda do PagSeguro
                UOL.PagSeguro.Produto produto = new UOL.PagSeguro.Produto();
                produto.Codigo = codigo.ToString();
                produto.Descricao = string.Format("{0} {1}", registro["Trademark"], registro["Model"]);
                produto.Quantidade = quantidade;
                produto.Valor = Convert.ToDouble(registro["Price"]);

                //Adicionando o produto à venda do PagSeguro
                this.VendaPagSeguro1.Produtos.Add(produto);
            }

            //Removendo o filtro do DataSource
            this.AccessDataSource1.FilterExpression = string.Empty;

            //Informe ao componente, caso possível, os dados do cliente que está efetuando a compra
            this.VendaPagSeguro1.Cliente = new UOL.PagSeguro.Cliente();
            this.VendaPagSeguro1.Cliente.Nome = "João da Silva";

            //Limpando o Carrinho
            Carrinho.Instancia.Limpar();

            //Encaminhando ao PagSeguro para efetuar o pagamento
            this.VendaPagSeguro1.Executar(this.Response);
        }
    }
}
