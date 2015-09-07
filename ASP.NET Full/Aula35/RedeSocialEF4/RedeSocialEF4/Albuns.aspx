<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Albuns.aspx.cs" Inherits="RedeSocialEF4.Albuns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1 runat="server" id="tituloAlbum">Álbuns de Fotos de</h1>
    <asp:Label runat="server" ID="lblUsuario" Font-Size="16px"/>
    <asp:HyperLink ID="hlCadastrarAlbum" NavigateUrl="~/CadastroAlbum.aspx" 
        runat="server" Text="Cadastrar novo álbum" />
    <hr />
    <table>
    <asp:ListView runat="server" ID="lvAlbuns" 
            OnItemDataBound="lvAlbuns_ItemDataBound" 
            OnItemCommand="lvAlbuns_ItemCommand" >
        <ItemTemplate>
            <tr>
                <td style="width:110px">
                    <a id="A1" href='<%# "~/Fotos.aspx?IdAlbum=" +
                        Eval("Id") %>' runat="server">
                        <img runat="server" id="imgCapaAlbum" alt="Capa" 
                            style="width:100px" />
                    </a>
                </td>
                <td>
                    <b><%# Eval("Nome") %></b><br />
                    <%# Eval("Descricao") %>
                </td>
                <td>
                    <asp:Button ID="btnExcluir" Text="Excluir" runat="server" 
                        CommandName="Excluir" 
                        CommandArgument='<%# Eval("Id") %>'
                        OnClientClick="return confirm('Deseja realmente excluir este álbum e todas as fotos que ele contém?');"/>
                </td>
                <td>
                    <asp:Button ID="Button2" Text="Fotos" runat="server"                         
                        PostBackUrl='<%# "~/Fotos.aspx?IdAlbum=" 
                            + Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    </table>
</asp:Content>
