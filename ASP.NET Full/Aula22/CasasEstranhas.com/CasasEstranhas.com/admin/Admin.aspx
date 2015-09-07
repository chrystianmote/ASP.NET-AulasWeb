<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="Admin.aspx.cs" Inherits="CasasEstranhas.com.admin.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h1>
        Administração do Site</h1>
    <hr />
    <h2>
        Categorias</h2>
    <div style="vertical-align: middle; padding-bottom: 10px;">
        <img id="img1" runat="server" src="~/img/btn_inserir.png" alt="inserir" title="Inserir" />
        <a id="Al" runat="server" href="~/admin/FormCategoria.aspx">Nova Categoria</a>
    </div>
    <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id"
        DataSourceID="sqldsCategorias" ForeColor="Black" GridLines="Horizontal">
        <Columns>
            <asp:TemplateField HeaderText="Opções" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select">
                        <img src="~/img/btn_casas.png" runat="server" title="Casas" alt="casas" />
                    </asp:LinkButton>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("id", "~/admin/FormCategoria.aspx?id={0}") %>'>
                        <img src="~/img/btn_alterar.png" runat="server" alt="Alterar" title="Alterar" />
                    </asp:HyperLink>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete">
                        <img src="~/img/btn_excluir.png" runat="server" alt="Excluir" title="Excluir" />
                    </asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="57px" />
            </asp:TemplateField>
            <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <br />
    <h2>
        Casas da Categoria Selecionada</h2>
    <div style="vertical-align: middle; padding-bottom: 10px;">
        <img id="img2" runat="server" src="~/img/btn_inserir.png" alt="inserir" title="Inserir" />
        <a id="Al0" runat="server" href="~/admin/FormCasa.aspx">Nova Cas</a><a href="~/admin/FormCategoria.aspx">a</a></div>
    <asp:GridView ID="gvCasas" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
        GridLines="Horizontal" DataSourceID="sqldsCasasPorCategoria">
        <Columns>
            <asp:TemplateField HeaderText="Opções" ShowHeader="False">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("id", "~/admin/FormCasa.aspx?id={0}") %>'>
                        <img src="~/img/btn_alterar.png" runat="server" alt="Alterar" title="Alterar" />
                    </asp:HyperLink>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete">
                        <img src="~/img/btn_excluir.png" runat="server" alt="Excluir" title="Excluir" />
                    </asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="45px" />
            </asp:TemplateField>
            <asp:BoundField DataField="nome" HeaderText="Nome">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="visitas" HeaderText="Visitas">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ofertas" HeaderText="Ofertas">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="data_finalizacao" HeaderText="Finalização">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="sqldsCasasPorCategoria" runat="server" ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>"
        DeleteCommand="DELETE FROM [Casa] WHERE [id] = @id" InsertCommand="INSERT INTO [Casa] ([id_categoria], [nome], [descricao], [preco_minimo], [visitas], [ofertas], [data_cadastro], [data_finalizacao], [maior_lance], [executor_lance], [data_lance]) VALUES (@id_categoria, @nome, @descricao, @preco_minimo, @visitas, @ofertas, @data_cadastro, @data_finalizacao, @maior_lance, @executor_lance, @data_lance)"
        SelectCommand="SELECT [id], [id_categoria], [nome], [descricao], [preco_minimo], [visitas], [ofertas], [data_cadastro], [data_finalizacao], [maior_lance], [executor_lance], [data_lance] FROM [Casa] WHERE ([id_categoria] = @id_categoria) ORDER BY [data_cadastro] DESC"
        UpdateCommand="UPDATE [Casa] SET [id_categoria] = @id_categoria, [nome] = @nome, [descricao] = @descricao, [preco_minimo] = @preco_minimo, [visitas] = @visitas, [ofertas] = @ofertas, [data_cadastro] = @data_cadastro, [data_finalizacao] = @data_finalizacao, [maior_lance] = @maior_lance, [executor_lance] = @executor_lance, [data_lance] = @data_lance WHERE [id] = @id">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvCategorias" Name="id_categoria" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="id_categoria" Type="Int32" />
            <asp:Parameter Name="nome" Type="String" />
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="preco_minimo" Type="Decimal" />
            <asp:Parameter Name="visitas" Type="Int32" />
            <asp:Parameter Name="ofertas" Type="Int32" />
            <asp:Parameter Name="data_cadastro" Type="DateTime" />
            <asp:Parameter Name="data_finalizacao" Type="DateTime" />
            <asp:Parameter Name="maior_lance" Type="Decimal" />
            <asp:Parameter Name="executor_lance" Type="String" />
            <asp:Parameter Name="data_lance" Type="DateTime" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="id_categoria" Type="Int32" />
            <asp:Parameter Name="nome" Type="String" />
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="preco_minimo" Type="Decimal" />
            <asp:Parameter Name="visitas" Type="Int32" />
            <asp:Parameter Name="ofertas" Type="Int32" />
            <asp:Parameter Name="data_cadastro" Type="DateTime" />
            <asp:Parameter Name="data_finalizacao" Type="DateTime" />
            <asp:Parameter Name="maior_lance" Type="Decimal" />
            <asp:Parameter Name="executor_lance" Type="String" />
            <asp:Parameter Name="data_lance" Type="DateTime" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqldsCategorias" runat="server" ConnectionString="<%$ ConnectionStrings:CasasEstranhasConnectionString %>"
        DeleteCommand="DELETE FROM [Categoria] WHERE [id] = @id" SelectCommand="SELECT [id], [descricao] FROM [Categoria] ORDER BY [descricao]">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>
