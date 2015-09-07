<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsandoSQLDataSource.aspx.cs"
    Inherits="UsandoDataBinding.UsandoSQLDataSource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sqldsPessoas" runat="server" ConnectionString="<%$ ConnectionStrings:ImoveisConnectionString %>"
            SelectCommand="SELECT [Id], [Nome] FROM [Pessoa]"></asp:SqlDataSource>
        <asp:ListBox ID="lbxPessoas" runat="server" AutoPostBack="True" DataSourceID="sqldsPessoas"
            DataTextField="Nome" DataValueField="Id" Height="146px" Width="170px"></asp:ListBox>
        <br />
        <asp:SqlDataSource ID="sqldsImoveis" runat="server" ConnectionString="<%$ ConnectionStrings:ImoveisConnectionString %>"
            SelectCommand="SELECT [Id], [Endereco] FROM [Imovel] WHERE ([IdPessoa] = @IdPessoa)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbxPessoas" Name="IdPessoa" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:ListBox ID="lbxImoveis" runat="server" AutoPostBack="True" DataSourceID="sqldsImoveis"
            DataTextField="Endereco" DataValueField="Id" Height="131px" Width="170px"></asp:ListBox>
        <asp:SqlDataSource ID="sqldsImovel" runat="server" ConnectionString="<%$ ConnectionStrings:ImoveisConnectionString %>"
            DeleteCommand="DELETE FROM [Imovel] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Imovel] ([IdPessoa], [Endereco], [Quartos], [Garagens], [Aluguel], [Alugado]) VALUES (@IdPessoa, @Endereco, @Quartos, @Garagens, @Aluguel, @Alugado)"
            SelectCommand="SELECT [Id], [IdPessoa], [Endereco], [Quartos], [Garagens], [Aluguel], [Alugado] FROM [Imovel] WHERE ([Id] = @Id)"
            UpdateCommand="UPDATE [Imovel] SET [IdPessoa] = @IdPessoa, [Endereco] = @Endereco, [Quartos] = @Quartos, [Garagens] = @Garagens, [Aluguel] = @Aluguel, [Alugado] = @Alugado WHERE [Id] = @Id">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbxImoveis" Name="Id" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="IdPessoa" Type="Int32" />
                <asp:Parameter Name="Endereco" Type="String" />
                <asp:Parameter Name="Quartos" Type="Int32" />
                <asp:Parameter Name="Garagens" Type="Int32" />
                <asp:Parameter Name="Aluguel" Type="Decimal" />
                <asp:Parameter Name="Alugado" Type="Boolean" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="IdPessoa" Type="Int32" />
                <asp:Parameter Name="Endereco" Type="String" />
                <asp:Parameter Name="Quartos" Type="Int32" />
                <asp:Parameter Name="Garagens" Type="Int32" />
                <asp:Parameter Name="Aluguel" Type="Decimal" />
                <asp:Parameter Name="Alugado" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>
        <br />
        &nbsp;
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White"
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Id"
            DataSourceID="sqldsImovel" ForeColor="Black" GridLines="Vertical" Height="50px"
            Width="300px">
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="Id" HeaderText="Código" InsertVisible="False" ReadOnly="True"
                    SortExpression="Id" />
                <asp:BoundField DataField="IdPessoa" HeaderText="Pessoa" SortExpression="IdPessoa" />
                <asp:BoundField DataField="Endereco" HeaderText="Endereço" SortExpression="Endereco" />
                <asp:BoundField DataField="Quartos" HeaderText="Quartos" SortExpression="Quartos" />
                <asp:BoundField DataField="Garagens" HeaderText="Garagens" SortExpression="Garagens" />
                <asp:BoundField DataField="Aluguel" HeaderText="Aluguel" SortExpression="Aluguel" />
                <asp:CheckBoxField DataField="Alugado" HeaderText="Alugado" SortExpression="Alugado" />
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Button ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Atualizar"></asp:Button>
                        &nbsp;<asp:Button ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancelar"></asp:Button>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:Button ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Inserir"></asp:Button>
                        &nbsp;<asp:Button ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancelar"></asp:Button>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Alterar"></asp:Button>
                        &nbsp;<asp:Button ID="LinkButton2" runat="server" CausesValidation="False" CommandName="New"
                            Text="Novo"></asp:Button>
                        &nbsp;<asp:Button ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete"
                            Text="Excluir" OnClientClick="return confirm ('Deseja realmente excluir?');">
                        </asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:DetailsView>
    </div>
    </form>
</body>
</html>
