<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroCategoria.aspx.cs" Inherits="eCommerceBackEnd.CadastroCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Cadastro de Categoria</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Nova Categoria"></asp:Label><br />
    </h2>
    <div class="sm-postcontent">    
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label><br />
        <asp:TextBox ID="txtDescricao" runat="server" Width="168px" ValidationGroup="Cadastro"></asp:TextBox>&nbsp;
        <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ErrorMessage="Campo obrigatório." 
            ControlToValidate="txtDescricao"
            ValidationGroup="Cadastro"></asp:RequiredFieldValidator><br />
            
        <span class="sm-button-wrapper">
            <span class="l"></span>
            <span class="r"></span>
            <asp:Button ID="btnCancelar" runat="server" 
                Text="Cancelar" CssClass="sm-button" 
                PostBackUrl="~/ListaCategorias.aspx" />
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
