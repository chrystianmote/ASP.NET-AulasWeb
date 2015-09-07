<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Retorno.aspx.cs" Inherits="Retorno" %>

<%@ Register Assembly="UOL.PagSeguro" Namespace="UOL.PagSeguro" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loja Exemplo</title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="status_carrinho" style="width: 100%">
        Obrigado Pela Compra! Entraremos em contato com você por e-mail.<br />
        <a href="Default.aspx">Clique aqui para retornar à página principal.</a>
    </div>
    <cc1:RetornoPagSeguro ID="RetornoPagSeguro1" runat="server" 
        OnVendaEfetuada="RetornoPagSeguro1_VendaEfetuada" 
        onfalhaprocessarretorno="RetornoPagSeguro1_FalhaProcessarRetorno" 
        onvendanaoautenticada="RetornoPagSeguro1_VendaNaoAutenticada" 
        onretornoverificado="RetornoPagSeguro1_RetornoVerificado">
    </cc1:RetornoPagSeguro>
    </form>
</body>
</html>
