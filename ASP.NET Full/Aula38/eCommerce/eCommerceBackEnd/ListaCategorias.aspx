<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaCategorias.aspx.cs" Inherits="eCommerceBackEnd.ListaCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Categorias Cadastradas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Categorias Cadastradas"></asp:Label><br />
    </h2>
    <div class="sm-postcontent">    
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" 
            OnRowCommand="gvLista_RowCommand" 
            EmptyDataText="Não há categorias cadastradas."
            Width="100%">
            <Columns>
                <asp:BoundField DataField="IdCategoria" 
                    HeaderText="Código" DataFormatString="{0:d3}">
                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Descricao" HeaderText="Nome da Categoria">                    
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ações">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlProdutos" runat="server" 
                            NavigateUrl='<%# Eval("IdCategoria", "ListaProdutos.aspx?IdCategoria={0}") %>' 
                            ImageUrl="Images/produtos.png" ToolTip="Produtos" CssClass="botao"></asp:HyperLink>
                        <asp:HyperLink ID="hlAlterar" runat="server"
                            NavigateUrl='<%# Eval("IdCategoria", "CadastroCategoria.aspx?IdCategoria={0}") %>' 
                            ImageUrl="Images/edit.png" ToolTip="Alterar" CssClass="botao"></asp:HyperLink>
                        <asp:LinkButton ID="btnExcluir" runat="server" CommandName="Excluir" 
                            CommandArgument='<%# Eval("IdCategoria") %>' 
                            OnClientClick='return confirm("Deseja realmente excluir esta categoria?");'>
                            <img src="Images/delete.png" alt="Excluir" title="Excluir" style="border-width:0px;"/>
                        </asp:LinkButton>                        
                    </ItemTemplate>
                    <ItemStyle Width="90px" />                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblListaVazia" runat="server" Text="Não há categorias cadastradas." Visible="false"></asp:Label>
    </div>
</asp:Content>