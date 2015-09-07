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
        <asp:DropDownList ID="ddlPessoas" runat="server" AutoPostBack="True" 
            DataSourceID="sqldsPessoas" DataTextField="Nome" DataValueField="Id" 
            Width="200px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sqldsImoveis" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ImoveisConnectionString %>" 
            SelectCommand="SELECT [Endereco] FROM [Imovel] WHERE ([IdPessoa] = @IdPessoa)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="IdPessoa" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" 
            DataSourceID="sqldsPessoas" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome">
                <ItemStyle Width="250px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
