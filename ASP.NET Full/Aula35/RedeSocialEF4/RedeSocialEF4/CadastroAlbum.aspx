<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroAlbum.aspx.cs" Inherits="RedeSocialEF4.CadastroAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Cadastro de Novo Álbum</h1>
    <p>
        Nome:<br />
        <asp:TextBox runat="server" ID="txtNome" Width="250px"/>
    </p>

    <p>
        Descrição:<br />
        <asp:TextBox runat="server" ID="txtDescricao" 
            TextMode="MultiLine" Rows="5" Width="250px"/>
    </p>

    <p>
        Tema:<br />
        <asp:DropDownList runat="server" ID="ddlTema"
            Width="250px">            
        </asp:DropDownList>
    </p>

    <p>
        <asp:Button Text="Gravar" runat="server" ID="btnGravar" 
            onclick="btnGravar_Click" />
    </p>
</asp:Content>
