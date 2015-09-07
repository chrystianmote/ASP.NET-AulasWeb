<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="eCommerceFrontEnd.Catalogo" %>
<%--a linha abaixo permite o uso da classe WebConfigurationManager dentro de bindings--%>
<%@ Register Namespace="System.Web.Configuration" TagPrefix="cfg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Catálogo de Produtos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader" runat="server" id="titulo">
        <img src="images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        Catálogo de Produtos
    </h2>
    <div class="sm-postcontent">
        <asp:ListView ID="lvCatalogo" runat="server">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </div>
                <div class="cleared"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="item-catalogo">
                    <img src='<%# WebConfigurationManager.AppSettings["UrlBaseFotos"] + Eval("IdProduto", "{0:d4}") + ".1.jpg" %>' alt="foto" />
                    <span class="nome"><%# Eval("Nome") %></span>
                    <span class="categoria"> (<%# Eval("NomeCategoria") %>)</span><br />
                    <span class="descricao"><%# Eval("Descricao").ToString().Length > 100 ? Eval("Descricao").ToString().Substring(0,100) + "..." : Eval("Descricao") %></span><br />
                    <span class="preco"><%# Eval("Preco", "{0:c}") %></span><br />
                    <a href='<%# "DetalhesProduto.aspx?IdProduto=" + Eval("IdProduto") %>'>Ver detalhes</a>
                </div>
                <div class="cleared"></div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <h4>Não há produtos a serem exibidos.</h4>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
    <div class="cleared"></div>
</asp:Content>
