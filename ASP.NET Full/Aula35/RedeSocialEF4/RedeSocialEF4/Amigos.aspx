<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Amigos.aspx.cs" Inherits="RedeSocialEF4.Amigos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Amigos</h1>
    <a runat="server" href="~/NaoAmigos.aspx"
        style="margin:10px 0 20px 0;font-size:14px;display:block;">
        Abduzir novos amigos</a>
    <table>
        <asp:ListView runat="server" ID="lvAmigos" 
            onitemcommand="lvAmigos_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td style="width:100px;text-align:center;">
                        <a href='<%# "~/Perfil.aspx?IdUsuario=" + 
                            Eval("Id") %>' runat="server">
                            <img runat="server" alt="foto"
                                src='<%# "~/Fotos/" + 
                                Eval("Id","{0:d6}") + ".jpg" %>' />
                        </a>
                    </td>
                    <td style="width:250px">
                        <span style="font-weight:bold;">
                            <%# Eval("Nome") %>
                        </span>
                        <br />
                        <a style="font-style:italic;"
                            href='<%# "mailto:" + 
                            Eval("Email") %>'>
                            <%# Eval("Email") %>
                        </a>
                    </td>
                    <td>
                        <asp:Button Text="Libertar" 
                            CommandName="Libertar"
                            CommandArgument='<%# Eval("Id") %>'
                            runat="server" 
                            ID="btnLibertar" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </table>
</asp:Content>
