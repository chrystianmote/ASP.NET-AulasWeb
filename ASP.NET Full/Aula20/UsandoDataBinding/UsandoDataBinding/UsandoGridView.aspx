<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoGridView.aspx.cs" Inherits="UsandoDataBinding.UsandoGridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Pessoas Cadastradas</h1>
        <asp:SqlDataSource ID="sqldsPessoas" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ImoveisConnectionString %>" 
            SelectCommand="SELECT [Id], [Nome], [Endreco], [Email] FROM [Pessoa] ORDER BY [Id]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            DataKeyNames="Id" DataSourceID="sqldsPessoas" ForeColor="Black" 
            GridLines="Vertical" Height="189px" Width="630px">
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Id" DataFormatString="{0:d6}" HeaderText="Código" 
                    InsertVisible="False" ReadOnly="True" SortExpression="Id">
                <HeaderStyle BackColor="Red" ForeColor="White" HorizontalAlign="Center" 
                    Width="60px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="Endreco" HeaderText="Endereço" 
                    SortExpression="Endreco">
                <HeaderStyle HorizontalAlign="Left" Width="250px" />
                <ItemStyle HorizontalAlign="Left" Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                <HeaderStyle HorizontalAlign="Left" Width="250px" />
                <ItemStyle HorizontalAlign="Left" Width="250px" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="~/ImoveisDePessoa.aspx?IdPessoa={0}" 
                    HeaderText="Imóveis" Text="Visualisar">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="80px" />
                </asp:HyperLinkField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
