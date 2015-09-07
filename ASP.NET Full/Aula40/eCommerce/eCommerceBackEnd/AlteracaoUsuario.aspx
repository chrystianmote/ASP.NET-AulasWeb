<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AlteracaoUsuario.aspx.cs" Inherits="eCommerceBackEnd.AlteracaoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Alteração de Usuário</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Alteração de Usuário"></asp:Label><br />
    </h2>
    <div class="sm-postcontent">    
        
        <asp:Label ID="lblSenhaAtual" runat="server" Text="Senha atual:"></asp:Label><br />
        <asp:TextBox ID="txtSenhaAtual" runat="server" Width="168px" 
            ValidationGroup="Cadastro" TextMode="Password"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvSenhaAtual" runat="server" 
            ErrorMessage="Campo obrigatório." ValidationGroup="Cadastro"
            ControlToValidate="txtSenhaAtual" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="revSenhaAtual" runat="server" 
            ControlToValidate="txtSenhaAtual" Display="Dynamic" 
            ErrorMessage="A senha deve ter pelo menos 6 caracteres." 
            ValidationExpression="\w{6,10}" ValidationGroup="Cadastro"></asp:RegularExpressionValidator>
        <br />

        <asp:Label ID="lblNovaSenha" runat="server" Text="Nova Senha:"></asp:Label><br />
        <asp:TextBox ID="txtNovaSenha" runat="server" Width="168px" 
            ValidationGroup="Cadastro" TextMode="Password"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvNovaSenha" runat="server" 
            ErrorMessage="Campo obrigatório." ValidationGroup="Cadastro"
            ControlToValidate="txtNovaSenha" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="revNovaSenha" runat="server" 
            ControlToValidate="txtNovaSenha" Display="Dynamic" 
            ErrorMessage="A nova senha deve ter pelo menos 6 caracteres." 
            ValidationExpression="\w{6,10}" ValidationGroup="Cadastro"></asp:RegularExpressionValidator>
        <br />
            
        <asp:Label ID="lblConfSenha" runat="server" Text="Confirmação de Senha:"></asp:Label><br />
        <asp:TextBox ID="txtConfSenha" runat="server" Width="168px" 
            ValidationGroup="Cadastro" TextMode="Password"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvConfSenha" runat="server" 
            ErrorMessage="Campo obrigatório." 
            ControlToValidate="txtConfSenha"
            Display="Dynamic"
            ValidationGroup="Cadastro">
            </asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvConfSenha" runat="server" 
            ErrorMessage="Senha não confere."
            ControlToValidate="txtNovaSenha" 
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

        <span class="sm-button-wrapper">
            <span class="l"></span>
            <span class="r"></span>
            <asp:Button ID="btnCancelar" runat="server" 
                Text="Cancelar" CssClass="sm-button" 
                PostBackUrl="~/ListaUsuarios.aspx" />
        </span>

        <span class="sm-button-wrapper">
            <span class="l"></span>
            <span class="r"></span>
            <asp:Button ID="btnGravar" runat="server" Text="Gravar"
                CssClass="sm-button" OnClick="btnGravar_Click" 
                ValidationGroup="Cadastro"/>
        </span>
    </div>
</asp:Content>
