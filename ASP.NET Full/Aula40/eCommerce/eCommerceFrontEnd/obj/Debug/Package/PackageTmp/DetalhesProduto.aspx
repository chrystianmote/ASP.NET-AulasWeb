<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetalhesProduto.aspx.cs" Inherits="eCommerceFrontEnd.DetalhesProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Detalhes de Produto</title>
    <script src="Scripts/visuallightbox/js/jquery.min.js" type="text/javascript"></script>
    <link href="Scripts/visuallightbox/css/visuallightbox.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/visuallightbox/css/vlightbox.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader" runat="server" id="titulo">
        <img src="images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        Detalhes de Produto
    </h2>
    <div class="sm-postcontent">
        <div class="detalhes-produto">
            <div id="vlightbox">
                <a runat="server" id="lnkFoto1" class="vlightbox" href="" title="Foto 1">
                    <img runat="server" id="imgFoto" src="" alt="foto" class="foto"/>
                </a>
                <%= ObterHtmlFotos() %>
                <script src="Scripts/visuallightbox/js/visuallightbox.js" type="text/javascript"></script>
            </div>
            <span runat="server" id="spnNomeProduto" class="nome"></span>
            <span runat="server" id="spnNomeCategoria" class="categoria"></span><br />
            <span runat="server" id="spnCodigo" class="codigo"></span><br />                        
            <span runat="server" id="spnPreco" class="preco"></span><br />            
            <span class="sm-button-wrapper">
    	        <span class="l"></span>
    	        <span class="r"></span>
                <asp:Button ID="btnComprar" runat="server" Text="Adicionar ao carrinho" 
                    CssClass="sm-button" Font-Bold="true" onclick="btnComprar_Click" />                                                    	        
            </span><br />
            <div class="cleared"></div>
            <span runat="server" id="spnDescricao" class="descricao"></span><br />
                       
        </div>
        <div class="cleared"></div>            
    </div>
    <div class="cleared"></div>
</asp:Content>
