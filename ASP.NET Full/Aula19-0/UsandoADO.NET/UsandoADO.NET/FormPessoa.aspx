<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPessoa.aspx.cs" Inherits="UsandoADO.NET.FormPessoa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Cadastro de Pessoa</h1>
        Nome:<br />
        <asp:TextBox ID="txtNome" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
            ErrorMessage="Preencha o seu nome!"></asp:RequiredFieldValidator>
        <br />
        E-mail:<br />
        <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="E-mail inválido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        Endereço:<br />
        <asp:TextBox ID="txtEndereco" runat="server" Rows="3" TextMode="MultiLine" Width="200px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" Text="Cadastrar" />
        <br />
    </div>
    </form>
</body>
</html>
