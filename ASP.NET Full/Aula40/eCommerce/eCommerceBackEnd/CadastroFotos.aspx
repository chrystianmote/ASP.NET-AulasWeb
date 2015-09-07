<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CadastroFotos.aspx.cs" Inherits="eCommerceBackEnd.CadastroFotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Cadastro de Fotos de Produto</title>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Fotos de Produto"></asp:Label><br />
    </h2>
    
    <div class="sm-postcontent">            
        <span><b>Produto:</b></span><br />
        <asp:Label ID="lblNome" runat="server" Text=""></asp:Label><br /><br /> 
        <span><b>Enviar nova foto:</b></span><br />
        <asp:FileUpload ID="fupFoto" runat="server" />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
            onclick="btnEnviar_Click" />
        <br /><br />
        <asp:ListView ID="lvFotos" runat="server" onitemcommand="lvFotos_ItemCommand">
            <LayoutTemplate>
                <div>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </div>
                <div class="cleared"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="foto-produto">
                    <img src='<%# "Fotos/" + Eval("Name") %>' alt="foto" />
                    <asp:LinkButton ID="btnExcluir" runat="server" CommandName="Excluir" 
                        CommandArgument='<%# Eval("FullName") %>' 
                        OnClientClick="return confirm('Deseja realmente excluir esta foto?');">Excluir</asp:LinkButton>
                    <asp:LinkButton ID="btnPrincipal" runat="server" CommandName="Principal" 
                        CommandArgument='<%# Eval("FullName") %>'
                        OnClientClick="return confirm('Deseja tornar esta foto como principal?');">Principal</asp:LinkButton>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <h4>Este produto não possui fotos cadastradas.</h4>
            </EmptyDataTemplate>
        </asp:ListView>
        <span class="sm-button-wrapper">
            <span class="l"></span>
            <span class="r"></span>
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" 
            CssClass="sm-button" onclick="btnVoltar_Click" />
        </span>
    </div>
</asp:Content>
