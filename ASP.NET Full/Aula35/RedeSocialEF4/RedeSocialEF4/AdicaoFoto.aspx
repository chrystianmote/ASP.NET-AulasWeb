<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AdicaoFoto.aspx.cs" Inherits="RedeSocialEF4.AdicaoFoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Adição de Foto ao Álbum</h1>
    <h2 style="color:Red" runat="server" id="h2Album"></h2>
    <hr />
    <p>
        Arquivo da foto:<br />
        <asp:FileUpload ID="fupFoto" runat="server" />
    </p>
    <p>
        Descrição:<br />
        <asp:TextBox runat="server" TextMode="MultiLine"
            Rows="5" Width="250px" ID="txtDescricao" />
    </p>
    <p>
        <asp:Button Text="Gravar" runat="server" 
            ID="btnGravar" onclick="btnGravar_Click" />
    </p>
</asp:Content>
