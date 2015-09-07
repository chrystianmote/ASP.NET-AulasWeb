<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaPessoasDataSource.aspx.cs" Inherits="UsandoADO.NET.ListaPessoasDataSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:SqlDataSource ID="sqldsPessoas" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ImoveisConnectionString %>" 
            SelectCommand="SELECT [Nome], [Id] FROM [Pessoa] ORDER BY [Nome]">
        </asp:SqlDataSource>
        <br />
        <asp:DropDownList ID="ddlPessoas" runat="server" AutoPostBack="True" 
            DataSourceID="sqldsPessoas" DataTextField="Nome" DataValueField="Id" 
            Height="20px" Width="200px">
        </asp:DropDownList>
        <br />
        <asp:SqlDataSource ID="sqldsImoveis" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ImoveisConnectionString %>" 
            SelectCommand="SELECT [Endereco] FROM [Imovel] WHERE ([Id] = @Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="Id" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Id" 
            DataSourceID="sqldsPessoas" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome">
                <ItemStyle Width="250px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="sqldsImoveis" 
            DataTextField="Endereco" DataValueField="Endereco" Height="200px" Width="200px">
        </asp:ListBox>
        
    </div>
    </form>
</body>
</html>
