<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalhesUsuario.aspx.cs" Inherits="UsandoMembershipRoles.DetalhesUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Detalhes de Usuário</h1>

        Nome de usuário: 
        <asp:Label ID="lblNomeUsuario" runat="server" /><br />

        E-mail:
        <asp:Label ID="lblEmail" runat="server" /><br />

        Data de Cadastro:
        <asp:Label ID="lblDataCadastro" runat="server" /><br />

        Data do Último Login:
        <asp:Label ID="lblDataUltimoLogin" runat="server" /><br />

        Data da Última Requisição:
        <asp:Label ID="lblDataUltimaRequisicao" runat="server" /><br />

        Data da Última Alteração de Senha:
        <asp:Label ID="lblDataAlteracaoSenha" runat="server" /><br />

        Está aprovado? 
        <asp:Label ID="lblEstaAprovado" runat="server" /><br />

        Está bloqueado?
        <asp:Label ID="lblEstaBloqueado" runat="server" /><br />

        Está online? 
        <asp:Label ID="lblEstaOnline" runat="server" /><br />

        Comentários:
        <asp:Label ID="lblComentarios" runat="server" /><br />
        <br />
        <asp:HyperLink NavigateUrl="~/ListaUsuarios.aspx" 
            runat="server" Text="Lista de Usuário" />
    </div>
    </form>
</body>
</html>
