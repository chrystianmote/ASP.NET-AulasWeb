<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="UOL.PagSeguro" namespace="UOL.PagSeguro" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loja Exemplo</title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="banner">
            <img src="imagens/btnWebprefC.gif" alt="Formas de Pagamento" />
            <br />
            <h1>Loja Exemplo</h1>
        </div>
        <br />
        <div id="status_carrinho">
            <asp:ImageButton ID="btnLimpar" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/imagens/reload.png"
                ToolTip="Limpar Carrinho" onclick="LimparCarrinho" />
            <asp:Label ID="lblCarrinho" runat="server" Text="Seu carrinho possui 0 itens"></asp:Label>
            <asp:ImageButton ID="btnEfetuarPagamento" runat="server" ImageUrl="~/imagens/btnComprarBR.jpg"
                OnClick="btnEfetuarPagamento_Click" ImageAlign="AbsMiddle" />
        </div>
        <br />
        <div id="lista_itens">
            <asp:Repeater ID="dataRepeater" runat="server" DataSourceID="AccessDataSource1">
                <ItemTemplate>
                    <div id="item">
                        Código:
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' Font-Bold="True" />
                        <br />
                        Marca:
                        <asp:Label ID="TrademarkLabel" runat="server" Text='<%# Eval("Trademark") %>' Font-Bold="True" />
                        <br />
                        Modelo:
                        <asp:Label ID="ModelLabel" runat="server" Text='<%# Eval("Model") %>' Font-Bold="True" />
                        <br />
                        Categoria:
                        <asp:Label ID="CategoryLabel" runat="server" Text='<%# Eval("Category") %>' Font-Bold="True" />
                        <br />
                        Valor:
                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price", "{0:C}") %>' Font-Bold="True" />
                        <br />
                        <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("ID", "{0}") %>'
                            OnClick="AdicionarItem" Text="Adicionar ao Carrinho" />
                        <br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/CarsDB.mdb"
        SelectCommand="SELECT [ID], [Trademark], [Model], [Category], [Picture], [Price] FROM [Cars]">
    </asp:AccessDataSource>
    <cc1:VendaPagSeguro ID="VendaPagSeguro1" runat="server" EmailCobranca="suporte@lojamodelo.com.br">
    </cc1:VendaPagSeguro>
    </form>
</body>
</html>
