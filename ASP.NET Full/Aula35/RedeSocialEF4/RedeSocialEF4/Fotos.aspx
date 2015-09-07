<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Fotos.aspx.cs" Inherits="RedeSocialEF4.Fotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .fotoAlbum
        {
            border:solid 2px gray;
            padding:5px;
            max-width:200px;
        }
        .divFotoAlbum
        {
            float:left;
            padding:10px;
            border:solid 1px black;
            max-width:220px;
            max-height:220px;
            margin:10px;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Fotos do Álbum</h1>
    <h2 style="color:Red" runat="server" id="h2Album"></h2>
    <asp:Label runat="server" ID="lblNomeDono" 
        Font-Size="16px" />
    <hr />
    <asp:Button ID="Button1" Text="Adicionar foto" runat="server" onclick="Unnamed1_Click" />
    <hr />
    <asp:ListView runat="server" ID="lvFotos" onitemcommand="lvFotos_ItemCommand" 
        onitemdatabound="lvFotos_ItemDataBound">
        <ItemTemplate>
            <div class="divFotoAlbum">
                <a href='<%# "~/DetalhesFoto.aspx?IdFoto=" +
                    Eval("Id") %>' runat="server">
                    <img class="fotoAlbum" src='<%# "~/FotosAlbuns/" +                     
                        Eval("Id", "{0:d9}") + ".jpg" %>' 
                        alt="foto" runat="server" />
                </a>
                <p>
                    <%--completa a descrição para que ela fique com 100
                    caracteres, toma os 50 primeiros e remove espaços
                    em branco das extremidades--%>
                    <%# Eval("Descricao").ToString().
                        PadRight(100).Substring(0, 50).Trim() %>
                </p>
                <p>
                    <asp:LinkButton Text="Excluir" 
                        runat="server" ID="btnExcluir"
                        CommandName="Excluir"
                        CommandArgument='<%# Eval("Id") %>' />
                </p>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <h3>Não há fotos neste álbum.</h3>
        </EmptyDataTemplate>
    </asp:ListView>
    <div style="clear:both;" />
</asp:Content>
