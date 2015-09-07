<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="HistoricoPedidos.aspx.cs" Inherits="eCommerce.HistoricoPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Softmark e-Commerce :: Histórico de Pedidos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h2 class="sm-postheader">
        <img src="Images/postheadericon.png" width="26" height="26" alt="Imagem" />
        <asp:Label ID="lblTitulo" runat="server" Text="Histórico de Pedidos"></asp:Label>
    </h2>    
    <div class="sm-postcontent">
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundField DataField="IdPedido" HeaderText="Pedido" DataFormatString="{0:d6}">
                    <ItemStyle Width="50px" HorizontalAlign="Center" />                    
                </asp:BoundField>
                <asp:BoundField DataField="DataHora" HeaderText="Data e Hora" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}">
                    <ItemStyle HorizontalAlign="Center" Width="120px"/>                    
                </asp:BoundField>                
                <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total" DataFormatString="{0:c}">
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status">
                    <ItemStyle Width="160px" HorizontalAlign="Center" />
                </asp:BoundField>                
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblListaVazia" runat="server" Text="Não há pedidos com os parâmetros passados." Visible="false"></asp:Label>
    </div>
</asp:Content>
