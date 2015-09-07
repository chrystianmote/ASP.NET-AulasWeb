<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroUsuarioManual.aspx.cs" Inherits="UsandoMembership.CadastroUsuarioManual" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Cadastro de Usuário</h1>
    <div>
        E-mail:<br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        Senha:<br />
        <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox><br />
        <asp:CheckBox ID="chkAdmin" runat="server" Text="Administrador" /><br />
        <br />
        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" 
            onclick="btnCadastrar_Click" />
    </div>
    </form>
</body>
</html>
