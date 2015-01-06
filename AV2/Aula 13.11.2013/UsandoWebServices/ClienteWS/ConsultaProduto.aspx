<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaProduto.aspx.cs" Inherits="ClienteWS.ConsultaProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Consulta de Produtos</h1>
        <hr />
        <p>
            <label>
                Código do Produto <br />
                <input type="text" runat="server" id="txtCodigo" />
            </label>
        </p>
        <p>
            <button type="submit" runat="server" id="btnConsultar" onserverclick="btnConsultar_ServerClick">
                Consultar
            </button>
        </p>
        <p>
            <span runat="server" id="spnPreco">Indefinido</span>
        </p>
    </form>
</body>
</html>
