<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="RedeSocialEF4.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Cadastro de Usuário</h1>
    <p>
        Nome:<br />
        <asp:TextBox runat="server" ID="txtNome" Width="250" />
        <asp:RequiredFieldValidator 
            ErrorMessage="Campo obrigatório!" 
            ControlToValidate="txtNome"
            runat="server" />
    </p>
    <p>
        E-mail:<br />
        <asp:TextBox runat="server" ID="txtEmail" Width="250" />
        <asp:RequiredFieldValidator 
            ErrorMessage="Campo obrigatório!" 
            ControlToValidate="txtEmail"
            runat="server" />
        <asp:RegularExpressionValidator runat="server" 
            ControlToValidate="txtEmail" 
            Display="Dynamic" 
            ErrorMessage="E-mail inválido!" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />

    </p>
    <p>
        Data Nascimento:<br />
        <asp:TextBox runat="server" ID="txtDataNasc" Width="100" />
        <asp:RequiredFieldValidator 
            ErrorMessage="Campo obrigatório!" 
            ControlToValidate="txtDataNasc"
            runat="server" />
        <asp:CompareValidator runat="server" 
            Display="Dynamic" 
            ErrorMessage="Data inválida!" 
            Operator="DataTypeCheck"
            ControlToValidate="txtDataNasc"
            Type="Date" />
    </p>
    <p>
        Senha:<br />
        <asp:TextBox runat="server" ID="txtSenha" TextMode="Password" Width="100" />
        <asp:RequiredFieldValidator ID="rfvSenha" 
            ErrorMessage="Campo obrigatório!" 
            ControlToValidate="txtSenha"
            runat="server" />
    </p>
    <p>
        Confirme a Senha:<br />
        <asp:TextBox runat="server" ID="txtConfSenha" TextMode="Password" Width="100" />
        <asp:RequiredFieldValidator ID="rfvConfSenha" 
            ErrorMessage="Campo obrigatório!" 
            ControlToValidate="txtConfSenha"
            runat="server" 
            Display="Dynamic" />
        <asp:CompareValidator
            ErrorMessage="Senha não confere!" 
            ControlToValidate="txtConfSenha"
            ControlToCompare="txtSenha"
            runat="server" 
            Display="Dynamic" />
    </p>
    <p>
        Foto atual:<br />
        <img runat="server" id="imgFoto" alt="Foto" src="" />
        <br /><br />
        Nova foto:<br />
        <asp:FileUpload ID="fupFoto" runat="server" />        
    </p>
    <p>
        <asp:Button Text="Cadastrar" runat="server" ID="btnCadastrar" 
            OnClick="btnCadastrar_Click" />
    </p>
</asp:Content>
