<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FechamentoCompra.aspx.cs" Inherits="eCommerceFrontEnd.FechamentoCompra" %>
<%@ Register assembly="UOL.PagSeguro" namespace="UOL.PagSeguro" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="Imagem" />
        <asp:Label ID="lblTitulo" runat="server" Text="Fechamento da Compra"></asp:Label>
    </h2>    
    <div class="sm-postcontent">
        <h3>Dados para Entrega:</h3>
        <p>
            Nome completo:<br />
            <asp:Label ID="lblNome" runat="server" Text=""></asp:Label><br />        
        </p>
        <p>
            Endereço:<br />
            <asp:Label ID="lblEndereco" runat="server" Text=""></asp:Label><br />
        </p>
        <p>
            E-mail:<br />
            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label><br />
        </p>
        <p>
            Telefone fixo:<br /> 
            <asp:Label ID="lblTelefoneFixo" runat="server" Text=""></asp:Label><br />
        </p>
        <p>
            Telefone móvel:<br />
            <asp:Label ID="lblTelefoneMovel" runat="server" Text=""></asp:Label><br />
        </p>
        
        <p>
            <asp:ImageButton ID="btnPagSeguro" runat="server" 
                ImageUrl="~/Images/btn_pagseguro.gif" OnClick="btnPagSeguro_Click" />
            <cc1:VendaPagSeguro ID="vpsPrincipal" runat="server" 
                Comportamento="Redirecionar" EmailCobranca="maroquio@gmail.com" 
                TipoFrete="DefinidoPeloCliente">
            </cc1:VendaPagSeguro>
        </p>
    </div>
</asp:Content>
