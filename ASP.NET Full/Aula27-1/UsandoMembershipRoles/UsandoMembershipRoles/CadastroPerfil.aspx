<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroPerfil.aspx.cs" Inherits="UsandoMembershipRoles.CadastroPerfil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Cadastro de Perfil</h1>

        Nome do perfil:<br />
        <asp:TextBox runat="server" ID="txtNomePerfil" /><br />
        <br />
        <asp:Button Text="Cadastrar" runat="server" ID="btnCadastrar" 
            onclick="btnCadastrar_Click" />
        <br /><br />
        <asp:HyperLink NavigateUrl="~/ListaPerfis.aspx" runat="server" 
            Text="Lista de Perfis" />
    </div>
    </form>
</body>
</html>
