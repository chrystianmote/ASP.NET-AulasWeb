<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormAjax.aspx.cs" Inherits="UsandoAjax.FormAjax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <h1>
            Cadastro de Cliente</h1>
        Cliente:<br />
        <asp:TextBox runat="server" ID="txtCliente" /><br />
        Bairro:<br />
        <asp:TextBox runat="server" ID="txtBairro" /><br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                Estados:<br />
                <asp:DropDownList runat="server" ID="ddlEstados" AutoPostBack="True" DataSourceID="sqldsEstados"
                    DataTextField="NomeEstado" DataValueField="UF">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqldsEstados" runat="server" ConnectionString="<%$ ConnectionStrings:ClientesConnectionString %>"
                    SelectCommand="SELECT [UF], [NomeEstado] FROM [Estado] ORDER BY [NomeEstado]">
                </asp:SqlDataSource>
                <br />
                Cidades:<br />
                <asp:DropDownList runat="server" ID="ddlCidades" DataSourceID="sqldsCidades" DataTextField="NomeCidade"
                    DataValueField="Codigo">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sqldsCidades" runat="server" ConnectionString="<%$ ConnectionStrings:ClientesConnectionString %>"
                    SelectCommand="SELECT [Codigo], [NomeCidade], [UF] FROM [Cidade] WHERE ([UF] = @UF) ORDER BY [NomeCidade]">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlEstados" Name="UF" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>



        <asp:SqlDataSource ID="sqldsClientes" runat="server" ConnectionString="<%$ ConnectionStrings:ClientesConnectionString %>"
            DeleteCommand="DELETE FROM [Cliente] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [Cliente] ([Nome], [Bairro], [CodigoCidade]) VALUES (@Nome, @Bairro, @CodigoCidade)"
            SelectCommand="SELECT [Codigo], [Nome], [Bairro], [CodigoCidade] FROM [Cliente]"
            UpdateCommand="UPDATE [Cliente] SET [Nome] = @Nome, [Bairro] = @Bairro, [CodigoCidade] = @CodigoCidade WHERE [Codigo] = @Codigo">
            <DeleteParameters>
                <asp:Parameter Name="Codigo" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:ControlParameter ControlID="txtCliente" Name="Nome" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtBairro" Name="Bairro" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="ddlCidades" Name="CodigoCidade" PropertyName="SelectedValue"
                    Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nome" Type="String" />
                <asp:Parameter Name="Bairro" Type="String" />
                <asp:Parameter Name="CodigoCidade" Type="Int32" />
                <asp:Parameter Name="Codigo" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Button Text="Cadastrar" runat="server" ID="btnCadastrar" OnClick="btnCadastrarClick" />
    </div>
    </form>
</body>
</html>
