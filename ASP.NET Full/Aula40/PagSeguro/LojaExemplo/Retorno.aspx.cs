using System;
using System.Collections;
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

public partial class Retorno : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        //Esta linha deve ser removida para que seja utilizado o ambiente real do PagSeguro
        this.RetornoPagSeguro1.UrlNPI = "http://localhost:9090/pagseguro-ws/checkout/NPI.jhtml";
    }

    protected void RetornoPagSeguro1_VendaEfetuada(UOL.PagSeguro.RetornoVenda retornoVenda) {
        //Obtendo o número do Pedido
        int codigo_pedido = int.Parse(retornoVenda.CodigoReferencia);

        //Obtendo o código da transação no PagSeguro
        string codigo_transacao_pagseguro = retornoVenda.CodigoTransacao;

        //Obtendo o novo status do pedido
        UOL.PagSeguro.StatusTransacao status = retornoVenda.StatusTransacao;

        //Obtendo a forma de pagamento utilizada
        string tipo_pagamento = retornoVenda.TipoPagamentoDescricao;

        //Obtendo o valor pago pelo frete
        double frete_cobrado = retornoVenda.ValorFrete;

        //Obtendo a anotação deixada pelo cliente no momento do pagamento
        string anotacao_cliente = retornoVenda.Anotacao;

        //Atualizando na base de dados o status do pedido e as outras informações
        AcessoDados.Instancia.AtualizarVenda(codigo_pedido, codigo_transacao_pagseguro, status, tipo_pagamento, frete_cobrado, anotacao_cliente);
    }

    protected void RetornoPagSeguro1_VendaNaoAutenticada(object sender, UOL.PagSeguro.VendaNaoAutenticadaEventArgs e) {
        //Aqui dispara quando o PagSeguro retorna algo diferente de verificado
    }

    protected void RetornoPagSeguro1_FalhaProcessarRetorno(object sender, UOL.PagSeguro.FalhaProcessarRetornoEventArgs e) {
        //Aqui dispara quando dá algum problema de parse nos dados
    }
    protected void RetornoPagSeguro1_RetornoVerificado(object sender, UOL.PagSeguro.VendaAutenticadaEventArgs e) {
        //Aqui dispara quando é obtido o retorno VERIFICADO do PagSeguro. Este método é disparado antes do RetornoPagSeguro1_VendaEfetuada
    }
}
