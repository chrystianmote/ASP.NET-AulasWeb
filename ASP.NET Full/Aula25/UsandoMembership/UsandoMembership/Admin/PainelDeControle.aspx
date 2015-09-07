<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PainelDeControle.aspx.cs" Inherits="UsandoMembership.Admin.PainelDeControle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Painel de Controle</h1>
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Admin/ListaUsuarios.aspx">Usuários Cadastrados</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/Admin/CadastroUsuario.aspx">Cadastro de Usuário</asp:HyperLink>
    </div>
    </form>
</body>
</html>
