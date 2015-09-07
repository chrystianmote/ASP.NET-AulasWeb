<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="RedeSocialEF4.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Perfil de Usuário</h1>
    <p>
        Foto:<br />
        <img runat="server" id="imgFoto" alt="Foto do Perfil" />
    </p>
    <p>
        Nome:<br />
        <asp:Label runat="server" ID="lblNome" />
    </p>
    <p>
        E-mail:<br />
        <asp:Label runat="server" ID="lblEmail" />
    </p>
    <p>
        Data de Nascimento:<br />
        <asp:Label runat="server" ID="lblDataNasc" />
    </p>
    <p>
        Data de Cadastro:<br />
        <asp:Label runat="server" ID="lblDataCadastro" />
    </p>
    <p>
        <asp:Button Text="Álbuns de Foto" runat="server" 
            ID="btnAlbuns" />
    </p>
</asp:Content>
