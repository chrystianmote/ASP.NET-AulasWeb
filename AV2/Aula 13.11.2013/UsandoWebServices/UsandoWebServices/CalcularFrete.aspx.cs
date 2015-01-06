using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsandoWebServices.Correios;

namespace UsandoWebServices
{
    public partial class CalcularFrete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_ServerClick(object sender, EventArgs e)
        {
            CalcPrecoPrazoWSSoapClient ws = new CalcPrecoPrazoWSSoapClient();
            var resultado = ws.CalcPrecoPrazo("", "", slcServico.Value, txtCepOrigem.Value,
                txtCepDestino.Value, txtPeso.Value, 1, 40, 40, 40, 0, chkMaoPropria.Checked ? "S" : "N",
                Convert.ToDecimal(txtValorDeclarado.Value), chkAvisoRecebimento.Checked ? "S" : "N");
            spnPrazo.InnerText = resultado.Servicos[0].PrazoEntrega + " dias";
            spnPreco.InnerText = "R$" + resultado.Servicos[0].Valor;
        }
    }
}