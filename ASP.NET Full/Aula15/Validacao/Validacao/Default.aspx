<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Validacao._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Número de 1 a 10<br />
    <asp:TextBox ID="txtComValidacao" runat="server"></asp:TextBox>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtComValidacao"
        ErrorMessage="O número deve estar entre 1 e 10" MaximumValue="10" MinimumValue="1"
        Type="Integer" Display="Dynamic"><img alt="erro" src="iconerror.gif" /></asp:RangeValidator>
    <br />
    <br />
    Algo qualquer:<br />
    <asp:TextBox ID="txtSemValidacao" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" onclick="btnEnviar_Click" />
    &nbsp;
        <asp:Button ID="btnvalidar" runat="server" CausesValidation="False" 
            onclick="btnvalidar_Click" Text="Validação Manual" />
        <br />
        <br />
        <asp:Label ID="lblerros" runat="server"></asp:Label>
        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            HeaderText="Acerte os seguintes erros" />
    </div>
    </form>
</body>
</html>
