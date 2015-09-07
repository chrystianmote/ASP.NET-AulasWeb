<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Temas.aspx.cs" Inherits="RedeSocialEF4.Temas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Temas de Álbuns</h1>
    <p>
        Nome:<br />
        <asp:TextBox runat="server" ID="txtNome" Width="250px" />
    </p>
    <p>
        <asp:Button Text="Gravar" runat="server" ID="btnGravar" 
            onclick="btnGravar_Click" />
    </p>
    <hr />
    <table>
        <tr>
            <th style="width:80px;">Código</th>
            <th style="width:250px;">Nome</th>
            <th style="width:80px;">Ações</th>
        </tr>
        <asp:ListView runat="server" ID="lvTemas" onitemcommand="lvTemas_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td style="text-align:center;"><%# Eval("Id", "{0:d3}") %></td>
                    <td><%# Eval("Nome") %></td>
                    <td style="text-align:center;">
                        <asp:LinkButton Text="Excluir" 
                            runat="server" 
                            CommandName="Excluir"
                            CommandArgument='<%# Eval("Id") %>'/>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
</asp:Content>
