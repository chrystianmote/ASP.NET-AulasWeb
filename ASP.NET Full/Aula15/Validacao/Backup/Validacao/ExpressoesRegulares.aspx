<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpressoesRegulares.aspx.cs"
    Inherits="Validacao.ExpressoesRegulares" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblERAtual" runat="server" Text=""></asp:Label><br />
        Nova expressão:<br />
        <asp:TextBox ID="txtNovaER" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnDefinirER" runat="server" Text="Definir Nova Expressão Regular"
            OnClick="btnDefinirER_Click" /><br />
        <br />
        Valor a validar:<br />
        <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revDinamico" runat="server" ErrorMessage="Valor inválido"
            ControlToValidate="txtValor" Text="*"></asp:RegularExpressionValidator><br />
        <asp:Button ID="btnValidar" runat="server" Text="Validar" /><br />
        <asp:ValidationSummary ID="vsErros" runat="server" />
    </div>
    </form>
</body>
</html>
