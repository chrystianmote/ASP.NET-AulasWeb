<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginManual.aspx.cs" Inherits="UsandoMembership.LoginManual" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Login</h1>
    <div id="divLogin" runat="server">
        Usuário:<br />
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox><br />
        Senha:<br />
        <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Efetuar Login" 
            onclick="btnLogin_Click" /><br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/CadastroUsuario.aspx">Quero me cadastrar</asp:HyperLink>
    </div>
    <div id="divLogado" runat="server">
        Olá, 
        <asp:Label ID="lblUsuario" runat="server"></asp:Label>.<br />
        Bem-vindo(a) ao Blog do Maroquio!<br />
        <asp:Button ID="btnLogout" runat="server" Text="Efetuar Logout" 
            onclick="btnLogout_Click" />
    </div>
    </form>
</body>
</html>
