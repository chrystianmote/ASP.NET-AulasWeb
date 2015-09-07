<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eCommerceFrontEnd.Default" %>
<%--a linha abaixo permite o uso da classe WebConfigurationManager dentro de bindings--%>
<%@ Register Namespace="System.Web.Configuration" TagPrefix="cfg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Sua loja virtual de produtos de informática</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">    
    <h2 class="sm-postheader">
        <img src="images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        Bem-vindo à Loja Virtual da Softmark!
    </h2>
    <div class="sm-postcontent">
        <h2>Confira os produtos em destaque!</h2>
        <asp:ListView ID="lvDestaques" runat="server">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </div>
                <div class="cleared"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="item-destaque">
                    <img src='<%# WebConfigurationManager.AppSettings["UrlBaseFotos"] + Eval("IdProduto", "{0:d4}") + ".1.jpg" %>' alt="foto" />
                    <span><%# Eval("Nome") %></span><br />
                    <span class="preco"><%# Eval("Preco", "{0:c}") %></span><br />
                    <a href='<%# "DetalhesProduto.aspx?IdProduto=" + Eval("IdProduto") %>'>Ver detalhes</a>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <h4>Não há produtos em destaque.</h4>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
    <div class="cleared"></div>                                                 
</asp:Content>

