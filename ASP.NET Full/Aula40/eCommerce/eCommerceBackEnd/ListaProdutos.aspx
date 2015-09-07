﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaProdutos.aspx.cs" Inherits="eCommerceBackEnd.ListaProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Produtos Cadastrados</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Produtos Cadastrados"></asp:Label><br />
    </h2>
    <div class="sm-postcontent">    
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" 
            OnRowCommand="gvLista_RowCommand" 
            EmptyDataText="Não há produtos cadastrados."
            Width="100%" >
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome do Produto">                    
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ações">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlFotos" runat="server" 
                            NavigateUrl='<%# Eval("IdProduto", 
                            "CadastroFotos.aspx?IdProduto={0}") %>' 
                            ImageUrl="Images/fotos.png" ToolTip="Fotos"></asp:HyperLink>
                        <asp:HyperLink ID="hlAlterar" runat="server" 
                            NavigateUrl='<%# Eval("IdProduto", "CadastroProduto.aspx?IdProduto={0}") %>' 
                            ImageUrl="Images/edit.png" ToolTip="Alterar"></asp:HyperLink>
                        <asp:LinkButton ID="btnExcluir" runat="server" CommandName="Excluir" 
                            CommandArgument='<%# Eval("IdProduto") %>' 
                            OnClientClick='return confirm("Deseja realmente excluir este registro?");'>
                            <img src="Images/delete.png" alt="Excluir" title="Excluir" style="border-width:0px;"/>
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="90px" HorizontalAlign="Center"/>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblListaVazia" runat="server" Text="Não há produtos cadastrados." Visible="false"></asp:Label>
    </div>
</asp:Content>