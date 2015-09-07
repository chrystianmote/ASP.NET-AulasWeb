<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="UsandoMembershipRoles.CadastroUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Cadastro de Usuário</h1>
        Nome de usuário:<br />
        <asp:TextBox runat="server" id="txtNomeUsuario"/><br />
        E-mail:<br />
        <asp:TextBox runat="server" id="txtEmail"/><br />
        Senha:<br />
        <asp:TextBox runat="server" id="txtSenha"/><br />
        Confirmação de senha:<br />
        <asp:TextBox runat="server" id="txtConfirmacao"/>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txtSenha" ControlToValidate="txtConfirmacao" 
            ErrorMessage="Senha e confirmação de senha não conferem."></asp:CompareValidator>
        <br />
        Pergunta de segurança:<br />
        <asp:TextBox runat="server" id="txtPergunta" />
        <br />
        Resposta de segurança:<br />
        <asp:TextBox ID="txtResposta" runat="server"></asp:TextBox>
        <br />        
        <asp:CheckBox Text="Aprovado" runat="server" id="chkAprovado" />
        <br />
        <br />
        Perfis associados:<br />
        <asp:CheckBoxList ID="cblPerfis" runat="server">
        </asp:CheckBoxList>
        <br />
        <br />
        <asp:Button Text="Cadastrar" runat="server" id="btnCadastrar" 
            onclick="btnCadastrar_Click" />
        <br />
        <asp:Label runat="server" id="lblInfo" 
            ForeColor="Red" />
    </div>
    </form>
</body>
</html>
