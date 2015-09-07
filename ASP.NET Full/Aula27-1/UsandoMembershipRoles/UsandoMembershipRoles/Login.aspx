<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UsandoMembershipRoles.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Login</h1>

        Usuário:<br />
        <asp:TextBox runat="server" ID="txtUsuario" /><br />
        <br />
        Senha:<br />
        <asp:TextBox runat="server" ID="txtSenha" 
            TextMode="Password" /><br />
        <br />
        <asp:Button Text="Login" runat="server" ID="btnLogin" 
            onclick="btnLogin_Click" />
        <br /><br />
        <asp:HyperLink NavigateUrl="~/CadastroUsuario.aspx" 
            runat="server" Text="Cadastrar Novo Usuário" />
    </div>
    </form>
</body>
</html>
