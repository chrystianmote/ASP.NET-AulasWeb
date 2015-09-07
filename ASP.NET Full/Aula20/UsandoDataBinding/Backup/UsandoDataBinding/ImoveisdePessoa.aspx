<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImoveisdePessoa.aspx.cs" Inherits="UsandoDataBinding.ImoveisdePessoa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Imóveis da Pessoa selecionada</h1>
        <p>
            <asp:SqlDataSource ID="sqldsImoveis" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ImoveisConnectionString %>" 
                SelectCommand="SELECT [Id], [IdPessoa], [Endereco], [Quartos], [Garagens], [Aluguel], [Alugado] FROM [Imovel] WHERE ([IdPessoa] = @IdPessoa) ORDER BY [Id]">
                <SelectParameters>
                    <asp:QueryStringParameter Name="IdPessoa" QueryStringField="IdPessoa" 
                        Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="gvImoveis" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                CellPadding="4" DataKeyNames="Id" DataSourceID="sqldsImoveis" 
                EmptyDataText="Essa pessoa não possui imóveis cadastrados" ForeColor="Black" 
                GridLines="Vertical">
                <RowStyle BackColor="#F7F7DE" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Código" InsertVisible="False" 
                        ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Endereco" HeaderText="Endereço" 
                        SortExpression="Endereco" />
                    <asp:BoundField DataField="Quartos" HeaderText="Quartos" 
                        SortExpression="Quartos" />
                    <asp:BoundField DataField="Garagens" HeaderText="Garagens" 
                        SortExpression="Garagens" />
                    <asp:BoundField DataField="Aluguel" DataFormatString="{0:c}" 
                        HeaderText="Aluguel" SortExpression="Aluguel" />
                    <asp:CheckBoxField DataField="Alugado" HeaderText="Alugado" 
                        SortExpression="Alugado" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </p>
    </div>
    </form>
</body>
</html>
