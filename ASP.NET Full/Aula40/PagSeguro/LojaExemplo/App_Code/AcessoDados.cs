using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using UOL.PagSeguro;

/// <summary>
/// Summary description for AcessoDados
/// </summary>
public class AcessoDados {

    private static AcessoDados _instancia;
    public static AcessoDados Instancia {
        get {
            if (_instancia == null) {
                _instancia = new AcessoDados();
            }
            return _instancia;
        }
    }

    private AcessoDados() {

    }

    //Adicionar o pedido na sua base de dados
    public string GravarPedido(Carrinho carrinho) {
        return Convert.ToString(new Random().Next());
    }

    //Aqui você deve atualizar o pedido na sua base de dados
    public void AtualizarVenda(int pedido, string transacao, StatusTransacao status, string forma_pagamento, double frete, string anotacao) {
        
    }
}
