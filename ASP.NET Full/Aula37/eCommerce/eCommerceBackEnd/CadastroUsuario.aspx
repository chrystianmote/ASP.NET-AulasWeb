<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="eCommerceBackEnd.CadastroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Novo Usuário"></asp:Label><br />
    </h2>
    <div class="sm-postcontent">    
        
        <asp:Label ID="lblEmail" runat="server" Text="E-mail:"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server" Width="168px" ValidationGroup="Cadastro"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
            ErrorMessage="Campo obrigatório." 
            ControlToValidate="txtEmail"
            Display="Dynamic" />
        <asp:RegularExpressionValidator 
            ErrorMessage="Formato de e-mail inválido." 
            ControlToValidate="txtEmail"
            ID="revEmail" runat="server" 
            Display="Dynamic" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/><br />

        <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label><br />
        <asp:TextBox ID="txtSenha" runat="server" Width="168px" 
            ValidationGroup="Cadastro" TextMode="Password"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvSenha" runat="server" 
            ErrorMessage="Campo obrigatório." 
            ControlToValidate="txtSenha" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="revSenha" runat="server" 
            ControlToValidate="txtSenha" Display="Dynamic" 
            ErrorMessage="A senha deve ter pelo menos 6 caracteres." 
            ValidationExpression="\w{6,10}" ValidationGroup="Cadastro"></asp:RegularExpressionValidator>
        <br />
            
        <asp:Label ID="lblConfSenha" runat="server" Text="Confirmação de Senha:"></asp:Label><br />
        <asp:TextBox ID="txtConfSenha" runat="server" Width="168px" 
            ValidationGroup="Cadastro" TextMode="Password"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvConfSenha" runat="server" 
            ErrorMessage="Campo obrigatório." 
            ControlToValidate="txtConfSenha"
            Display="Dynamic">
            </asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvConfSenha" runat="server" 
            ErrorMessage="Senha não confere."
            ControlToValidate="txtSenha" 
            ControlToCompare="txtConfSenha"
            ValidationGroup="Cadastro" 
            Display="Dynamic">
            </asp:CompareValidator><br />

        <p>
            <b>Perfis:</b><br />
            <asp:CheckBox ID="chkAdministrador" Text="Administrador" 
                runat="server" /><br />
            <asp:CheckBox ID="chkVendedor" Text="Vendedor" 
                runat="server" /><br />
            <asp:CheckBox ID="chkCadastrador" Text="Cadastrador" 
                runat="server" />
        </p>
                    <asp:Button ID="btnGravar" runat="server" Text="Cadastrar Usuário"
                ValidationGroup="Cadastro" onclick="btnGravar_Click"/>

            <asp:Button ID="btnCancelar" runat="server" 
                Text="Cancelar" 
                PostBackUrl="~/ListaUsuarios.aspx" />


    </div>
</asp:Content>