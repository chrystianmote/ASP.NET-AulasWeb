<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NaoAmigos.aspx.cs" Inherits="RedeSocialEF4.NaoAmigos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Seres não abduzidos</h1>
    <table>
        <asp:ListView runat="server" ID="lvNaoAmigos" 
            onitemcommand="lvNaoAmigos_ItemCommand" >
            <ItemTemplate>
                <tr>
                    <td style="width:100px;text-align:center;">
                        <img runat="server" alt="foto"
                            src='<%# "~/Fotos/" + 
                            Eval("Id","{0:d6}") + ".jpg" %>' />
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
                        <asp:Button Text="Abduzir" 
                            CommandName="Abduzir"
                            CommandArgument='<%# Eval("Id") %>'
                            runat="server" 
                            ID="btnAbduzir" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td colspan="3">
                        Não há seres para abduzir. 
                        Você já abduziu todos!
                    </td>
                </tr>
            </EmptyDataTemplate>
        </asp:ListView>
    </table>
</asp:Content>
