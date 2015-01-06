<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalcularFrete.aspx.cs" Inherits="UsandoWebServices.CalcularFrete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Consultar Frete</h1>
        <hr />
        <div>
            <p>
                <label>
                    Serviço:<br />
                    <select runat="server" id="slcServico">
                        <option value="40010">SEDEX Varejo</option>
                        <option value="40045">SEDEX a Cobrar Varejo</option>
                        <option value="40215">SEDEX 10 Varejo</option>
                        <option value="40290">SEDEX Hoje Varejo</option>
                        <option value="41106">PAC Varejo</option>
                    </select>
                </label>
            </p>
            <p>
                <label>
                    CEP de Origem:
                    <br />
                    <input type="text" runat="server" id="txtCepOrigem" />
                </label>
            </p>
            <p>
                <label>
                    CEP de Destino:
                    <br />
                    <input type="text" runat="server" id="txtCepDestino" />
                </label>
            </p>
            <p>
                <label>
                    Peso:
                    <br />
                    <input type="text" runat="server" id="txtPeso" />
                </label>
            </p>
            <p>
                <label>
                    Valor Declarado:
                    <br />
                    <input type="text" runat="server" id="txtValorDeclarado" />
                </label>
            </p>
            <p>
                <label>
                    <input type="checkbox" runat="server" id="chkAvisoRecebimento" />
                    Aviso de Recebimento:
                </label>
            </p>
            <p>
                <label>
                     <input type="checkbox" runat="server" id="chkMaoPropria" />
                    Entrega em Mão Própria:
                </label>
            </p>
            <p>
                <button type="submit" runat="server" id="btnConsultar" onserverclick="btnConsultar_ServerClick">
                    Consultar
                </button>
            </p>
            <p>
                Prazo: <span runat="server" id="spnPrazo">Indefinido</span><br />
                Preço: <span runat="server" id="spnPreco">Indefinido</span>
            </p>
        </div>
    </form>
</body>
</html>
