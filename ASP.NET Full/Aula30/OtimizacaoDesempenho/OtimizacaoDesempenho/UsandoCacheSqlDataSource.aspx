<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoCacheSqlDataSource.aspx.cs" Inherits="OtimizacaoDesempenho.UsandoCacheSqlDataSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Usando Cache com SqlDataSource</h1>
        <asp:GridView runat="server" ID="gvCategorias" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="id" DataSourceID="sqldsCategorias" 
            ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="sqldsCategorias" CacheDuration="60" 
            ConnectionString="<%$ ConnectionStrings:EstoqueConnectionString %>" 
            EnableCaching="True" 
            SelectCommand="SELECT [id], [nome] FROM [Categoria] ORDER BY [nome]"/>
    </div>
    </form>
</body>
</html>
