<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FormUsuario.aspx.cs" Inherits="CasasEstranhas.com.admin.FormUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script src="../scripts/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../scripts/jquery.meio.mask.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h1>Cadastro de Usuário</h1>
    <hr />
    Nome:<br />
    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtNome" ErrorMessage="Campo obrigatório." 
        ValidationGroup="Cadastrar"></asp:RequiredFieldValidator>
    <br />
    Login:<br />
    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtLogin" ErrorMessage="Campo obrigatório." 
        ValidationGroup="Cadastrar"></asp:RequiredFieldValidator>
    <br />
    Senha:<br />
    <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtSenha" ErrorMessage="Campo obrigatório." 
        ValidationGroup="Cadastrar"></asp:RequiredFieldValidator>
    <br />
    Confirmação de Senha:<br />
    <asp:TextBox ID="txtConfSenha" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtConfSenha" Display="Dynamic" 
        ErrorMessage="Campo obrigatório." ValidationGroup="Cadastrar"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="txtSenha" ControlToValidate="txtConfSenha" Display="Dynamic" 
        ErrorMessage="Senha não confere." ValidationGroup="Cadastrar"></asp:CompareValidator>
    <br />
    <asp:CheckBox ID="chkAdmin" runat="server" />Administrador<br />
    <br />
    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" 
        ValidationGroup="Cadastrar" onclick="btnCadastrar_Click" />
</asp:Content>
