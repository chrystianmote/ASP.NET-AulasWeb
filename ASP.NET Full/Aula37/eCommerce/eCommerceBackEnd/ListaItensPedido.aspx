<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListaItensPedido.aspx.cs" Inherits="eCommerceBackEnd.ListaItensPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>SGP Design e-Commerce :: Itens de Pedido</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="postheadericon" />
        <asp:Label ID="lblTitulo" runat="server" Text="Itens do Pedido "></asp:Label><br />
    </h2>
    <div class="sm-postcontent">    
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" 
            OnRowCommand="gvLista_RowCommand" 
            EmptyDataText="Não há itens neste pedido.">
            <Columns>
                <asp:BoundField DataField="NomeProduto" 
                    HeaderText="Produto">
                    <ItemStyle Width="200px" HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="PrecoUnitario" 
                    HeaderText="Valor Unit." DataFormatString="{0:c}">
                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Quantidade" 
                    HeaderText="Qtde." DataFormatString="{0:d3}">
                    <ItemStyle Width="100px" HorizontalAlign="Center"/>
                </asp:BoundField>
                <asp:BoundField DataField="Subtotal" 
                    HeaderText="Subtotal" DataFormatString="{0:c}">
                    <ItemStyle Width="100px" HorizontalAlign="Right"/>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ações">
                    <ItemTemplate>                        
                        <asp:LinkButton ID="btnExcluir" runat="server" CommandName="Excluir" 
                            CommandArgument='<%# Eval("IdProduto") %>' 
                            OnClientClick='return confirm("Deseja realmente excluir este item de pedido?");'>
                            <img src="Images/delete.png" alt="Excluir" title="Excluir" style="border-width:0px;"/>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:HyperLink NavigateUrl="~/ListaPedidos.aspx" runat="server" Text="Voltar para a lista de pedidos" />
    </div>
</asp:Content>
